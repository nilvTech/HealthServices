using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientServices.Models.Authentication;
using PatientServices.Services.Interfaces;

namespace PatientServices.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("RegisterUser")]
        public async Task<bool> Register(LoginUser user)
        {
            return await _authService.RegisterUser(user);

        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _authService.LoginUser(user);
            if (result == true)
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(tokenString);
            }
            return BadRequest();
        }
    }
}
