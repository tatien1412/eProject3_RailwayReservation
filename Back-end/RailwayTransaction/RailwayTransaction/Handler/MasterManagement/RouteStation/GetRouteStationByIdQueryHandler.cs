using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class GetRouteStationByIdQueryHandler : IRequestHandler<GetRouteStationByIdQuery, Domain.Entities.RouteStation>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public GetRouteStationByIdQueryHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _routeStationRepository = routeStationRepository;
        }

        public async Task<Domain.Entities.RouteStation> Handle(GetRouteStationByIdQuery request, CancellationToken cancellationToken)
        {
            var routeStation = await _routeStationRepository.GetByIdAsync(request.RouteStationID);

            if (routeStation == null)
            {
                throw new Exception("RouteStation not found");
            }

            return routeStation;
        }
    }
}
