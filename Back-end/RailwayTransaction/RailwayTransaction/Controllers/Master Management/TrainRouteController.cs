using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.TrainRoute;
using RailwayTransaction.Application.Commands.MasterManagement.TrainRoute;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
    [Authorize(Roles = "Master Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class TrainRouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainRouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all TrainRoutes
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllTrainRoutes()
        {
            var query = new GetAllTrainRoutesQuery();
            var trainRoutes = await _mediator.Send(query);

            if (trainRoutes == null || trainRoutes.Count == 0)
            {
                return NotFound("No TrainRoutes found");
            }

            return Ok(trainRoutes);
        }

        // Query: Get TrainRoute by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainRouteById(int id)
        {
            var query = new GetTrainRouteByIdQuery(id);
            var trainRoute = await _mediator.Send(query);

            if (trainRoute == null)
            {
                return NotFound();
            }

            return Ok(trainRoute);
        }

        // Command: Create a new TrainRoute
        [HttpPost]
        public async Task<IActionResult> CreateTrainRoute([FromBody] CreateTrainRouteCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainRouteId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTrainRouteById), new { id = trainRouteId }, trainRouteId);
        }

        // Command: Update an existing TrainRoute
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainRoute(int id, [FromBody] UpdateTrainRouteCommand command)
        {
            if (id != command.TrainRouteID)
            {
                return BadRequest("TrainRoute ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a TrainRoute
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainRoute(int id)
        {
            await _mediator.Send(new DeleteTrainRouteCommand { TrainRouteID = id });
            return NoContent();
        }
    }
}
