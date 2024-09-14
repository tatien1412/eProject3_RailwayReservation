using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Schedule
{
    public class GetScheduleByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.ScheduleResponse_joined>
    {
        public int ScheduleID { get; set; }

        public GetScheduleByIdQuery(int scheduleID)
        {
            ScheduleID = scheduleID;
        }
    }
}
