namespace Back_Blogs.Dto
{
    public class DtoMessageUser
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public bool IsLogin {  get; set; } = false;
        public TokenDto Token { get; set; }
    }
}
