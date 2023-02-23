namespace BlogEngine.API.Services.Common.User
{
    using Entities;
    using Models.User;

    public interface ILoginUser
    {
        Task<User?> LoginUser(LoginUser loginUser);
    }
}