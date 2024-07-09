using Back_Blogs.Dto;
using Back_Blogs.Models;

namespace Back_Blogs.Services
{
    public interface IServiceCategory
    {
        public Task<CatgDto> AddCategory(string category);
    }
}
