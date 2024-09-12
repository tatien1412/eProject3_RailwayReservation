using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class TripResponse
    {
        public int TripID { get; set; }
        public int ReservationID { get; set; }
        public int ScheduleID { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan TravelTime { get; set; }

    }
}