using Microsoft.AspNetCore.Mvc;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;

namespace Nasas.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class LoginContoller : ControllerBase
    {
        private readonly ILoginService _loginService;


        public LoginContoller(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login, CancellationToken cancellationToken)
        {
            if (login == null)
            {
                return BadRequest("Login data is required");
            }

            try
            {
                var loginResult = await _loginService.LoginAsync(login, cancellationToken);
                if (loginResult == null)
                {
                    return Unauthorized("Invalid credentials");
                }
                return Ok(loginResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto, CancellationToken cancellationToken)
        {
            if (registerDto == null)
            {
                return BadRequest("Registration data is required");
            }

            try
            {
                var registrationResult = await _loginService.RegisterAsync(registerDto, cancellationToken);
                if (registrationResult == null)
                {
                    return BadRequest("Registration failed");
                }
                return CreatedAtAction(nameof(Register), new { id = registrationResult.Id }, registrationResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}