namespace BlogEngine.API.Models.User
{
    public class LoginUser : IUserDto
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}