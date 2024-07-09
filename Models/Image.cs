using Microsoft.AspNetCore.Identity;

namespace Back_Blogs.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public string Text { get; set; }

        public int ? IdBlog { get; set; }
        public virtual Blog Blog { get; set; }
        
        public string ? IdUser {  get; set; }
        public virtual AppUser User { get; set; }

    }
}
