namespace BlogEngine.API.Services.Common.User
{
    using Entities;
    using Models.User;

    public interface IRegisterUser
    {
        Task<User?> RegisterUser(RegisterUser registerUser);
    }
}