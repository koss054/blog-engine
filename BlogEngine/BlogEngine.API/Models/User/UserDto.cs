namespace BlogEngine.API.Models.User
{
    public class UserDto : IUserDto
    {
        public string UserName { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}