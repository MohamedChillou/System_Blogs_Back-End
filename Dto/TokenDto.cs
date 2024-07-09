namespace Back_Blogs.Dto
{
    public class TokenDto
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public DateTime Expire {  get; set; }
        public string Message { get; set; }

    }
}
