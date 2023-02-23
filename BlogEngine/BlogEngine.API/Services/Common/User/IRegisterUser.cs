namespace BlogEngine.API.Services.Common.User
{
    using Models.User;

    public interface IRegisterUser
    {
        Task<bool> RegisterUser(RegisterUser registerUser);
    }
}