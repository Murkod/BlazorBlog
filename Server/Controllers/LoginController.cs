using Blog.Server.Services.Auth;
using Blog.Shared.Models.DTO.AuthorDTOS;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAuthor(loginDto);

            if (token == null)
            {
                return Unauthorized("xD");
            }


            return Ok(token);
        }
    }
}
