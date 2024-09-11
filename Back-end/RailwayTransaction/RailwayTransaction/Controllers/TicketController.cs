using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Ticket;
using RailwayTransaction.Application.Commands.MasterManagement.Ticket;

namespace RailwayTransaction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all Tickets
        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var query = new GetAllTicketsQuery();
            var tickets = await _mediator.Send(query);

            if (tickets == null || tickets.Count == 0)
            {
                return NotFound("No Tickets found");
            }

            return Ok(tickets);
        }

        // Query: Get Ticket by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var query = new GetTicketByIdQuery(id);
            var ticket = await _mediator.Send(query);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // Command: Create a new Ticket
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticketId }, ticketId);
        }

        // Command: Update an existing Ticket
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] UpdateTicketCommand command)
        {
            if (id != command.PnrNo)
            {
                return BadRequest("Ticket ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a Ticket
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _mediator.Send(new DeleteTicketCommand { PnrNo = id });
            return NoContent();
        }
    }
}
