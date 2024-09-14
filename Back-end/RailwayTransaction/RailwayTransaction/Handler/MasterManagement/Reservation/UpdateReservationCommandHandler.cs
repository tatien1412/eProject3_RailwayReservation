using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public UpdateReservationCommandHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            reservation.PnrNo = request.PnrNo;
            reservation.DateOfJourney = request.DateOfJourney;
            reservation.TotalFare = request.TotalFare;

            await _reservationRepository.UpdateAsync(reservation);

            return Unit.Value;
        }
    }
}
