namespace BlogEngine.API.Services.Common.User
{
    using Microsoft.AspNetCore.Mvc;
    
    using Models.User;

    public interface ILoginUser
    {
        Task<IActionResult> LoginUser(LoginUser loginUser);        
    }
}