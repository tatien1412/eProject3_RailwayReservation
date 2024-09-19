using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories.MasterManagement;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;

        public UpdateReservationCommandHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        private async Task<int> CalculateDistanceAsync(int tripId)
        {
            // Lấy thông tin Trip từ bảng Trip
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            // Lấy thông tin ga khởi hành và ga kết thúc từ RouteStation
            var startStation = await _routeStationRepository.GetByStationIdAsync(trip.StartStationID);
            var endStation = await _routeStationRepository.GetByStationIdAsync(trip.EndStationID);

            // Tính toán khoảng cách dựa trên OrderInRoute của các ga
            int distance = Math.Abs(endStation.OrderInRoute - startStation.OrderInRoute);

            return distance;
        }


        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            reservation.PnrNo = request.PnrNo;
            reservation.DateOfJourney = request.DateOfJourney;
            reservation.TotalFare = request.TotalFare;

            await _reservationRepository.UpdateAsync(reservation);

            return Unit.Value;
        }
    }
}
