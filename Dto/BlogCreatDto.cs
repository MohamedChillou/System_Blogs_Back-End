using Back_Blogs.Models;

namespace Back_Blogs.Dto
{
    public class BlogCreatDto
    {
        public string Titre { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ? category { get; set; }
        public IFormFile ? FileImage { get; set; }
        public string IdUser { get; set; }


    
    }
}
