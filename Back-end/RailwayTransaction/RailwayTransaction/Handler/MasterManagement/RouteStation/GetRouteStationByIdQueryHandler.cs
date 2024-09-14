using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class GetRouteStationByIdQueryHandler : IRequestHandler<GetRouteStationByIdQuery, Domain.Entities.Dtos.Response.dependent.RouteStationResponse_joined>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;
        private readonly IRepository<Domain.Entities.Station, int> _stationRouteRepository;

        public GetRouteStationByIdQueryHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository,
                                                IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository,
                                                IRepository<Domain.Entities.Station, int> stationRepository)
        {
            _routeStationRepository = routeStationRepository;
            _trainRouteRepository = trainRouteRepository;
            _stationRouteRepository = stationRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.RouteStationResponse_joined> Handle(GetRouteStationByIdQuery request, CancellationToken cancellationToken)
        {
            var routeStation = await _routeStationRepository.GetByIdAsync(request.RouteStationID);

            if (routeStation == null)
            {
                throw new Exception("RouteStation not found");
            }

            var trainRoute = await _trainRouteRepository.GetByIdAsync(routeStation.TrainRouteID);
            var station = await _stationRouteRepository.GetByIdAsync(routeStation.StationID);
            return RouteStationMapper.ConvertToResponseAll(routeStation, trainRoute, station);
        }
    }
}
