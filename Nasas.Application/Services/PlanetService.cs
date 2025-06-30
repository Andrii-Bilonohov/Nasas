using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Models;

namespace Nasas.Application.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;


        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }


        public async Task<Planet> AddPlanetAsync(CreatePlanetDto planet, CancellationToken cancellationToken)
        {
            if (planet == null)
            {
                throw new ArgumentNullException(nameof(planet), "CreatePlanetDto cannot be null");
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

            return await _planetRepository.AddAsync(newPlanet, cancellationToken);
        }


        public async Task<bool> DeletePlanetAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Planet ID must be greater than zero");
            }

            return await _planetRepository.DeleteAsync(id, cancellationToken);
        }


        public async Task<Planet> EditPlanetAsync(EditPlanetDto planet, CancellationToken cancellationToken)
        {
            if (planet == null)
            {
                throw new ArgumentNullException(nameof(planet), "EditPlanetDto cannot be null");
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
                Status = planet.Status
            };

            return await _planetRepository.UpdateAsync(existingPlanet, cancellationToken);
        }


        public async Task<IEnumerable<Planet>> GetAllPlanetAsync(CancellationToken cancellationToken)
        {
            return await _planetRepository.GetAllAsync(cancellationToken);
        }


        public async Task<IEnumerable<Planet>> PlanetFilter(PlanetFilter property, CancellationToken cancellationToken)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property), "PlanetFilter cannot be null");
            }

            var planets = await _planetRepository.GetAllAsync(cancellationToken);

            if (!string.IsNullOrEmpty(property.Name))
            {
                planets = planets.Where(p => p.Name.Contains(property.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (property.Radius.HasValue)
            {
                planets = planets.Where(p => p.Radius == property.Radius.Value);
            }

            return planets;
        }

        public async Task<IEnumerable<Planet>> SearchPlanetAsync(string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Planet name cannot be null or empty", nameof(name));
            }

            var planets = await _planetRepository.GetAllAsync(cancellationToken);

            return planets.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
