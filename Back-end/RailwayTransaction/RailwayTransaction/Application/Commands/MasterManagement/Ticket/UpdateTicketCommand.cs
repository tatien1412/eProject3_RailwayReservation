using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Ticket
{
    public class UpdateTicketCommand : IRequest
    {
        public int PnrNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int TotalPassengers { get; set; }
    }
}
