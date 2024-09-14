using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Seat;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;


namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class GetSeatByIdQueryHandler : IRequestHandler<GetSeatByIdQuery, Domain.Entities.Dtos.Response.dependent.SeatResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public GetSeatByIdQueryHandler(IRepository<Domain.Entities.Seat, int> seatRepository,
                                                IRepository<Domain.Entities.Compartment, int> compartmentRepository,
                                                IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _seatRepository = seatRepository;
            _compartmentRepository = compartmentRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.SeatResponse_joined> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            var seat = await _seatRepository.GetByIdAsync(request.SeatID);

            if (seat == null)
            {
                throw new Exception("Seat not found");
            }

            var compartment = await _compartmentRepository.GetByIdAsync(seat.CompartmentID);
            var reservation = await _reservationRepository.GetByIdAsync(seat.ReservationID);
            return SeatMapper.ConvertToResponseAll(seat, compartment, reservation);
        }
    }
}
