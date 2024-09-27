using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.RouteStation;
using RailwayTransaction.Application.Commands.MasterManagement.RouteStation;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
   // [Authorize(Roles = "Master Manager, Transaction Staff")]
    [ApiController]
    [Route("api/[controller]")]
    public class RouteStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteStationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all RouteStations
        [HttpGet]
        public async Task<IActionResult> GetAllRouteStations()
        {
            var query = new GetAllRouteStationsQuery();
            var routeStations = await _mediator.Send(query);

            if (routeStations == null || routeStations.Count == 0)
            {
                return NotFound("No RouteStations found");
            }

            return Ok(routeStations);
        }

        // Query: Get RouteStation by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteStationById(int id)
        {
            var query = new GetRouteStationByIdQuery(id);
            var routeStation = await _mediator.Send(query);

            if (routeStation == null)
            {
                return NotFound();
            }

            return Ok(routeStation);
        }

        // Command: Create a new RouteStation
        [HttpPost]
        public async Task<IActionResult> CreateRouteStation([FromBody] CreateRouteStationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var routeStationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRouteStationById), new { id = routeStationId }, routeStationId);
        }

        // Command: Update an existing RouteStation
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRouteStation(int id, [FromBody] UpdateRouteStationCommand command)
        {
            if (id != command.RouteStationID)
            {
                return BadRequest("RouteStation ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a RouteStation
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteStation(int id)
        {
            await _mediator.Send(new DeleteRouteStationCommand { RouteStationID = id });
            return NoContent();
        }
    }
}
