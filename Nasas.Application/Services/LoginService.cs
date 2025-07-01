using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Abstraction.Models;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;
using Nasas.Domain.Models;

namespace Nasas.Application.Services
{
    public class LoginService : ILoginService
    { 
        private readonly ILoginRepository _loginRepository;


        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
        }


        public Task<Login> LoginAsync(LoginDto loginDtos, CancellationToken cancellationToken)
        {
            if (loginDtos == null)
            {
                throw new ArgumentNullException(nameof(loginDtos));
            }

            return _loginRepository.GetLoginAsync(loginDtos.UserName, loginDtos.Password, cancellationToken);
        }

        public async Task<Login> RegisterAsync(RegisterDto registerDtos, CancellationToken cancellationToken)
        {
            if (registerDtos == null)
            {
                throw new ArgumentNullException(nameof(registerDtos));
            }

            var existsLogin = await _loginRepository.IsLoginExistsAsync(new Login
            {
                UserName = registerDtos.UserName,
                Email = registerDtos.Email,
                Password = registerDtos.Password,
            }, cancellationToken);

            if (existsLogin)
            {
                throw new InvalidOperationException("Login already exists.");
            }

            var newLogin = new Login
            {
                UserName = registerDtos.UserName,
                Email = registerDtos.Email,
                Password = registerDtos.Password,
            };

            return await _loginRepository.AddAsync(newLogin, cancellationToken);
        }
    }
}
