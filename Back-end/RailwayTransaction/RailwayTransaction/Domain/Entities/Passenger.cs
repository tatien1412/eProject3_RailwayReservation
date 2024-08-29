namespace RailwayTransaction.Domain.Entities
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string SeatNo { get; set; }
        public string CoachNo { get; set; }

        // Foreign key
        public int PnrNo { get; set; }
        public Ticket Ticket { get; set; }
    }
}
