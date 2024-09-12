using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.RouteStation
{
    public class GetAllRouteStationsQueryHandler : IRequestHandler<GetAllRouteStationsQuery, List<Domain.Entities.RouteStation>>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public GetAllRouteStationsQueryHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _routeStationRepository = routeStationRepository;
        }

        public async Task<List<Domain.Entities.RouteStation>> Handle(GetAllRouteStationsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<RouteStation> thành List<RouteStation>
            return (await _routeStationRepository.GetAllAsync()).ToList();
        }
    }
}
