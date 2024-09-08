using RailwayTransaction.Domain.Entities.Dtos.Response;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class ScheduleMapper
    {
        //public int ScheduleID { get; set; }
        //public int TrainNo { get; set; }
        //public int StartStationID { get; set; }
        //public int EndStationID { get; set; }
        //public TimeSpan DepartureTime { get; set; }
        //public TimeSpan ArrivalTime { get; set; }
        //public string DayOfWeek { get; set; }

        //// Navigation property
        //public Train Train { get; set; }
        //public ICollection<Reservation> Reservations { get; set; }

        public static ScheduleResponse ConvertToResponse(Schedule schedule)
        {
            return new ScheduleResponse
            {
                ScheduleID = schedule.ScheduleID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek
            };
        }
        public static Schedule ConvertToResponseAll(Schedule schedule,
                                                    Train train,
                                                    List<Reservation> reservations)
        {
            return new Schedule
            {
                ScheduleID = schedule.ScheduleID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek,

                Train = train,
                Reservations    = reservations
            };
        }
    }
}
