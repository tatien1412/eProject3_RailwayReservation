using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Ticket;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Ticket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IRepository<Domain.Entities.Ticket, int> _ticketRepository;

        public CreateTicketCommandHandler(IRepository<Domain.Entities.Ticket, int> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Domain.Entities.Ticket
            {
                Name = request.Name,
                Age = request.Age,
                Gender = request.Gender,
                TotalPassengers = request.TotalPassengers,
            };

            await _ticketRepository.AddAsync(ticket);

            return ticket.PnrNo;
        }
    }
}
