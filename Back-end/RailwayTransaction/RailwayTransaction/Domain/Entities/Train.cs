namespace RailwayTransaction.Domain.Entities
{
    public class Train
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }
        public string Route { get; set; }
        public int NumberOfCompartments { get; set; }

        // Navigation properties
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
s