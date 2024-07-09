using Back_Blogs.Data;
using Back_Blogs.Dto;
using Back_Blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_Blogs.Services
{
    public class ServiceBlog : IServiceBlog
    {
        private readonly AppDbContext _db;
        public ServiceBlog(AppDbContext db)
        {
            _db = db;   
        }

        public async Task<DtoComment> AddComment(DtoAddComment comment)
        {
            var blog = await _db.Blogs.SingleOrDefaultAsync(b => b.Id == comment.Id);
            if (blog == null) return null;

            var user = await _db.Users.SingleOrDefaultAsync(u => u.Id == comment.IdUser);
            if (user == null) return null;
            var newComment = new Comment
            {
                IdBlog = comment.Id,
                Date = DateTime.Now,
                IdUser = comment.IdUser,
                Text = comment.Comment,
                AppUser = user
            };

            blog.Comments.Add(newComment);    
            try
            {
                await _db.SaveChangesAsync();
                return DtoComment.ToDto(newComment);
            }
            catch (DbUpdateException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }
        
        public async Task<Blog> CreatBlog(BlogCreatDto blog)
        {
            Image image = null;
            if ( blog.FileImage != null )
            {
                using var stream = new MemoryStream();
                await blog.FileImage.CopyToAsync(stream);
                 image = new Image() {
                     ImageData = stream.ToArray() ,
                     Text = "Text1",
                     Title = "Titre1"
                 };
            }     
            Category category = _db.Categories.SingleOrDefault(c => c.Type == blog.category);
            Blog _blog = new Blog()
            {
                Text = blog.Text,
                Titre = blog.Titre,
                Date = DateTime.Now,
                Category = category,
                IdUser = blog.IdUser,
                Image = image
            };
            _db.Blogs.Add(_blog);
            try
            {
              await  _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            return _blog;
        }
        
        public List<DtoBlog> GetAllBlogs()
        {
            List<Blog> blogs = _db.Blogs.ToList();
            List<DtoBlog> _blogs = blogs.Select(b => DtoBlog.ToDto(b)).ToList();           
            return _blogs;
        }

        public async Task<DtoBlog> GetBlogById(int id)
        {
            Blog blog = await _db.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            DtoBlog blg = blog != null ? DtoBlog.ToDto(blog) : null;
            return blg;
        }

        public  async Task<DtoBlog> SelectFirstBlog()
        {
            Blog blog = _db.Blogs.FirstOrDefault();
            DtoBlog _blog = null;
            if (blog != null)
            {
                _blog = DtoBlog.ToDto(blog);
            }
            return _blog;   
        }

        public async Task<BlogCreatDto> UpdateBlog(int id, BlogCreatDto blog)
        {
            Image image = null;
            Blog blg = await _db.Blogs.FindAsync(id);
            if (blog.FileImage != null)
            {
                using var stream = new MemoryStream();
                await blog.FileImage.CopyToAsync(stream);
                if (blg.Image == null)
                {
                    blg.Image = new Image();
                    blg.Image.Title = "Titre";
                    blg.Image.Text = "Texte";
                }
                blg.Image.ImageData = stream.ToArray();
            }
            // var category = blg.Category;
            //category.Type = blog.category != "" ? blog.category : blg.Category.Type ;
            blg.Text = blog.Text != null ? blog.Text : blg.Text;
            blg.Titre = blog.Titre != null ? blog.Titre : blg.Titre;
            blg.IdUser = blog.IdUser != null ? blog.IdUser : blg.IdUser;
            //.Category = category ;
            blg.Date = blog.Date != null ? DateTime.UtcNow : blg.Date;
            blg.Comments = blg.Comments;
            blg.Image = image != null ? image : blg.Image;
            _db.Blogs.Update(blg);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                return null;
            }
            return blog ;
        }
    }
}
