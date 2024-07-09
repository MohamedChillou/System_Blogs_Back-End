using Back_Blogs.Models;

namespace Back_Blogs.Dto
{
    public class DtoComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public DtoUser User { get; set; }


        public static DtoComment ToDto(Comment comment)
        {
            return new DtoComment
            {
                Id = comment.Id,
                Date = comment.Date,
                Text = comment.Text,
                User = comment.AppUser != null ? DtoUser.ToDto(comment.AppUser) : null
            };
        }
    }
}
