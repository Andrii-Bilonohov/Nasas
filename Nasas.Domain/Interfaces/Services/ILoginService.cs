using Nasas.Domain.Dtos;
using Nasas.Domain.Models;

namespace Nasas.Domain.Interfaces.Services;

    public interface ILoginService
    {
        Task<bool> RegisterAsync(RegisterDtos registerDtos, CancellationToken cancellationToken);
        Task<bool> LoginAsync(LoginDtos loginDtos, CancellationToken cancellationToken);
    }

