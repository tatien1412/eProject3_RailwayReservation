using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.Schedule;
using RailwayTransaction.Application.Commands.MasterManagement.Schedule;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
    [Authorize(Roles = "Master Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all schedules
        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var query = new GetAllSchedulesQuery();
            var schedules = await _mediator.Send(query);

            if (schedules == null || schedules.Count == 0)
            {
                return NotFound("No schedules found");
            }

            return Ok(schedules);
        }

        // Query: Get schedule by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var query = new GetScheduleByIdQuery(id);
            var schedule = await _mediator.Send(query);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // Command: Create a new schedule
        [HttpPost("create")]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scheduleId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetScheduleById), new { id = scheduleId }, scheduleId);
        }

        // Command: Update an existing schedule
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] UpdateScheduleCommand command)
        {
            if (id != command.ScheduleID)
            {
                return BadRequest("Schedule ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a schedule
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _mediator.Send(new DeleteScheduleCommand { ScheduleID = id });
            return NoContent();
        }
    }
}
