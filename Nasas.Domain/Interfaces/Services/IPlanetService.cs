using Nasas.Domain.Models;

namespace Nasas.Domain.Interfaces.Services;

public interface IPlanetService
{
    Task<Planet> AddPlanetAsync(Planet planet, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> GetAllPlanetAsync(Planet planet, CancellationToken cancellationToken);

    Task<Planet> EditPlanetAsync(Planet planet, CancellationToken cancellationToken);

    Task<bool> DeletePlanetAsync(int id, CancellationToken cancellationToken);

    Task<Planet> SearchPlanetAsync(string name, CancellationToken cancellationToken);


    Task<IEnumerable<Planet>> FilterByName(string name, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> FilterByRadius(double radius, CancellationToken cancellationToken);
}
