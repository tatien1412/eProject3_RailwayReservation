using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Commands.Staff;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Handler.Staff;

namespace RailwayTransaction.Controllers.Staff
{
    //[Authorize(Roles = "Master Manager, Transaction Staff")]
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
        public async Task<IActionResult> GetTrains(int FromStationId, int ToStationId, string DateOfTravel, int TotalPassenger)
        {
            var query = new SearchTrainQuery(FromStationId, ToStationId, DateOfTravel, TotalPassenger);
            var trains = await _mediator.Send(query);

            if (trains == null || trains.Count == 0)
            {
                return NotFound("No trains found");
            }

            return Ok(trains);
        }
        [HttpGet("AvailableSeat/{TrainId}")]
        public async Task<IActionResult> Getseats(int TrainId)
        {
            var query = new AvailabelseatQuery(TrainId);
            var total = await _mediator.Send(query);

            // Kiểm tra nếu `total` là null hoặc là danh sách rỗng
            if (total == null)
            {
                return NotFound("No trains found");
            }

            return Ok(total);
        }
        [HttpPut("UpdateConfirmTicket/{TrainID}/{CompartmentType}/{TotalConfirmTicket}")]
        public async Task<IActionResult> UpdateSeatStatus(int TrainID, string CompartmentType, int TotalConfirmTicket)
        {
            var query = new UpdateSeatStatusQuery(TrainID, CompartmentType, TotalConfirmTicket);
            await _mediator.Send(query);
            return NoContent();

        }
        [HttpPut("UpdateTicketInQuery/{TrainID}/{CompartmentType}/{TotalConfirmTicket}")]
        public async Task<IActionResult> UpdateSeatQueryStatus(int TrainID, string CompartmentType, int TotalConfirmTicket)
        {
            var query = new UpdateSeatQueueStatusQuery(TrainID, CompartmentType, TotalConfirmTicket);
            await _mediator.Send(query);
            return NoContent();

        }
        [HttpGet("DailyCash/{DateOfTravel}")]
        public async Task<IActionResult> DailyCash(string DateOfTravel)
        {
            var query = new DailyCashQuery(DateOfTravel);
            var total  = await _mediator.Send(query);
            return Ok(total);
        }
    }
}
