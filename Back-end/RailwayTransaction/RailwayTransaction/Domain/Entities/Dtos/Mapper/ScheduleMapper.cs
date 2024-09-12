using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class ScheduleMapper
    {
        public static ScheduleResponse ConvertToResponse(Schedule schedule)
        {
            return new ScheduleResponse
            {
                ScheduleID = schedule.ScheduleID,
                TrainID = schedule.TrainID,
                TrainRouteID = schedule.TrainRouteID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek,
            };
        }
        public static ScheduleResponse_joined ConvertToResponseAll(Schedule schedule,
                                                    Train train,
                                                    TrainRoute trainRoute)
        {
            return new ScheduleResponse_joined
            {
                ScheduleID = schedule.ScheduleID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek,

                Train = TrainMapper.ConvertToResponse(train),
                TrainRoute = TrainRouteMapper.ConvertToResponse(trainRoute),
            };
        }
    }
}
