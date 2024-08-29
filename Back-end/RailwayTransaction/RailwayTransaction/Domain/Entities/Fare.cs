namespace RailwayTransaction.Domain.Entities
{
    public class Fare
    {
        public int FareID { get; set; }
        public int ReservationID { get; set; }
        public int Distance { get; set; }
        public string CompartmentType { get; set; }
        public string TrainType { get; set; }
        public decimal Amount { get; set; }

        // Navigation property
        public Reservation Reservation { get; set; }
    }
}
