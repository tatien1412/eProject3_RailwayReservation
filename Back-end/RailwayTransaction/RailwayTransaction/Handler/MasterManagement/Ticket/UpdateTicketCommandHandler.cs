using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Ticket;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Ticket
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly IRepository<Domain.Entities.Ticket, int> _trainRepository;

        public UpdateTicketCommandHandler(IRepository<Domain.Entities.Ticket, int> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _trainRepository.GetByIdAsync(request.PnrNo);

            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            ticket.Name = request.Name;
            ticket.Age = request.Age;
            ticket.Gender = request.Gender;
            ticket.TotalPassengers = request.TotalPassengers;
            await _trainRepository.UpdateAsync(ticket);

            return Unit.Value;
        }
    }
}
