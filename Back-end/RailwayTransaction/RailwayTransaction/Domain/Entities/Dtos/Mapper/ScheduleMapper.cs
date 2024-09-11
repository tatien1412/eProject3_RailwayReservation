using RailwayTransaction.Domain.Entities.Dtos.Response;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class ScheduleMapper
    {
        public static ScheduleResponse ConvertToResponse(Schedule schedule)
        {
            return new ScheduleResponse
            {
                TrainID = schedule.TrainID,
                TrainRouteID = schedule.TrainRouteID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek,
            };
        }
        //public static Schedule ConvertToResponseAll(Schedule schedule,
        //                                            Train train,
        //                                            List<Reservation> reservations)
        //{
        //    return new Schedule
        //    {
        //        ScheduleID = schedule.ScheduleID,
        //        DepartureTime = schedule.DepartureTime,
        //        ArrivalTime = schedule.ArrivalTime,
        //        DayOfWeek = schedule.DayOfWeek,

        //        Train = train,
        //        Reservations    = reservations
        //    };
        //}
    }
}
