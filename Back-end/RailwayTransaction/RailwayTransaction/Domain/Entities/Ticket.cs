using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int PnrNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int TotalPassengers { get; set; }

        // Navigation property
        public ICollection<Passenger> Passengers { get; set; }
        public Reservation Reservation { get; set; }
    }
}
