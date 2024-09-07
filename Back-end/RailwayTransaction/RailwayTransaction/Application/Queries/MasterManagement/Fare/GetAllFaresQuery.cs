using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Fare
{
    public class GetAllFaresQuery : IRequest<List<Domain.Entities.Fare>>
    {
    }
}
