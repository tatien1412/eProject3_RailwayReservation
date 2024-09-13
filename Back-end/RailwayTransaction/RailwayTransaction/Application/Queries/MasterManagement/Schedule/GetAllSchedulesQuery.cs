using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Schedule
{
    public class GetAllSchedulesQuery : IRequest<List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>>
    {
    }
}
