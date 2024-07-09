using Back_Blogs.Dto;
using Back_Blogs.Models;
using Back_Blogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_Blogs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IServiceBlog _service;
        private readonly ILogger<BlogController> _logger;   
        
        public BlogController(IServiceBlog service , ILogger<BlogController> logger) { 
            _service = service;
            _logger = logger;
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> SelectAll()
        {
            var blogs = _service.GetAllBlogs();
            return Ok(blogs);
        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(DtoAddComment comment)
        {
            var cmnt = await _service.AddComment(comment);
            return cmnt != null ? Ok(cmnt) : BadRequest(new {Message = "Erreur"});
        }

        [HttpGet("Test")]
        public IActionResult TestApi ()
        {
            return Ok(new {  message = "tres bien" });
        }

        [HttpPost("Add-Blog")]
        public async Task<IActionResult> CreateBlog(BlogCreatDto blog)
        {
            Blog _blog = await _service.CreatBlog(blog);
            _logger.LogInformation("Salam");
            return _blog != null ? Ok(blog) : BadRequest();
        }

        [HttpGet("First-blog")]
        public async Task<IActionResult> GetFirstBlog()
        {
            DtoBlog blog = await _service.SelectFirstBlog();
            return Ok(blog);
        }

        [HttpPut("Update-Blog/{id}")]
        public async Task<IActionResult> UpdateBlog(int id, BlogCreatDto blog)
        {
            var result = await _service.UpdateBlog(id, blog);
            return result != null ? Ok(result) : BadRequest(new { erreur = "Erreur de la modification"});
        }

        [HttpGet("Get-One-Blog")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var blog = await _service.GetBlogById(id);
            return blog != null ? Ok(blog) : BadRequest(new {Message = "Erreur"});
        }


    }
}
