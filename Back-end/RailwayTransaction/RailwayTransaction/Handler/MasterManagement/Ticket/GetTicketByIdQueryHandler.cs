using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Ticket;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Ticket
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Domain.Entities.Dtos.Response.dependent.TicketResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Ticket, int> _ticketRepository;

        public GetTicketByIdQueryHandler(IRepository<Domain.Entities.Ticket, int> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.TicketResponse_joined> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.TicketID);

            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            return TicketMapper.ConvertToResponseAll(ticket);
        }
    }
}
