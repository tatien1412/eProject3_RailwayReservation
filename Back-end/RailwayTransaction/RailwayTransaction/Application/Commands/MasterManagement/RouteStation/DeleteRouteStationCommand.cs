using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.RouteStation
{
    public class DeleteRouteStationCommand : IRequest
    {
        public int RouteStationID { get; set; }
    }
}
