using Microsoft.AspNetCore.Mvc;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Domain.Dtos.Input;

namespace Nasas.Api.Controllers
{
    [ApiController]
    [Route("api/scientist")]
    public class ScientistController : ControllerBase
    {
        private readonly IScientistService _scientistService;


        public ScientistController(IScientistService scientistService)
        {
            _scientistService = scientistService;
        }


        [HttpGet]
        public async Task<IActionResult> GetScientist(CancellationToken cancellationToken)
        {
            try
            {
                var scientists = await _scientistService.GetAllScientistAsync(cancellationToken);
                return Ok(scientists);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateScientist([FromBody] ScientistDto scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
                return BadRequest("Scientist data is required");
            try
            {
                var createdScientist = await _scientistService.AddScientistAsync(scientist, cancellationToken);
                return CreatedAtAction(nameof(GetScientist), new { id = createdScientist.Id }, createdScientist);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateScientist([FromBody] ScientistDto scientist, CancellationToken cancellationToken)
        {
            if (scientist == null)
            {
                return BadRequest("Scientist data is required");
            }

            try
            {
                var updatedScientist = await _scientistService.EditScientistAsync(scientist, cancellationToken);
                return Ok(updatedScientist);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScientist([FromRoute] int id, CancellationToken cancellationToken)
        {
            try
            {
                var isDeleted = await _scientistService.DeleteScientistAsync(id, cancellationToken);
                if (isDeleted)
                {
                    return NoContent();
                }
                return NotFound("Scientist not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
