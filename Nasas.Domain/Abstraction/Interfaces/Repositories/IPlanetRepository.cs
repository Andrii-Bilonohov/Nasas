using Nasas.Domain.Models;

namespace Nasas.Domain.Abstraction.Interfaces.Repositories;

    public interface IPlanetRepository
    {
        Task<IEnumerable<Planet>> GetAllAsync(CancellationToken cancellationToken);

        Task<Planet> AddAsync(Planet planet, CancellationToken cancellationToken);

        Task<Planet> UpdateAsync(Planet planet, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<Planet>> SearchAsync(Planet planet, CancellationToken cancellationToken);

        Task<IEnumerable<Planet>> FilterAsync(Planet planet, CancellationToken cancellationToken);
    }
