using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Trip
{
    public class GetAllTripsQuery : IRequest<List<Domain.Entities.Trip>>
    {
    }
}
