using Back_Blogs.Models;

namespace Back_Blogs.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public byte[] ImageData { get; set; }
        public string Text { get; set; } = string.Empty;

        public static ImageDto ToDto(Image image)
        {
            return new ImageDto
            {
                Id = image.Id,
                Text = image.Text,
                Title = image.Title,
                ImageData = image.ImageData
            };
        }
    }
}
