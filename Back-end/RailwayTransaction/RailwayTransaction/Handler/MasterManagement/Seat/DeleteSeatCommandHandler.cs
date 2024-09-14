using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Seat;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public DeleteSeatCommandHandler(IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Unit> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = await _seatRepository.GetByIdAsync(request.SeatID);

            if (seat == null)
            {
                throw new Exception("Seat not found");
            }

            await _seatRepository.DeleteAsync(seat);

            return Unit.Value;
        }
    }
}
