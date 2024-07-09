using Back_Blogs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back_Blogs.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder
                .HasMany(u => u.comments)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.blogs)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Image)
                .WithOne(i => i.User)
                .HasForeignKey<Image>(i => i.IdUser)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
