using RailwayTransaction.Domain.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories.MasterManagement;
using MediatR;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Application.Queries.MasterManagement.Train;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Entities.Dtos.Response.StaffReponse;
using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using System.Diagnostics;
using System.Collections;
using System.Xml.Linq;
namespace RailwayTransaction.Handler.Staff
{
    public class Searchhandler : IRequestHandler<SearchTrainQuery,List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;
        private readonly IRepository<Domain.Entities.Station, int> _stationRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;
        // Khởi tạo với DbContext
        public Searchhandler(IRepository<Domain.Entities.Train, int> trainRepository,
                                         IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository,
                                         IRepository<Domain.Entities.Station, int> stationRepository,
                                         IRepository<Domain.Entities.Schedule, int> scheduleRepository,
                                         IRepository<Domain.Entities.Compartment,int> compartmentRepository,
                                         IRepository<RouteStation, int> routeStationRepository,
                                         IRepository<Domain.Entities.Seat,int> seatRepository)
        {
            _trainRepository = trainRepository;
            _trainRouteRepository = trainRouteRepository;
            _stationRepository = stationRepository;
            _scheduleRepository = scheduleRepository;
            _routeStationRepository = routeStationRepository;
            _compartmentRepository = compartmentRepository;
            _seatRepository = seatRepository;
        }

        // Phương thức để lấy tất cả các chuyến tàu dựa trên fromStationId, toStationId và dateOfTravel
        public async Task<List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>> Handle(SearchTrainQuery request, CancellationToken cancellationToken)
        {



            var trains = await _trainRepository
            .GetAllAsync(); // Giả sử phương thức này trả về tất cả các tàu
            List<Domain.Entities.Compartment> compartment = (await _compartmentRepository.GetAllAsync()).ToList();
            List<Domain.Entities.Schedule> schedule = (await _scheduleRepository.GetAllAsync()).ToList();
            List<Domain.Entities.RouteStation> routestation = (await _routeStationRepository.GetAllAsync()).ToList();
            var filteredTrains = new List<TrainSearchReponse_joined>();
            foreach (var train in trains)
            {
                var trainroute = await _trainRouteRepository.GetByIdAsync(train.TrainRouteID);
                filteredTrains.Add(TrainMapper.ConvertToResponseSearch(train, trainroute, compartment, schedule, routestation));
            }

            // Lọc thêm theo lịch trình phù hợp với ngày đi
            var matchingSchedules = new List<Domain.Entities.Dtos.Response.independent.ScheduleResponse>();
            var element1 = request.FromStationId;
            var element2 = request.ToStationId;

            

            foreach (var train in filteredTrains)
            {
                bool bothInList = train.RouteStations.Any(rs => rs.StationID == element1) &&
                     train.RouteStations.Any(rs => rs.StationID == element2);
                if (bothInList)
                {
                    var matching = new Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse();
                    Train trainn = await _trainRepository.GetByIdAsync(train.TrainID);

                    var trainRoute = await _trainRouteRepository.GetByIdAsync(trainn.TrainRouteID);
                    matching.TrainId = train.TrainID;
                    var trainmapper = TrainMapper.ConvertToResponseAll(trainn, trainRoute, compartment, schedule);
                    foreach (var compartmentt in trainmapper.Compartments)
                    {
                        List<Seat> seat = (await _seatRepository.GetAllAsync()).ToList();
                        List<Seat> filterseat = seat.Where(s => s.CompartmentID == compartmentt.CompartmentID).ToList();
                        var res = new Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse();
                        var filter = CompartmentMapper.ConvertToAvailableseatResponse(compartmentt.CompartmentID, seat);
                        var CompartmentType = compartmentt.CompartmentType;
                        if (CompartmentType == "AC1")
                            matching.TotalAvailableSeatType1 += filterseat.Count(ss => ss.SeatStatus == "Available");
                        if (CompartmentType == "AC2")
                            matching.TotalAvailableSeatType2 += filterseat.Count(ss => ss.SeatStatus == "Available");
                        if (CompartmentType == "AC3")
                            matching.TotalAvailableSeatType3 += filterseat.Count(ss => ss.SeatStatus == "Available");
                    }

                    var availableseat = matching.TotalAvailableSeatType1+ matching.TotalAvailableSeatType2+ matching.TotalAvailableSeatType3;
                    if(availableseat > request.TotalPassenger)
                    {
                        var trainSchedules = train.Schedules
                    .Where(s => s.DateOfTravel == request.DateOfTravel) // Lọc theo ngày đi
                    .ToList();

                        if (trainSchedules.Count > 0)
                        {
                            matchingSchedules.AddRange(trainSchedules);
                        }
                    }
                   
                }
            }
            return matchingSchedules;
        }

       }
}
