using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, int>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;

        public CreateTripCommandHandler(IRepository<Domain.Entities.Trip, int> tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<int> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = new Domain.Entities.Trip
            {
                ReservationID = request.ReservationID,
                ScheduleID = request.ScheduleID,
                StartStationID = request.StartStationID,
                EndStationID = request.EndStationID,
                DepartureTime = request.DepartureTime,
                ArrivalTime = request.ArrivalTime,
                TravelTime = request.TravelTime,
            };

            await _tripRepository.AddAsync(trip);

            return trip.TripID;
        }
    }
}
