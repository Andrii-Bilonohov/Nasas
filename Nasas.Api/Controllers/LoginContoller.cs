using Microsoft.AspNetCore.Mvc;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Output;

namespace Nasas.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginContoller : ControllerBase 
    {
        private readonly ILoginService _loginService;

        public LoginContoller(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }

        [HttpGet]
        public async Task<IActionResult> Login(LoginDto login, CancellationToken cancellationToken)
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
    }
}
