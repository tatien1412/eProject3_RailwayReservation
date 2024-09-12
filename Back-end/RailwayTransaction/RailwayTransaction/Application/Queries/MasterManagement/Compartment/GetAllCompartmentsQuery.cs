using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Compartment
{
    public class GetAllCompartmentsQuery : IRequest<List<Domain.Entities.Compartment>>
    {
    }
}
