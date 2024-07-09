namespace Back_Blogs.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int ? IdBlog { get; set; }
        public virtual Blog Blog { get; set; }

        public string ? IdUser { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
