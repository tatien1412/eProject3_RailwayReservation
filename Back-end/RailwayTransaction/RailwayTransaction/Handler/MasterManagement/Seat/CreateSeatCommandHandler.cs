using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Seat;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, int?>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public CreateSeatCommandHandler(IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<int?> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = new Domain.Entities.Seat
            {
                CompartmentID = request.CompartmentID,
                SeatNumber = request.SeatNumber,
                SeatStatus = request.SeatStatus,
                Fare = request.Fare,
                ReservationID = request.ReservationID,

            };

            if (request.Fare < 0)
            {
                throw new Exception("Fare out of valid range");
            }
            await _seatRepository.AddAsync(seat);

            return seat.ReservationID;
        }
    }
}
