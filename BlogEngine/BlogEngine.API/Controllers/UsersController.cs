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
            var user = await _service.RegisterUser(registerUser);

            if (user == null) return BadRequest(registerUser);

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUser loginUser) {
            var user = await _service.LoginUser(loginUser);

            if (user == null) return Unauthorized(loginUser);

            return Ok(user);
        }
    }
}