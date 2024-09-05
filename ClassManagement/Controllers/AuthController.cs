using DemoVerificationOTP.Dtos.FormLogin;
using DemoVerificationOTP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoVerificationOTP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login (DefaultLoginDto input)
        {
            try
            {
                _authService.DefaultLogin(input);
                return Ok("Sinh OTP thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpPost("login-otp")]
        public IActionResult LoginOTP(LoginWithOTPDto input)
        {
            try
            {
                return Ok(_authService.LoginWithOtp(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
