using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Trip;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;
using System.Diagnostics;


namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, Domain.Entities.Dtos.Response.dependent.TripResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;
        private readonly IRepository<Domain.Entities.Station, int> _stationRepository;

        public GetTripByIdQueryHandler(IRepository<Domain.Entities.Trip, int> tripRepository,
                                        IRepository<Domain.Entities.Reservation, int> reservationRepository,
                                        IRepository<Domain.Entities.Schedule, int> scheduleRepository,
                                        IRepository<Domain.Entities.Station, int> stationRepository)
        {
            _tripRepository = tripRepository;
            _reservationRepository = reservationRepository;
            _scheduleRepository = scheduleRepository;
            _stationRepository = stationRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.TripResponse_joined> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByIdAsync(request.TripID);

            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            var reservation = await _reservationRepository.GetByIdAsync(trip.ReservationID);
            var schedule = await _scheduleRepository.GetByIdAsync(trip.ScheduleID);
            var startStation = await _stationRepository.GetByIdAsync(trip.StartStationID);
            var endStation = await _stationRepository.GetByIdAsync(trip.EndStationID);
            return TripMapper.ConvertToResponseAll(trip, reservation, schedule, startStation, endStation);
        }
    }
}
