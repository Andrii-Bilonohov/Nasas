using Microsoft.AspNetCore.Mvc;
using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Dtos.Output;
using Nasas.Domain.Models;

namespace Nasas.Api.Controllers
{
    [ApiController]
    [Route("/api/planet")]
    public class PlanetControler : ControllerBase
    {
        private readonly IPlanetRepository _planetRepository;


        public PlanetControler(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository ?? throw new ArgumentNullException(nameof(planetRepository));
        }


        [HttpGet]
        public async Task<IActionResult> GetPlanets(CancellationToken cancellationToken)
        {
            try
            {
                var planets = await _planetRepository.GetAllAsync(cancellationToken);
                return Ok(planets);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchPlanets(SearchPlanetDto searchPlanet, CancellationToken cancellationToken)
        {
            if (searchPlanet == null)
            {
                return BadRequest("Search criteria is required");
            }

            try
            {
                var planets = await _planetRepository.SearchAsync(searchPlanet, cancellationToken);
                return Ok(planets);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("filter")]
        public async Task<IActionResult> FilterPlanets(PlanetFilter filterPlanet, CancellationToken cancellationToken)
        {
            if (filterPlanet == null)
            {
                return BadRequest("Filter criteria is required");
            }

            try
            {
                var planets = await _planetRepository.FilterAsync(filterPlanet, cancellationToken);
                return Ok(planets);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPlanet(CreatePlanetDto planetDto, CancellationToken cancellationToken)
        {
            if (planetDto == null)
            {
                return BadRequest("Planet data is required");
            }

            var planet = new Planet
            {
                Name = planetDto.Name,
                Radius = planetDto.Radius,
                Mass = planetDto.Mass,
                Age = planetDto.Age,
                Image = planetDto.Image,
                Type = planetDto.Type,
                Orbit = planetDto.Orbit,
                Composition = planetDto.Composition,
                Status = planetDto.Status,
            };

            try
            {
                var addedPlanet = await _planetRepository.AddAsync(planet, cancellationToken);
                return CreatedAtAction(nameof(GetPlanets), new { id = addedPlanet.Id }, addedPlanet);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutPlanet(EditPlanetDto planetDto, CancellationToken cancellationToken)
        {
            if (planetDto == null)
            {
                return BadRequest("Valid planet data is required");
            }

            var planet = new Planet
            {
                Name = planetDto.Name,
                Radius = planetDto.Radius,
                Mass = planetDto.Mass,
                Age = planetDto.Age,
                Image = planetDto.Image,
                Type = planetDto.Type,
                Orbit = planetDto.Orbit,
                Composition = planetDto.Composition,
                Status = planetDto.Status,
            };

            try
            {
                var updatedPlanet = await _planetRepository.UpdateAsync(planet, cancellationToken);
                return Ok(updatedPlanet);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePlanet(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return BadRequest("Valid planet ID is required");
            }
            try
            {
                var deleted = await _planetRepository.DeleteAsync(id, cancellationToken);
                if (!deleted)
                {
                    return NotFound("Planet not found");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
