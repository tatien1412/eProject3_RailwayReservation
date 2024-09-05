using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Train;
using RailwayTransaction.Application.Commands.MasterManagement.Train;

namespace RailwayTransaction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all trains
        [HttpGet]
        public async Task<IActionResult> GetAllTrains()
        {
            var query = new GetAllTrainsQuery();
            var trains = await _mediator.Send(query);

            if (trains == null || trains.Count == 0)
            {
                return NotFound("No trains found");
            }

            return Ok(trains);
        }

        // Query: Get train by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById(int id)
        {
            var query = new GetTrainByIdQuery(id);
            var train = await _mediator.Send(query);

            if (train == null)
            {
                return NotFound();
            }

            return Ok(train);
        }

        // Command: Create a new train
        [HttpPost]
        public async Task<IActionResult> CreateTrain([FromBody] CreateTrainCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTrainById), new { id = trainId }, trainId);
        }

        // Command: Update an existing train
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrain(int id, [FromBody] UpdateTrainCommand command)
        {
            if (id != command.TrainID)
            {
                return BadRequest("Train ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a train
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            await _mediator.Send(new DeleteTrainCommand { TrainID = id });
            return NoContent();
        }
    }
}
