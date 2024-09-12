using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class TripResponse_joined
    {
        public int TripID { get; set; }
        public int ReservationID { get; set; }
        public int ScheduleID { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan TravelTime { get; set; }

        public ReservationResponse Reservation { get; set; }
        public ScheduleResponse Schedule { get; set; }
        public StationResponse StartStation { get; set; }
        public StationResponse EndStation { get; set; }
        public ICollection<ReservationResponse> Reservations { get; set; }

    }
}