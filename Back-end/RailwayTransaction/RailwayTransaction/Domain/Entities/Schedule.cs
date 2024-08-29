using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int TrainNo { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }

        // Navigation property
        public Train Train { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
