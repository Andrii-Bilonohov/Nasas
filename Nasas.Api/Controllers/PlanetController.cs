using Microsoft.AspNetCore.Mvc;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;
using Nasas.Domain.Models;

namespace Nasas.Api.Controllers
{
    [ApiController]
    [Route("api/planets")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;


        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }


        [HttpGet]
        public async Task<IActionResult> GetPlanets(CancellationToken cancellationToken)
        {
            try
            {
                var planets = await _planetService.GetAllPlanetAsync(cancellationToken);
                return Ok(planets);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchPlanets([FromQuery] string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Search criteria is required");

            try
            {
                var planets = await _planetService.SearchPlanetAsync(name, cancellationToken);
                return Ok(planets);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("filter")]
        public async Task<IActionResult> FilterPlanets([FromQuery] PlanetFilter filterPlanet, CancellationToken cancellationToken)
        {
            try
            {
                var planets = await _planetService.PlanetFilterAsync(filterPlanet, cancellationToken);
                return Ok(planets);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPlanet([FromBody] CreatePlanetDto planetDto, CancellationToken cancellationToken)
        {
            if (planetDto == null)
                return BadRequest("Planet data is required");

            try
            {
                var addedPlanet = await _planetService.AddPlanetAsync(planetDto, cancellationToken);
                return CreatedAtAction(nameof(GetPlanets), new { id = addedPlanet.Id }, addedPlanet);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePlanet([FromRoute] int id, [FromBody] EditPlanetDto planetDto, CancellationToken cancellationToken)
        {
            if (planetDto == null)
                return BadRequest("Valid planet data is required");

            try
            {
                var updatedPlanet = await _planetService.EditPlanetAsync(planetDto, cancellationToken);
                return Ok(updatedPlanet);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanet([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return BadRequest("Valid planet ID is required");

            try
            {
                var deleted = await _planetService.DeletePlanetAsync(id, cancellationToken);
                if (!deleted)
                    return NotFound("Planet not found");

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
