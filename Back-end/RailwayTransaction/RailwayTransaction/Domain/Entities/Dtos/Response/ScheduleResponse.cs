namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class ScheduleResponse
    {
        public int ScheduleID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }

    }
}
