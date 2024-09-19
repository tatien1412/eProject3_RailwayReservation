using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Schedule;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Schedule
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, Domain.Entities.Dtos.Response.dependent.ScheduleResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;

        public GetScheduleByIdQueryHandler(IRepository<Domain.Entities.Schedule, int> scheduleRepository,
                                                IRepository<Domain.Entities.Train, int> trainRepository,
                                                IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _scheduleRepository = scheduleRepository;
            _trainRepository = trainRepository;
            _trainRouteRepository = trainRouteRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.ScheduleResponse_joined> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleID);

            if (schedule == null)
            {
                throw new Exception("Schedule not found");
            }

            var train = await _trainRepository.GetByIdAsync(schedule.TrainID);
            //var trainRoute = await _trainRouteRepository.GetByIdAsync(schedule.TrainRouteID);
            return ScheduleMapper.ConvertToResponseAll(schedule, train);
        }
    }
}
