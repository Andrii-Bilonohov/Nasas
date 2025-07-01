using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
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
            _loginRepository = loginRepository;
        }


        public async Task<Login> LoginAsync(LoginDto loginDtos, CancellationToken cancellationToken)
        {

            if (loginDtos == null)
            {
                throw new ArgumentNullException(nameof(loginDtos), "LoginDto cannot be null");
            }

            var login = await _loginRepository.GetLoginAsync(loginDtos.UserName, loginDtos.Password, cancellationToken);
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login), "Login cannot be null");
            }

            return login;
        }


        public async Task<bool> RegisterAsync(RegisterDto registerDtos, CancellationToken cancellationToken)
        {
            if (registerDtos == null)
            {
                throw new ArgumentNullException(nameof(registerDtos), "RegisterDto cannot be null");
            }

            var existingLogins = await IsExistingLogin(registerDtos);

            var newLogin = new Login
            {
                UserName = registerDtos.UserName,
                Password = registerDtos.Password,
                Email = registerDtos.Email
            };

            await _loginRepository.AddAsync(newLogin, cancellationToken);

            return true;
        }


        private async Task<bool> IsExistingLogin(RegisterDto registerDtos)
        {
            if (registerDtos == null)
            {
                throw new ArgumentNullException(nameof(registerDtos), "RegisterDto cannot be null");
            }

            var existingLogins = await _loginRepository.GetAllAsync(CancellationToken.None);

            return existingLogins.Any(l => l.UserName == registerDtos.UserName && l.Password == registerDtos.Password);
        }
    }
}
