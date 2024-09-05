using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Schedule;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public CreateScheduleCommandHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Domain.Entities.Schedule
            {
                TrainNo = request.TrainNo,
                StartStationID = request.StartStationID,
                EndStationID = request.EndStationID,
                DepartureTime = request.DepartureTime,
                ArrivalTime = request.ArrivalTime,
                DayOfWeek = request.DayOfWeek
            };

            await _scheduleRepository.AddAsync(schedule);

            return schedule.ScheduleID;
        }
    }
}
