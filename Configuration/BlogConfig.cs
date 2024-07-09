using Back_Blogs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back_Blogs.Configuration
{
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(b => b.Category)
                .WithOne(c => c.Blog)
                .HasForeignKey<Category>(c => c.IdBlog)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(b => b.Comments)
                .WithOne(com => com.Blog)
                .HasForeignKey(com => com.IdBlog)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Image)
                .WithOne(i => i.Blog)
                .HasForeignKey<Image>(i => i.IdBlog)
                .OnDelete(DeleteBehavior.Restrict);



        }

    }
}
