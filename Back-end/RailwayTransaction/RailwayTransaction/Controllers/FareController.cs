using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Fare;
using RailwayTransaction.Application.Commands.MasterManagement.Fare;

namespace RailwayTransaction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FareController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all fares
        [HttpGet]
        public async Task<IActionResult> GetAllFares()
        {
            var query = new GetAllFaresQuery();
            var fares = await _mediator.Send(query);

            if (fares == null || fares.Count == 0)
            {
                return NotFound("No fares found");
            }

            return Ok(fares);
        }

        // Query: Get fare by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFareById(int id)
        {
            var query = new GetFareByIdQuery(id);
            var fare = await _mediator.Send(query);

            if (fare == null)
            {
                return NotFound();
            }

            return Ok(fare);
        }

        // Command: Create a new fare
        [HttpPost]
        public async Task<IActionResult> CreateTrain([FromBody] CreateFareCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fareId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFareById), new { id = fareId }, fareId);
        }

        // Command: Update an existing fare
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrain(int id, [FromBody] UpdateFareCommand command)
        {
            if (id != command.FareID)
            {
                return BadRequest("Fare ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a fare
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            await _mediator.Send(new DeleteFareCommand { FareID = id });
            return NoContent();
        }
    }
}
