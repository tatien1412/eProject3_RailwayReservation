using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Ticket;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Ticket
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<Domain.Entities.Ticket>>
    {
        private readonly IRepository<Domain.Entities.Ticket, int> _ticketRepository;

        public GetAllTicketsQueryHandler(IRepository<Domain.Entities.Ticket, int> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Domain.Entities.Ticket>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Ticket> thành List<Ticket>
            return (await _ticketRepository.GetAllAsync()).ToList();
        }
    }
}
