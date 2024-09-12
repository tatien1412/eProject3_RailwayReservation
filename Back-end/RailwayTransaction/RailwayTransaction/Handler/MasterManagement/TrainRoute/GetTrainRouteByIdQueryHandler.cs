using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.TrainRoute;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.TrainRoute
{
    public class GetTrainRouteByIdQueryHandler : IRequestHandler<GetTrainRouteByIdQuery, Domain.Entities.TrainRoute>
    {
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;

        public GetTrainRouteByIdQueryHandler(IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _trainRouteRepository = trainRouteRepository;
        }

        public async Task<Domain.Entities.TrainRoute> Handle(GetTrainRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var TrainRoute = await _trainRouteRepository.GetByIdAsync(request.trainRouteID);

            if (TrainRoute == null)
            {
                throw new Exception("TrainRoute not found");
            }

            return TrainRoute;
        }
    }
}
