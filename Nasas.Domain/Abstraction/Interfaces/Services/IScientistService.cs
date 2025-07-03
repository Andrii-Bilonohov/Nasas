using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;
using Nasas.Domain.Models;

namespace Nasas.Domain.Abstraction.Interfaces.Services;

public interface IScientistService
{
    Task<Scientist> AddScientistAsync(ScientistDto scientist, CancellationToken cancellationToken);

    Task<IEnumerable<Scientist>> GetAllScientistAsync(CancellationToken cancellationToken);

    Task<Scientist> GetScientistAsync(ScientistOutput scientist, CancellationToken cancellationToken);

    Task<Scientist> EditScientistAsync(ScientistDto scientist, CancellationToken cancellationToken);

    Task<bool> DeleteScientistAsync(int id, CancellationToken cancellationToken);
}

