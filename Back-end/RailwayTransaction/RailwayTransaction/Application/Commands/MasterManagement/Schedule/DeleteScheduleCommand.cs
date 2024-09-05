using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Schedule
{
    public class DeleteScheduleCommand : IRequest
    {
        public int ScheduleID { get; set; }
    }
}
