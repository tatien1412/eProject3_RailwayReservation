using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.TrainRoute;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.TrainRoute
{
    public class CreateTrainRouteCommandHandler : IRequestHandler<CreateTrainRouteCommand, int>
    {
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;

        public CreateTrainRouteCommandHandler(IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _trainRouteRepository = trainRouteRepository;
        }

        public async Task<int> Handle(CreateTrainRouteCommand request, CancellationToken cancellationToken)
        {
            var trainRoute = new Domain.Entities.TrainRoute
            {
                TrainRouteName = request.TrainRouteName,
            };

            await _trainRouteRepository.AddAsync(trainRoute);

            return trainRoute.TrainRouteID;
        }
    }
}
