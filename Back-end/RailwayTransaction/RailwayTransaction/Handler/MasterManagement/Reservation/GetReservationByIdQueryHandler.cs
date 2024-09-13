using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Reservation;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Domain.Entities.Dtos.Response.dependent.ReservationResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;
        private readonly IRepository<Domain.Entities.Ticket, int> _ticketRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public GetReservationByIdQueryHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository,
                                                IRepository<Domain.Entities.Ticket, int> ticketRepository,
                                                IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _reservationRepository = reservationRepository;
            _ticketRepository = ticketRepository;
            _seatRepository = seatRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.ReservationResponse_joined> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            var ticket = await _ticketRepository.GetByIdAsync(reservation.PnrNo);
            List<Domain.Entities.Seat> seats = (await _seatRepository.GetAllAsync()).ToList();
            return ReservationMapper.ConvertToResponseAll(reservation, ticket, seats);
        }
    }
}
