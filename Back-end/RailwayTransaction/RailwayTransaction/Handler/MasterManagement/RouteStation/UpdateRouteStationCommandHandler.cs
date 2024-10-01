using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.RouteStation
{
    public class UpdateRouteStationCommandHandler : IRequestHandler<UpdateRouteStationCommand>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public UpdateRouteStationCommandHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _routeStationRepository = routeStationRepository;
        }

        public async Task<Unit> Handle(UpdateRouteStationCommand request, CancellationToken cancellationToken)
        {
            var routeStation = await _routeStationRepository.GetByIdAsync(request.RouteStationID);

            if (routeStation == null)
            {
                throw new Exception("RouteStation not found");
            }

            routeStation.TrainRouteID = request.RouteStationID;
            routeStation.StationID = request.StationID;
            routeStation.OrderInRoute = request.OrderInRoute;

            if (request.OrderInRoute < 0)
            {
                throw new Exception("OrderInRoute out of valid range");
            }
            await _routeStationRepository.UpdateAsync(routeStation);

            return Unit.Value;
        }
    }
}
