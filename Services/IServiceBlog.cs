using Back_Blogs.Dto;
using Back_Blogs.Models;

namespace Back_Blogs.Services
{
    public interface IServiceBlog
    {
        public Task<Blog> CreatBlog(BlogCreatDto blog); 
        public Task<DtoBlog> SelectFirstBlog();
        public  List<DtoBlog> GetAllBlogs();
        public Task<BlogCreatDto> UpdateBlog(int id,BlogCreatDto blog);
        public Task<DtoBlog> GetBlogById(int id);
        public Task<DtoComment> AddComment(DtoAddComment comment);
    }
}
