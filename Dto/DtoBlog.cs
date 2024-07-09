using Back_Blogs.Models;

namespace Back_Blogs.Dto
{
    public class DtoBlog
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } 
        public List<DtoComment> Comments { get; set; } 
        public ImageDto Image { get; set; }
        public DtoUser User { get; set; }

        public static DtoBlog ToDto(Blog blog)
        {
            return new DtoBlog
            {
                Id = blog.Id,
                Titre = blog.Titre,
                Text = blog.Text,
                Date = blog.Date,
                Category = blog.Category != null ? blog.Category.Type : null,
                Image = blog.Image != null ? ImageDto.ToDto(blog.Image) : null,
                User = blog.User != null ? DtoUser.ToDto(blog.User) : null,
                Comments = blog.Comments?.Select(c => DtoComment.ToDto(c)).ToList()
            };
        }
    }
}
