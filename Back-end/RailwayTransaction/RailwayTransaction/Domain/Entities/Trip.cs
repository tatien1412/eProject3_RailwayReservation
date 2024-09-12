using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleID { get; set; }
        public Schedule Schedule { get; set; }

        [ForeignKey("StartStation")]
        public int StartStationID { get; set; }
        public Station StartStation { get; set; }

        [ForeignKey("EndStation")]
        public int EndStationID { get; set; }
        public Station EndStation { get; set; }

        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan TravelTime { get; set; } // Thời gian di chuyển dự kiến

    }
}
