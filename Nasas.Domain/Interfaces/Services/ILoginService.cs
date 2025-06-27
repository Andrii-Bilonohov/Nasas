using Nasas.Domain.Models;

namespace Nasas.Domain.Interfaces.Services;

    public interface ILoginService
    {
        Task<bool> RegisterAsync(string userName, string email, string password, CancellationToken cancellationToken);
        Task<bool> LoginAsync(string userName, string password, CancellationToken cancellationToken);
    }

