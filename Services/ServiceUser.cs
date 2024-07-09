using Back_Blogs.Dto;
using Back_Blogs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Back_Blogs.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public ServiceUser(UserManager<AppUser> userManager ,IConfiguration configuration)
        {
            _config = configuration;
            _userManager = userManager;
        }

        public async Task<UserSingUp> AddUser(UserSingUp user)
        {
            AppUser _user = new AppUser()
            {
                UserName = user.Name,
                Email = user.Email,
                PhoneNumber = user.Phone,
            };
            var result = await _userManager.CreateAsync(_user,user.Password);

            return result.Succeeded ? user : null ; 
        }

        public async Task<TokenDto> GenerationToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id));
            claims.Add(new Claim(ClaimTypes.Role,"User"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));
            var infos = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var tokenInfos = new JwtSecurityToken(
                claims : claims,
                issuer : _config["JWT:Issuer"],
                audience : _config["JWT:Audiance"],
                expires: DateTime.Now.AddDays(1),
                signingCredentials:infos
                );
            return new TokenDto
            {
                Id = user.Id,
                Expire = tokenInfos.ValidTo,
                Token = new JwtSecurityTokenHandler().WriteToken(tokenInfos)
            };
        }

        public async Task<AppUser> GetUserById(string id)
            =>  await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);
        
        public async Task<DtoMessageUser> Login(string username, string password)
        {
            var message = new DtoMessageUser();
            var user = await _userManager.FindByNameAsync(username);
            var result =  await _userManager.CheckPasswordAsync(user, password);
            if (result)
            {
                var token = await GenerationToken(user);
                message.Message = "Login avec success";
                message.IsLogin = true;
                message.Id = user.Id;
                message.Token = token is not null ? token : null;
                return message;
            }
            message.Message = "User ou Mot de passe est incorrecte";
            return message;
        }

        public async Task<List<UserSelectDto>> SelectAll()
        {
             List <UserSelectDto> users = new List<UserSelectDto> ();

            _userManager.Users.ToList().ForEach(user =>
            {
                users.Add(new UserSelectDto()
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Phone = user.PhoneNumber
                });
            });

            return users;
        }
    }
}
