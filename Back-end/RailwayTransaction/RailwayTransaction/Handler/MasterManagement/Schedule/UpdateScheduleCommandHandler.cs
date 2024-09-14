using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Schedule;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public UpdateScheduleCommandHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleID);

            if (schedule == null)
            {
                throw new Exception("Schedule not found");
            }
            schedule.TrainID = request.TrainID;
            schedule.TrainRouteID = request.TrainRouteID;
            schedule.DepartureTime = request.DepartureTime;
            schedule.ArrivalTime = request.ArrivalTime;
            schedule.DayOfWeek = request.DayOfWeek;
            await _scheduleRepository.UpdateAsync(schedule);

            return Unit.Value;
        }
    }
}
