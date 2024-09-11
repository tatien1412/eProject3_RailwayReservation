namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class ScheduleResponse
    {
        public int TrainID { get; set; }
        public int TrainRouteID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }

    }
}
