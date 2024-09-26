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
        // Khởi tạo với DbContext
        public Searchhandler(IRepository<Domain.Entities.Train, int> trainRepository,
                                         IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository,
                                         IRepository<Domain.Entities.Station, int> stationRepository,
                                         IRepository<Domain.Entities.Schedule, int> scheduleRepository,
                                         IRepository<Domain.Entities.Compartment,int> compartmentRepository,
                                         IRepository<RouteStation, int> routeStationRepository)
        {
            _trainRepository = trainRepository;
            _trainRouteRepository = trainRouteRepository;
            _stationRepository = stationRepository;
            _scheduleRepository = scheduleRepository;
            _routeStationRepository = routeStationRepository;
            _compartmentRepository = compartmentRepository;
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
                     train.RouteStations.Any(rs => rs.StationID == element2)&&
                     train.Compartments.Any(cpm => cpm.NumberOfSeats>=request.TotalPassenger);
                if (bothInList)
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
            return matchingSchedules;
        }

       }
}
