using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Seat;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class GetSeatByIdQueryHandler : IRequestHandler<GetSeatByIdQuery, Domain.Entities.Seat>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public GetSeatByIdQueryHandler(IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Domain.Entities.Seat> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            var Seat = await _seatRepository.GetByIdAsync(request.SeatID);

            if (Seat == null)
            {
                throw new Exception("Seat not found");
            }

            return Seat;
        }
    }
}
