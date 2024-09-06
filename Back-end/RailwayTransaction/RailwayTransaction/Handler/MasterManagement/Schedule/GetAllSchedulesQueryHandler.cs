using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Schedule;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, List<Domain.Entities.Schedule>>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public GetAllSchedulesQueryHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Domain.Entities.Schedule>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Schedule> thành List<Schedule>
            return (await _scheduleRepository.GetAllAsync()).ToList();
        }
    }
}
