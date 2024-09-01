using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Station
{
    public class GetAllStationsQuery : IRequest<List<Domain.Entities.Station>>
    {
    }
}
