using static System.Collections.Specialized.BitVector32;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int PnrNo { get; set; }
        public int UserID { get; set; }
        public int TrainNo { get; set; }
        public int ScheduleID { get; set; }
        public int FromStationID { get; set; }
        public int ToStationID { get; set; }
        public string SeatNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public string CoachNo { get; set; }
        public decimal Fare { get; set; }
        public string CancellationStatus { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Train Train { get; set; }
        public Station FromStation { get; set; }
        public Station ToStation { get; set; }
        public Schedule Schedule { get; set; }
        public Fare FareDetails { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
