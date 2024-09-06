using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Schedule;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public DeleteScheduleCommandHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleID);

            if (schedule == null)
            {
                throw new Exception("Schedule not found");
            }

            await _scheduleRepository.DeleteAsync(schedule);

            return Unit.Value;
        }
    }
}
