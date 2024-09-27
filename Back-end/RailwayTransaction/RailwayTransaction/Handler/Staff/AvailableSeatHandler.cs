using MediatR;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.Staff
{
    public class AvailableSeatHandler :  IRequestHandler<AvailabelseatQuery,Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;
        private readonly IRepository<Domain.Entities.TrainRoute, int> _trainRouteRepository;
        public AvailableSeatHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository,
                                    IRepository<Domain.Entities.Seat, int>  seatRepository,
                                    IRepository<Domain.Entities.Train, int> trainRepository,
                                    IRepository<Domain.Entities.Schedule, int> scheduleRepository,
                                    IRepository<Domain.Entities.TrainRoute, int> trainRouteRepository)
        {
            _compartmentRepository = compartmentRepository;
            _seatRepository=seatRepository;
           _trainRepository = trainRepository;
            _scheduleRepository = scheduleRepository;
            _trainRouteRepository = trainRouteRepository;
        }
        public async Task<Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse> Handle(AvailabelseatQuery request, CancellationToken cancellationToken)
        {
            var matching = new Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse();
            Train train = await _trainRepository.GetByIdAsync(request.TrainId);

            var trainRoute = await _trainRouteRepository.GetByIdAsync(train.TrainRouteID);
            List<Domain.Entities.Compartment> compartment = (await _compartmentRepository.GetAllAsync()).ToList();
            List<Domain.Entities.Schedule> schedule = (await _scheduleRepository.GetAllAsync()).ToList();
            matching.TrainId=request.TrainId;
            var trainmapper = TrainMapper.ConvertToResponseAll(train, trainRoute, compartment, schedule);
            foreach (var compartmentt in trainmapper.Compartments)
            {
                List<Seat> seat = (await _seatRepository.GetAllAsync()).ToList();
                List<Seat> filterseat = seat.Where(s => s.CompartmentID == compartmentt.CompartmentID).ToList();
                var res = new Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse();
                var filter = CompartmentMapper.ConvertToAvailableseatResponse(compartmentt.CompartmentID, seat);
                var CompartmentType = compartmentt.CompartmentType;
                if(CompartmentType=="AC1")
                matching.TotalAvailableSeatType1 += filterseat.Count(ss => ss.SeatStatus == "Available");
                if (CompartmentType == "AC2")
                    matching.TotalAvailableSeatType2 += filterseat.Count(ss => ss.SeatStatus == "Available");
                if (CompartmentType == "AC3")
                    matching.TotalAvailableSeatType3 += filterseat.Count(ss => ss.SeatStatus == "Available");
            }
            return matching;
        }
    }
}
