using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.RouteStation
{
    public class GetRouteStationByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.RouteStationResponse_joined>
    {
        public int RouteStationID { get; set; }

        public GetRouteStationByIdQuery(int routeStationID)
        {
            RouteStationID = routeStationID;
        }
    }
}
