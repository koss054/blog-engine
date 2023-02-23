namespace BlogEngine.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Models.User;
    using Entities;
    using BlogEngine.API.Services.Common.User;
    using BlogEngine.API.Common;
    using Microsoft.AspNetCore.Authorization;

    public class UsersController : BaseApiController
    {
        IUserService _userService;
        ITokenService _tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(RegisterUser registerUser)
        {
            var user = await _userService.RegisterUser(registerUser);

            if (string.IsNullOrWhiteSpace(user.UserName)) return BadRequest(registerUser);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
            };

            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUser loginUser)
        {
            var user = await _userService.LoginUser(loginUser);

            if (user == null) return Unauthorized(loginUser);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
            };

            return Ok(userDto);
        }
    }
}