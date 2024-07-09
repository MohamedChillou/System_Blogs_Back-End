namespace Back_Blogs.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int IdBlog { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
