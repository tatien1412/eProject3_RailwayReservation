using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Domain.Entities.Reservation>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public GetReservationByIdQueryHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Domain.Entities.Reservation> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            return reservation;
        }
    }
}
