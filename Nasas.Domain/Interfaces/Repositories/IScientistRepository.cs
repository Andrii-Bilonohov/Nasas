using Nasas.Domain.Models;

namespace Nasas.Domain.Interfaces.Repositories;

    public interface IScientistRepository
    {
        Task<IEnumerable<Scientist>> GetAllAsync();

        Task<Scientist> AddAsync(Scientist scientist, CancellationToken cancellationToken);

        Task<Scientist> UpdateAsync(Scientist scientist, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);

    }

