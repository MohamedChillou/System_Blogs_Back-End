using Back_Blogs.Configuration;
using Back_Blogs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Back_Blogs.Data
{
    public class AppDbContext :IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) 
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BlogConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new ImageConfig());
            builder.ApplyConfiguration(new UserConfig());
            base.OnModelCreating(builder);

        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }    
    }
}
