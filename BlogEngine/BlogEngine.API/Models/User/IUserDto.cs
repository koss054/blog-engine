namespace BlogEngine.API.Models.User
{
    public interface IUserDto
    {
        string UserName { get; }

        string Token { get; }
    }
}