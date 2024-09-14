using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Train;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;


namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class GetTrainByIdQueryHandler : IRequestHandler<GetTrainByIdQuery, Domain.Entities.Dtos.Response.dependent.TrainResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public GetTrainByIdQueryHandler(IRepository<Domain.Entities.Train, int> trainRepository,
                                         IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository,
                                         IRepository<Domain.Entities.Compartment, int> compartmentRepository,
                                         IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _trainRepository = trainRepository;
            _trainRouteRepository = trainRouteRepository;
            _compartmentRepository = compartmentRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.TrainResponse_joined> Handle(GetTrainByIdQuery request, CancellationToken cancellationToken)
        {
            var train = await _trainRepository.GetByIdAsync(request.TrainID);

            if (train == null)
            {
                throw new Exception("Train not found");
            }

            var trainRoute = await _trainRouteRepository.GetByIdAsync(train.TrainRouteID);
            List<Domain.Entities.Compartment> compartment = (await _compartmentRepository.GetAllAsync()).ToList();
            List<Domain.Entities.Schedule> schedule = (await _scheduleRepository.GetAllAsync()).ToList();
            return TrainMapper.ConvertToResponseAll(train, trainRoute, compartment, schedule);
        }
    }
}
