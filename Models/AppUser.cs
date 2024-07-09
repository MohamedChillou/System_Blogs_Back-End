using Microsoft.AspNetCore.Identity;

namespace Back_Blogs.Models
{
    public class AppUser : IdentityUser
    {
        public virtual List<Comment> comments { get; set; }

        public virtual List<Blog> blogs { get; set; }

        public virtual Image Image { get; set; }

    }
}
