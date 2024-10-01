using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Trip;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
  //  [Authorize(Roles = "Master Manager, Transaction Staff")]
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all Trips
        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
        {
            var query = new GetAllTripsQuery();
            var trips = await _mediator.Send(query);

            if (trips == null || trips.Count == 0)
            {
                return NotFound("No Trips found");
            }

            return Ok(trips);
        }

        // Query: Get Trip by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(int id)
        {
            var query = new GetTripByIdQuery(id);
            var trip = await _mediator.Send(query);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // Command: Create a new Trip
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] CreateTripCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTripById), new { id = tripId }, tripId);
        }

        // Command: Update an existing Trip
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, [FromBody] UpdateTripCommand command)
        {
            if (id != command.TripID)
            {
                return BadRequest("Trip ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a Trip
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            await _mediator.Send(new DeleteTripCommand { TripID = id });
            return NoContent();
        }
    }
}
