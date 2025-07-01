using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;
using Nasas.Domain.Models;

namespace Nasas.Application.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;


        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository ?? throw new ArgumentNullException(nameof(planetRepository));
        }


        public Task<Planet> AddPlanetAsync(CreatePlanetDto planet, CancellationToken cancellationToken)
        {
            if (planet == null)
            {
                throw new ArgumentNullException(nameof(planet));
            }

            var newPlanet = new Planet
            {
                Name = planet.Name,
                Mass = planet.Mass,
                Radius = planet.Radius,
                Age = planet.Age,
                Image = planet.Image,
                Type = planet.Type,
                Orbit = planet.Orbit,
                Composition = planet.Composition,
                Status = planet.Status,
            };

            return _planetRepository.AddAsync(newPlanet, cancellationToken);
        }


        public Task<IEnumerable<Planet>> GetAllPlanetAsync(CancellationToken cancellationToken)
        {
            return _planetRepository.GetAllAsync(cancellationToken);
        }


        public Task<Planet> EditPlanetAsync(EditPlanetDto planet, CancellationToken cancellationToken)
        {
            if (planet == null)
            {
                throw new ArgumentNullException(nameof(planet));
            }

            var existingPlanet = new Planet
            {
                Name = planet.Name,
                Mass = planet.Mass,
                Radius = planet.Radius,
                Age = planet.Age,
                Image = planet.Image,
                Type = planet.Type,
                Orbit = planet.Orbit,
                Composition = planet.Composition,
                Status = planet.Status,
            };

            return _planetRepository.UpdateAsync(existingPlanet, cancellationToken);
        }


        public Task<IEnumerable<Planet>> SearchPlanetAsync(string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Planet name cannot be null or empty.", nameof(name));
            }

            var searchDto = new SearchPlanetDto { Name = name };
            return _planetRepository.SearchAsync(searchDto, cancellationToken);
        }


        public Task<IEnumerable<Planet>> PlanetFilterAsync(PlanetFilter property, CancellationToken cancellationToken)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return _planetRepository.FilterAsync(property, cancellationToken);
        }


        public Task<bool> DeletePlanetAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            return _planetRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
