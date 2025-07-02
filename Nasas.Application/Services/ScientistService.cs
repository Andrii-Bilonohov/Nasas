using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;
using Nasas.Domain.Models;

namespace Nasas.Application.Services
{
    public class ScientistService : IScientistService
    {
        private readonly IScientistRepository _scientistRepository;


        public ScientistService(IScientistRepository scientistRepository)
        {
            _scientistRepository = scientistRepository ?? throw new ArgumentNullException(nameof(scientistRepository));
        }


        public Task<Scientist> AddScientistAsync(ScientistDto scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
            {
                throw new ArgumentNullException(nameof(scientist));
            }

            var newScientist = new Scientist
            { 
              FirstName = scientist.FirstName, 
              LastName = scientist.LastName 
            };

            return _scientistRepository.AddAsync(newScientist, cancellationToken);
        }


        public Task<bool> DeleteScientistAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            return _scientistRepository.DeleteAsync(id, cancellationToken);
        }


        public Task<Scientist> EditScientistAsync(ScientistDto scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
            {
                throw new ArgumentNullException(nameof(scientist));
            }

            var updatedScientist = new Scientist
            { 
              FirstName = scientist.FirstName, 
              LastName = scientist.LastName 
            };

            return _scientistRepository.UpdateAsync(updatedScientist, cancellationToken);
        }


        public Task<IEnumerable<Scientist>> GetAllScientistAsync(CancellationToken cancellationToken)
        {
            return _scientistRepository.GetAllAsync(cancellationToken);
        }


        public Task<Scientist> GetScientistAsync(ScientistOutput scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
            {
                throw new ArgumentNullException(nameof(scientist));
            }

            var scientistModel = new Scientist
            {
                FirstName = scientist.FirstName,
                LastName = scientist.LastName
            };

            return _scientistRepository.GetScientistAsync(scientistModel, cancellationToken);
        }
    }
}
