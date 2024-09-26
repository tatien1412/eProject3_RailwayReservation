using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Reservation;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
    [Authorize(Roles = "Master Manager, Transaction Staff")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all Reservation
        [HttpGet]
        public async Task<IActionResult> GetAllReservation()
        {
            var query = new GetAllReservationsQuery();
            var reservation = await _mediator.Send(query);

            if (reservation == null || reservation.Count == 0)
            {
                return NotFound("No Reservation found");
            }

            return Ok(reservation);
        }

        // Query: Get Reservation by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var query = new GetReservationByIdQuery(id);
            var reservation = await _mediator.Send(query);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // Command: Create a new Reservation
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReservationById), new { id = reservationId }, reservationId);
        }

        // Command: Update an existing Reservation
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] UpdateReservationCommand command)
        {
            if (id != command.ReservationID)
            {
                return BadRequest("Reservation ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a Reservation
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _mediator.Send(new DeleteReservationCommand { ReservationID = id });
            return NoContent();
        }
    }
}
