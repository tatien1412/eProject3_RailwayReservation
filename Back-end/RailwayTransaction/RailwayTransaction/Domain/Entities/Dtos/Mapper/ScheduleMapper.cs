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
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek,
                DateOfTravel = schedule.DateOfTravel,
            };
        }
        public static ScheduleResponse_joined ConvertToResponseAll(Schedule schedule,
                                                    Train train)
        {
            return new ScheduleResponse_joined
            {
                ScheduleID = schedule.ScheduleID,
                TrainID = schedule.TrainID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                DayOfWeek = schedule.DayOfWeek,
                DateOfTravel = schedule.DateOfTravel,

                Train = TrainMapper.ConvertToResponse(train),
            };
        }
    }
}
