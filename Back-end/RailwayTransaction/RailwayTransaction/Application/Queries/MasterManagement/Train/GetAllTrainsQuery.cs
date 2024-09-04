using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Train
{
    public class GetAllTrainsQuery : IRequest<List<Domain.Entities.Train>>
    {
    }
}
