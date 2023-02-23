namespace BlogEngine.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Models.User;
    using Entities;
    using BlogEngine.API.Services.Common.User;

    public class UsersController : BaseApiController
    {
        IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(RegisterUser registerUser) {
            var isUserRegistered = await _service.RegisterUser(registerUser);

            if (!isUserRegistered) return BadRequest(registerUser);

            return Ok(registerUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUser loginUser) {
            return await _service.LoginUser(loginUser);
        }
    }
}