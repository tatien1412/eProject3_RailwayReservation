using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Compartment;
using RailwayTransaction.Application.Commands.MasterManagement.Compartment;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
    [Authorize(Roles = "Master Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class CompartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all Compartments
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCompartments()
        {
            var query = new GetAllCompartmentsQuery();
            var compartments = await _mediator.Send(query);

            if (compartments == null || compartments.Count == 0)
            {
                return NotFound("No Compartments found");
            }

            return Ok(compartments);
        }

        // Query: Get Compartment by ID
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetCompartmentById(int id)
        {
            var query = new GetCompartmentByIdQuery(id);
            var compartment = await _mediator.Send(query);

            if (compartment == null)
            {
                return NotFound();
            }

            return Ok(compartment);
        }

        // Command: Create a new Compartment
        [HttpPost("create")]
        public async Task<IActionResult> CreateCompartment([FromBody] CreateCompartmentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compartmentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCompartmentById), new { id = compartmentId }, compartmentId);
        }

        // Command: Update an existing Compartment
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCompartment(int id, [FromBody] UpdateCompartmentCommand command)
        {
            if (id != command.CompartmentID)
            {
                return BadRequest("Compartment ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a Compartment
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompartment(int id)
        {
            await _mediator.Send(new DeleteCompartmentCommand { CompartmentID = id });
            return NoContent();
        }
    }
}
