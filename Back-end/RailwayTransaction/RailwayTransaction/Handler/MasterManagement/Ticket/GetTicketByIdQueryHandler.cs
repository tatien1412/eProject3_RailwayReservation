using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Ticket;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Ticket
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Domain.Entities.Ticket>
    {
        private readonly IRepository<Domain.Entities.Ticket, int> _ticketRepository;

        public GetTicketByIdQueryHandler(IRepository<Domain.Entities.Ticket, int> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Domain.Entities.Ticket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var Ticket = await _ticketRepository.GetByIdAsync(request.TicketID);

            if (Ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            return Ticket;
        }
    }
}
