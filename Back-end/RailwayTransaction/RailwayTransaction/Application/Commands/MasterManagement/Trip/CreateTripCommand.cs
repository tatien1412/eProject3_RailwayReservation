using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Trip
{
    public class CreateTripCommand : IRequest<int>
    {
        public int ReservationID { get; set; }
        public int ScheduleID { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan TravelTime { get; set; } // Thời gian di chuyển dự kiến
    }
}
