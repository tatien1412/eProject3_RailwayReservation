using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;

        public UpdateTripCommandHandler(IRepository<Domain.Entities.Trip, int> tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByIdAsync(request.TripID);

            if (trip == null)
            {
                throw new Exception("Train not found");
            }

            trip.ReservationID = request.ReservationID;
            trip.ScheduleID = request.ScheduleID;
            trip.StartStationID = request.StartStationID;
            trip.EndStationID = request.EndStationID;
            trip.DepartureTime = request.DepartureTime;
            trip.ArrivalTime = request.ArrivalTime;
            trip.TravelTime = request.TravelTime;
            await _tripRepository.UpdateAsync(trip);

            return Unit.Value;
        }
    }
}
