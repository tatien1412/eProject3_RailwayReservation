using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Seat;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Seat
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand>
    {
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public UpdateSeatCommandHandler(IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Unit> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = await _seatRepository.GetByIdAsync(request.SeatID);

            if (seat == null)
            {
                throw new Exception("Seat not found");
            }

            seat.CompartmentID = request.CompartmentID;
            seat.SeatNumber = request.SeatNumber;
            seat.SeatStatus = request.SeatStatus;
            seat.Fare = request.Fare;
            seat.ReservationID = request.ReservationID;

            if (request.Fare < 0)
            {
                throw new Exception("Fare out of valid range");
            }
            await _seatRepository.UpdateAsync(seat);

            return Unit.Value;
        }
    }
}
