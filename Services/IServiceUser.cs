using Back_Blogs.Dto;
using Back_Blogs.Models;

namespace Back_Blogs.Services
{
    public interface IServiceUser
    {
        public Task<UserSingUp> AddUser(UserSingUp user);
        public Task<List<UserSelectDto>> SelectAll();
        public Task<DtoMessageUser> Login(string username, string password);
        public Task<TokenDto> GenerationToken(AppUser user);
        public Task<AppUser> GetUserById(string id);


    }
}
