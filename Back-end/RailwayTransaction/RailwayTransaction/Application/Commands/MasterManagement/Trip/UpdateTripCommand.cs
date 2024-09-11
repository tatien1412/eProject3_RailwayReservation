using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Application.Commands.MasterManagement.Trip
{
    public class UpdateTripCommand : IRequest
    {
        public int TripID { get; set; }
        public int ReservationID { get; set; }
        public int ScheduleID { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan TravelTime { get; set; } // Thời gian di chuyển dự kiến


    }
}
