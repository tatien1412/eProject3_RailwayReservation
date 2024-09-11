using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.RouteStation
{
    public class CreateRouteStationCommand : IRequest<int>
    {
        public int TrainRouteID { get; set; }
        public int StationID { get; set; }
        public int Order { get; set; }
    }
}
