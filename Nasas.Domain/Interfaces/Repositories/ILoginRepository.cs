using Nasas.Domain.Models;

namespace Nasas.Domain.Interfaces.Repositories;

    public interface ILoginRepository
    {
        Task<IEnumerable<Login>> GetAllAsync();

        Task<Login> AddAsync(Login login, CancellationToken cancellationToken);

        Task<Login> UpdateAsync(Login login, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}

