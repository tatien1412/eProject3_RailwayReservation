using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.RouteStation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.RouteStation
{
    public class DeleteRouteStationCommandHandler : IRequestHandler<DeleteRouteStationCommand>
    {
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public DeleteRouteStationCommandHandler(IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _routeStationRepository = routeStationRepository;
        }

        public async Task<Unit> Handle(DeleteRouteStationCommand request, CancellationToken cancellationToken)
        {
            var routeStation = await _routeStationRepository.GetByIdAsync(request.RouteStationID);

            if (routeStation == null)
            {
                throw new Exception("RouteStation not found");
            }

            await _routeStationRepository.DeleteAsync(routeStation);

            return Unit.Value;
        }
    }
}
