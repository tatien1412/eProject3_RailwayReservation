using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Inject TrainService thông qua Dependency Injection
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // API để lấy danh sách chuyến tàu dựa trên fromStationId, toStationId và dateOfTravel
        [HttpGet("GetTrains/{FromStationId}/{ToStationId}/{DateOfTravel}/{TotalPassenger}")]
        public async Task<IActionResult> GetTrains(int FromStationId, int ToStationId,string DateOfTravel,int TotalPassenger)
        {
            var query = new SearchTrainQuery(FromStationId, ToStationId,DateOfTravel,TotalPassenger);
            var trains = await _mediator.Send(query);

            if (trains == null || trains.Count == 0)
            {
                return NotFound("No trains found");
            }

            return Ok(trains);
        }
    }
}
