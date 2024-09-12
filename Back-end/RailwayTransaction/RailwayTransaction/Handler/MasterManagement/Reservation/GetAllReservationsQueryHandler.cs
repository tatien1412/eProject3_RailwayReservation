using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<Domain.Entities.Reservation>>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public GetAllReservationsQueryHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<Domain.Entities.Reservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Train> thành List<Train>
            return (await _reservationRepository.GetAllAsync()).ToList();
        }
    }
}
