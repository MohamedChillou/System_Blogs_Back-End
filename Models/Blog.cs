namespace Back_Blogs.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        
        public virtual Category Category { get; set; }
        
        public virtual Image Image { get; set; }
        
        public virtual List<Comment> Comments { get; set;} = new List<Comment>();

        public string ? IdUser { get; set; }
        public virtual AppUser User { get; set; }
    }
}
