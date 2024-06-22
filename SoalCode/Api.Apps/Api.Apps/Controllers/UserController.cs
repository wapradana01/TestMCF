using Core.RequestInputs;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Apps.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("user/login")]
        public async Task<IActionResult> Login([FromBody] LoginInput input)
        {
            var result = await _userService.Login(input);

            if (string.IsNullOrEmpty(result.AccessToken))
                return Unauthorized();

            return Ok(result);
        }
    }
}
