using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, int>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;

        public CreateTripCommandHandler(IRepository<Domain.Entities.Trip, int> tripRepository,
                                        IRepository<Domain.Entities.RouteStation, int> routeStationRepository,
                                        IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _tripRepository = tripRepository;
            _routeStationRepository = routeStationRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<int> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            // Giả sử: lấy thông tin thời gian khởi hành từ ga đầu (ga 1) từ bảng Schedule
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleID);
            TimeSpan initialDepartureTime = TimeSpan.Parse(schedule.DepartureTime); // Giả sử 6:00

            // Thời gian di chuyển giữa các ga và thời gian dừng
            TimeSpan travelBetweenStations = TimeSpan.FromMinutes(15); // Thời gian di chuyển giữa 2 ga
            TimeSpan stopTimeAtStation = TimeSpan.FromMinutes(5);      // Thời gian dừng ở mỗi ga

            // Lấy thông tin RouteStation cho ga bắt đầu và kết thúc
            var startStation = await _routeStationRepository.GetByIdAsync(request.StartStationID);
            var endStation = await _routeStationRepository.GetByIdAsync(request.EndStationID);

            // Sử dụng thuộc tính OrderInRoute để tính toán số lượng ga giữa StartStation và EndStation
            int numberOfStations = Math.Abs(endStation.OrderInRoute - startStation.OrderInRoute);

            // Tính thời gian khởi hành từ StartStation
            TimeSpan totalTimeFromStart = (startStation.OrderInRoute - 1) * (travelBetweenStations + stopTimeAtStation);
            TimeSpan departureTimeFromStartStation = initialDepartureTime + totalTimeFromStart;

            // Tính thời gian kết thúc tại EndStation
            TimeSpan totalTravelTime = numberOfStations * travelBetweenStations;
            TimeSpan totalStopTime = (numberOfStations - 1) * stopTimeAtStation; // Dừng giữa các ga
            TimeSpan arrivalTimeAtEndStation = departureTimeFromStartStation + totalTravelTime + totalStopTime;

            // Tính thời gian của chuyến đi (TravelTime)
            TimeSpan totalTripTime = arrivalTimeAtEndStation - departureTimeFromStartStation;

            // Tạo mới Trip với thông tin tính toán được
            var trip = new Domain.Entities.Trip
            {
                ReservationID = request.ReservationID,
                ScheduleID = request.ScheduleID,
                StartStationID = request.StartStationID,
                EndStationID = request.EndStationID,
                DepartureTime = departureTimeFromStartStation,
                ArrivalTime = arrivalTimeAtEndStation,
                TravelTime = totalTripTime,
            };

            await _tripRepository.AddAsync(trip);

            return trip.TripID;
        }
    }
}
