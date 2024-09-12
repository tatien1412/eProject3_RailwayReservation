using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.TrainRoute;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.TrainRoute
{
    public class DeleteTrainRouteCommandHandler : IRequestHandler<DeleteTrainRouteCommand>
    {
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;

        public DeleteTrainRouteCommandHandler(IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _trainRouteRepository = trainRouteRepository;
        }

        public async Task<Unit> Handle(DeleteTrainRouteCommand request, CancellationToken cancellationToken)
        {
            var trainRoute = await _trainRouteRepository.GetByIdAsync(request.TrainRouteID);

            if (trainRoute == null)
            {
                throw new Exception("TrainRoute not found");
            }

            await _trainRouteRepository.DeleteAsync(trainRoute);

            return Unit.Value;
        }
    }
}
