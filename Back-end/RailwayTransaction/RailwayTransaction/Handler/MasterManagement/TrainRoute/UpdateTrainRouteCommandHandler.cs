using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.TrainRoute;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.TrainRoute
{
    public class UpdateTrainRouteCommandHandler : IRequestHandler<UpdateTrainRouteCommand>
    {
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;

        public UpdateTrainRouteCommandHandler(IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _trainRouteRepository = trainRouteRepository;
        }

        public async Task<Unit> Handle(UpdateTrainRouteCommand request, CancellationToken cancellationToken)
        {
            var trainRoute = await _trainRouteRepository.GetByIdAsync(request.TrainRouteID);

            if (trainRoute == null)
            {
                throw new Exception("TrainRoute not found");
            }

            trainRoute.TrainRouteName = request.TrainRouteName;
            await _trainRouteRepository.UpdateAsync(trainRoute);

            return Unit.Value;
        }
    }
}
