using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Seat;
using RailwayTransaction.Application.Commands.MasterManagement.Seat;

namespace RailwayTransaction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all Seats
        [HttpGet]
        public async Task<IActionResult> GetAllSeats()
        {
            var query = new GetAllSeatsQuery();
            var seats = await _mediator.Send(query);

            if (seats == null || seats.Count == 0)
            {
                return NotFound("No Seats found");
            }

            return Ok(seats);
        }

        // Query: Get Seat by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(int id)
        {
            var query = new GetSeatByIdQuery(id);
            var seat = await _mediator.Send(query);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        // Command: Create a new Seat
        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] CreateSeatCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seatId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSeatById), new { id = seatId }, seatId);
        }

        // Command: Update an existing Seat
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, [FromBody] UpdateSeatCommand command)
        {
            if (id != command.SeatID)
            {
                return BadRequest("Seat ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a Seat
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            await _mediator.Send(new DeleteSeatCommand { SeatID = id });
            return NoContent();
        }
    }
}
