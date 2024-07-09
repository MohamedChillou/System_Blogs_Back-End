using Back_Blogs.Dto;
using Back_Blogs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _service;
        public UserController(IServiceUser service)
        {
            _service = service;
        }

        [HttpPost("Create-User")]
        public async Task<IActionResult> AddUser( [FromBody] UserSingUp user)
        {
            UserSingUp _user = await _service.AddUser(user);
            return  _user != null ? Ok(_user) : BadRequest("Erreur de Sing Up");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(DtoLogin login)
        {
            var message = await _service.Login(login.Username, login.Password);
            return  message.IsLogin == true ? Ok(message) : BadRequest(new { message = message.Message });
        }

        [HttpGet("Get-Token")]
        public async Task<IActionResult> GenerateTokn(string id)
        {
            var user = _service.GetUserById(id).Result;
            var token = _service.GenerationToken(user);
            return token is not null ? Ok(token) : BadRequest("Erreur");
        }

        [HttpGet("Get-Users")]
        public async Task<IActionResult> GetAllUsers()
            =>  Ok(_service.SelectAll());
        
    }
}
