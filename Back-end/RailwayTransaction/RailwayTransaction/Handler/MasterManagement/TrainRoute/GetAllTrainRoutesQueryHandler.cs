using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.TrainRoute;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.TrainRoute
{
    public class GetAllTrainRoutesQueryHandler : IRequestHandler<GetAllTrainRoutesQuery, List<Domain.Entities.TrainRoute>>
    {
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;

        public GetAllTrainRoutesQueryHandler(IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _trainRouteRepository = trainRouteRepository;
        }

        public async Task<List<Domain.Entities.TrainRoute>> Handle(GetAllTrainRoutesQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<TrainRoute> thành List<TrainRoute>
            return (await _trainRouteRepository.GetAllAsync()).ToList();
        }
    }
}
