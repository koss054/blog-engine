namespace BlogEngine.API.Services.Common
{
    using Entities;
    using Models.User;

    public interface IRegisterUser
    {
        Task<bool> RegisterUser(RegisterUser registerUser);
    }
}