using Back_Blogs.Dto;
using Back_Blogs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceCategory _service;
        
        public CategoryController(IServiceCategory service)
        {
            _service = service;
        }

        [HttpPost("Add-Category")]
        public async Task<IActionResult> CreateCategory(string category)
        {
            CatgDto catg = await _service.AddCategory(category);
            return catg != null ? Ok(catg) : BadRequest();
        }
    }
}
