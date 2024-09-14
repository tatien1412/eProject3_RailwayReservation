using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Ticket
{
    public class GetTicketByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.TicketResponse_joined>
    {
        public int TicketID { get; set; }

        public GetTicketByIdQuery(int ticketID)
        {
            TicketID = ticketID;
        }
    }
}
