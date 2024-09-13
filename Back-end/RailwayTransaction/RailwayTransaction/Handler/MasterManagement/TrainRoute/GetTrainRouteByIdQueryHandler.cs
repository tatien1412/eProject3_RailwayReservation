using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.TrainRoute;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;


namespace RailwayTransaction.Handler.MasterManagement.TrainRoute
{
    public class GetTrainRouteByIdQueryHandler : IRequestHandler<GetTrainRouteByIdQuery, Domain.Entities.Dtos.Response.dependent.TrainRouteResponse_joined>
    {
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public GetTrainRouteByIdQueryHandler(IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository, IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _trainRouteRepository = trainRouteRepository;
            _routeStationRepository = routeStationRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.TrainRouteResponse_joined> Handle(GetTrainRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var trainRoute = await _trainRouteRepository.GetByIdAsync(request.trainRouteID);

            if (trainRoute == null)
            {
                throw new Exception("TrainRoute not found");
            }

            List<Domain.Entities.RouteStation> routeStation = (await _routeStationRepository.GetAllAsync()).ToList();
            return TrainRouteMapper.ConvertToResponseAll(trainRoute, routeStation);
        }
    }
}
