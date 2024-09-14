using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Ticket;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Ticket
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
    {
        private readonly IRepository<Domain.Entities.Ticket, int> _ticketRepository;

        public DeleteTicketCommandHandler(IRepository<Domain.Entities.Ticket, int> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.PnrNo);

            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            await _ticketRepository.DeleteAsync(ticket);

            return Unit.Value;
        }
    }
}
