using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Seat;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class GetAllSeatsQueryHandler : IRequestHandler<GetAllSeatsQuery, List<Domain.Entities.Seat>>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public GetAllSeatsQueryHandler(IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Domain.Entities.Seat>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Seat> thành List<Seat>
            return (await _seatRepository.GetAllAsync()).ToList();
        }
    }
}
