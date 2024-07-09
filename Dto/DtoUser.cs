using Back_Blogs.Models;

namespace Back_Blogs.Dto
{
    public class DtoUser
    {
        public string UserName { get; set; }


        public static DtoUser ToDto(AppUser user)
        {
            return new DtoUser
            {
                UserName = user.UserName
            };
        }

    }
}
