using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.RouteStation
{
    public class GetAllRouteStationsQueryHandler : IRequestHandler<GetAllRouteStationsQuery, List<Domain.Entities.Dtos.Response.independent.RouteStationResponse>>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public GetAllRouteStationsQueryHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _routeStationRepository = routeStationRepository;
        }

        public async Task<List<Domain.Entities.Dtos.Response.independent.RouteStationResponse>> Handle(GetAllRouteStationsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<RouteStation> thành List<RouteStation>
            return (await _routeStationRepository.GetAllAsync()).Select(r => RouteStationMapper.ConvertToResponse(r)).ToList();
        }
    }
}
