using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Station;
using RailwayTransaction.Application.Commands.MasterManagement.Station;

namespace RailwayTransaction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all stations
        [HttpGet]
        public async Task<IActionResult> GetAllStations()
        {
            var query = new GetAllStationsQuery();
            var stations = await _mediator.Send(query);

            if (stations == null || stations.Count == 0)
            {
                return NotFound("No stations found");
            }

            return Ok(stations);
        }

        // Query: Get station by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStationById(int id)
        {
            var query = new GetStationByIdQuery(id);
            var station = await _mediator.Send(query);

            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        // Command: Create a new station
        [HttpPost]
        public async Task<IActionResult> CreateStation([FromBody] CreateStationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStationById), new { id = stationId }, stationId);
        }

        // Command: Update an existing station
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(int id, [FromBody] UpdateStationCommand command)
        {
            if (id != command.StationID)
            {
                return BadRequest("Station ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a station
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(int id)
        {
            await _mediator.Send(new DeleteStationCommand { StationID = id });
            return NoContent();
        }
    }
}
