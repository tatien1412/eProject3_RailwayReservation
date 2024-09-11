using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Ticket
{
    public class GetAllTicketsQuery : IRequest<List<Domain.Entities.Ticket>>
    {
    }
}
