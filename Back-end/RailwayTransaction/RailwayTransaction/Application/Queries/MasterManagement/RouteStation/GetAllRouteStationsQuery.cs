using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.RouteStation
{
    public class GetAllRouteStationsQuery : IRequest<List<Domain.Entities.RouteStation>>
    {
    }
}
