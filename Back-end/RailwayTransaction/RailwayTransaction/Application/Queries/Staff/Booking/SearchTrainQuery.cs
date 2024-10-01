using MediatR;

namespace RailwayTransaction.Application.Queries.Staff.Booking
{
    public class SearchTrainQuery : IRequest<List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>>
    {
        public int FromStationId { get; set; }
        public int ToStationId { get; set; }
        public string DateOfTravel { get; set; }
        public int TotalPassenger {  get; set; }
        public SearchTrainQuery(int fromStationId, int toStationId, string dateOfTravel, int totalPassenger)
        {
            FromStationId = fromStationId; ToStationId = toStationId;
            DateOfTravel = dateOfTravel;
            TotalPassenger = totalPassenger;
        }
    }
}
