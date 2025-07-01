using Nasas.Domain.Models;

namespace Nasas.Domain.Abstraction.Interfaces.Repositories;

    public interface ILoginRepository
    {
        Task<IEnumerable<Login>> GetAllAsync(CancellationToken cancellationToken);

        Task<Login> AddAsync(Login login, CancellationToken cancellationToken);

        Task<Login> UpdateAsync(Login login, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);

        Task<Login> GetLoginAsync(string username, string password, CancellationToken cancellationToken);

}

