using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Schedule;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public GetAllSchedulesQueryHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Schedule> thành List<Schedule>
            return (await _scheduleRepository.GetAllAsync()).Select(s => ScheduleMapper.ConvertToResponse(s)).ToList();
        }
    }
}
