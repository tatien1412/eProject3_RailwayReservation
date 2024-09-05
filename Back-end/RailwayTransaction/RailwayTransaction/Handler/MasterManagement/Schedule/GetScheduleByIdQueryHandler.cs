using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Schedule;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, Domain.Entities.Schedule>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public GetScheduleByIdQueryHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Domain.Entities.Schedule> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleID);

            if (schedule == null)
            {
                throw new Exception("Schedule not found");
            }

            return schedule;
        }
    }
}
