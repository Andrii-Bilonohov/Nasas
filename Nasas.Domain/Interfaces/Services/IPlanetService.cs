using Nasas.Domain.Models;

namespace Nasas.Domain.Interfaces.Services;

public interface IPlanetService
{
    Task<Planet> AddPlanetAsync(Planet planet, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> GetAllPlanetAsync( CancellationToken cancellationToken);

    Task<Planet> EditPlanetAsync(Planet planet, CancellationToken cancellationToken);

    Task<bool> DeletePlanetAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> SearchPlanetAsync(string name, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> PlanetFilter(string property, CancellationToken cancellationToken);

}
