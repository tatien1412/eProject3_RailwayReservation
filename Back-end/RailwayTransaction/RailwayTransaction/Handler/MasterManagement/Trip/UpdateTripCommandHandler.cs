using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public UpdateTripCommandHandler(IRepository<Domain.Entities.Trip, int> tripRepository,
                                        IRepository<Domain.Entities.RouteStation, int> routeStationRepository,
                                        IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _tripRepository = tripRepository;
            _routeStationRepository = routeStationRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Unit> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByIdAsync(request.TripID);

            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            // Cập nhật các thông tin cơ bản từ request
            trip.ReservationID = request.ReservationID;
            trip.ScheduleID = request.ScheduleID;
            trip.StartStationID = request.StartStationID;
            trip.EndStationID = request.EndStationID;

            // Lấy thông tin thời gian khởi hành từ ga đầu tiên trong Schedule
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleID);
            TimeSpan initialDepartureTime = TimeSpan.Parse(schedule.DepartureTime); // Giả sử 6:00

            // Thời gian di chuyển giữa các ga và thời gian dừng ở mỗi ga
            TimeSpan travelBetweenStations = TimeSpan.FromMinutes(15); // Thời gian di chuyển giữa 2 ga
            TimeSpan stopTimeAtStation = TimeSpan.FromMinutes(5);      // Thời gian dừng ở mỗi ga

            // Lấy thông tin RouteStation cho ga bắt đầu và kết thúc
            var startStation = await _routeStationRepository.GetByIdAsync(request.StartStationID);
            var endStation = await _routeStationRepository.GetByIdAsync(request.EndStationID);

            // Tính số lượng ga giữa StartStation và EndStation
            int numberOfStations = Math.Abs(endStation.OrderInRoute - startStation.OrderInRoute);

            // Tính lại thời gian khởi hành từ StartStation
            TimeSpan totalTimeFromStart = (startStation.OrderInRoute - 1) * (travelBetweenStations + stopTimeAtStation);
            TimeSpan departureTimeFromStartStation = initialDepartureTime + totalTimeFromStart;

            // Tính thời gian kết thúc tại EndStation
            TimeSpan totalTravelTime = numberOfStations * travelBetweenStations;
            TimeSpan totalStopTime = (numberOfStations - 1) * stopTimeAtStation; // Dừng giữa các ga
            TimeSpan arrivalTimeAtEndStation = departureTimeFromStartStation + totalTravelTime + totalStopTime;

            // Cập nhật các giá trị thời gian trong Trip
            trip.DepartureTime = departureTimeFromStartStation;
            trip.ArrivalTime = arrivalTimeAtEndStation;
            trip.TravelTime = arrivalTimeAtEndStation - departureTimeFromStartStation;

            // Cập nhật lại Trip trong cơ sở dữ liệu
            await _tripRepository.UpdateAsync(trip);

            return Unit.Value;
        }
    }
}
