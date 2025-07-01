using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Models;
namespace Nasas.Application.Services
{
    public class ScientistService : IScientistService
    {
        private readonly IScientistRepository _scientistRepository;


        public ScientistService(IScientistRepository scientistRepository)
        {
            _scientistRepository = scientistRepository;
        }


        public async Task<Scientist> AddScientistAsync(ScientistDto scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
            {
                throw new ArgumentNullException(nameof(scientist), "ScientistDto cannot be null");
            }

            var newScientist = new Scientist
            {
                FirstName = scientist.FirstName,
                LastName = scientist.LastName,
            };

            return await _scientistRepository.AddAsync(newScientist, cancellationToken);
        }


        public async Task<bool> DeleteScientistAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Scientist ID must be greater than zero");
            }

            return await _scientistRepository.DeleteAsync(id, cancellationToken);
        }


        public Task<Scientist> EditScientistAsync(ScientistDto scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
            {
                throw new ArgumentNullException(nameof(scientist), "ScientistDto cannot be null");
            }

            var updatedScientist = new Scientist
            {
                FirstName = scientist.FirstName,
                LastName = scientist.LastName,
            };

            return _scientistRepository.UpdateAsync(updatedScientist, cancellationToken);
         }


        public async Task<IEnumerable<Scientist>> GetAllScientistAsync(CancellationToken cancellationToken)
        {
            return await _scientistRepository.GetAllAsync(cancellationToken);
        }
    }
}
