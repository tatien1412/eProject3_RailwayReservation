using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.RouteStation
{
    public class CreateRouteStationCommandHandler : IRequestHandler<CreateRouteStationCommand, int>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public CreateRouteStationCommandHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _routeStationRepository = routeStationRepository;
        }

        public async Task<int> Handle(CreateRouteStationCommand request, CancellationToken cancellationToken)
        {
            var routeStation = new Domain.Entities.RouteStation
            {
                TrainRouteID = request.TrainRouteID,
                StationID = request.StationID,
                OrderInRoute = request.OrderInRoute,
            };

            if (request.OrderInRoute < 0)
            {
                throw new Exception("OrderInRoute out of valid range");
            }
            await _routeStationRepository.AddAsync(routeStation);

            return routeStation.RouteStationID;
        }
    }
}
