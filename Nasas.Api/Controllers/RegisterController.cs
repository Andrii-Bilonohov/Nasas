using Microsoft.AspNetCore.Mvc;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;

namespace Nasas.Api.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public RegisterController(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }


        [HttpPost]
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
