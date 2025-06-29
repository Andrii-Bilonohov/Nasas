using Nasas.Domain.Abstraction.Models;
using Nasas.Domain.Models;
using Nasas.Domain.Dtos.Input;

namespace Nasas.Domain.Abstraction.Interfaces.Services;

public interface IPlanetService
{
    Task<Planet> AddPlanetAsync(CreatePlanetDto planet, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> GetAllPlanetAsync( CancellationToken cancellationToken);

    Task<Planet> EditPlanetAsync(EditPlanetDto planet, CancellationToken cancellationToken);

    Task<bool> DeletePlanetAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> SearchPlanetAsync(string name, CancellationToken cancellationToken);

    Task<IEnumerable<Planet>> PlanetFilter(PlanetFilter property, CancellationToken cancellationToken);

}
