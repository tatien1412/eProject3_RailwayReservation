using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public DeleteReservationCommandHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository, IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _reservationRepository = reservationRepository;
            _cashTransactionRepository = cashTransactionRepository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            await _reservationRepository.DeleteAsync(reservation);

            return Unit.Value;
        }
    }
}
