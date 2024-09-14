using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public CreateReservationCommandHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Domain.Entities.Reservation
            {
               PnrNo = request.PnrNo,
               DateOfJourney = request.DateOfJourney,
               TotalFare = request.TotalFare,
            };

            await _reservationRepository.AddAsync(reservation);

            return reservation.ReservationID;
        }
    }
}
