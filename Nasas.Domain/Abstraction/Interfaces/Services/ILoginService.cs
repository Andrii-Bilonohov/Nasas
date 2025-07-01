using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;
using Nasas.Domain.Models;

namespace Nasas.Domain.Abstraction.Interfaces.Services;

    public interface ILoginService
    {
        Task<Login> RegisterAsync(RegisterDto registerDtos, CancellationToken cancellationToken);
        Task<Login> LoginAsync(LoginDto loginDtos, CancellationToken cancellationToken);
    }

