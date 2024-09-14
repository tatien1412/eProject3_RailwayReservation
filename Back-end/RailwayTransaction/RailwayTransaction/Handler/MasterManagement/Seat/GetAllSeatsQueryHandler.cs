using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Seat;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class GetAllSeatsQueryHandler : IRequestHandler<GetAllSeatsQuery, List<Domain.Entities.Dtos.Response.independent.SeatResponse>>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public GetAllSeatsQueryHandler(IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Domain.Entities.Dtos.Response.independent.SeatResponse>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Seat> thành List<Seat>
            return (await _seatRepository.GetAllAsync()).Select(s => SeatMapper.ConvertToResponse(s)).ToList();
        }
    }
}
