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


        public async Task<bool> LoginAsync(LoginDto loginDtos, CancellationToken cancellationToken)
        {

            if (loginDtos == null)
            {
                throw new ArgumentNullException(nameof(loginDtos), "LoginDto cannot be null");
            }

            var logins = await _loginRepository.GetAllAsync(cancellationToken);

            var login = logins.FirstOrDefault(l => l.UserName == loginDtos.UserName && l.Password == loginDtos.Password);

            if (login != null)
            {

                return true;
            }


            return false; 
        }


        public async Task<bool> RegisterAsync(RegisterDto registerDtos, CancellationToken cancellationToken)
        {
            if (registerDtos == null)
            {
                throw new ArgumentNullException(nameof(registerDtos), "RegisterDto cannot be null");
            }

            var existingLogins = await _loginRepository.GetAllAsync(cancellationToken);

            if (existingLogins.Any(l => l.UserName == registerDtos.UserName))
            {
                return false; 
            }

            var newLogin = new Login
            {
                UserName = registerDtos.UserName,
                Password = registerDtos.Password,
                Email = registerDtos.Email
            };

            await _loginRepository.AddAsync(newLogin, cancellationToken);

            return true;
        }
    }
}
