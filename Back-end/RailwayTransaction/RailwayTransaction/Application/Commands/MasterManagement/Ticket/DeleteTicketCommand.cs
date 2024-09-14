using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Ticket
{
    public class DeleteTicketCommand : IRequest
    {
        public int PnrNo { get; set; }
    }
}
