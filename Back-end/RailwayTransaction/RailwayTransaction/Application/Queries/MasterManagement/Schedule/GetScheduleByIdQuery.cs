using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Schedule
{
    public class GetScheduleByIdQuery : IRequest<Domain.Entities.Schedule>
    {
        public int ScheduleID { get; set; }

        public GetScheduleByIdQuery(int scheduleID)
        {
            ScheduleID = scheduleID;
        }
    }
}
