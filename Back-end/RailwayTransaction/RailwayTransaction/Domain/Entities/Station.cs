namespace RailwayTransaction.Domain.Entities
{
    public class Station
    {
        public int StationID { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string RailwayDivisionName { get; set; }

        // Navigation properties
        public ICollection<Reservation> FromReservations { get; set; }
        public ICollection<Reservation> ToReservations { get; set; }
    }
}
