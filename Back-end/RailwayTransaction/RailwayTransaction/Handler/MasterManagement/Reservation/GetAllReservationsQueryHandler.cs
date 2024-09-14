using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Reservation;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<Domain.Entities.Dtos.Response.independent.ReservationResponse>>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public GetAllReservationsQueryHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<Domain.Entities.Dtos.Response.independent.ReservationResponse>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Train> thành List<Train>
            return (await _reservationRepository.GetAllAsync()).Select(r => ReservationMapper.ConvertToResponse(r)).ToList();
        }
    }
}
