using MediatR;
using RailwayTransaction.Application.Commands.Staff;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories.MasterManagement;

namespace RailwayTransaction.Handler.Staff
{
    public class UpdateSeatStatusHandler : IRequestHandler<UpdateSeatStatusQuery>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        public UpdateSeatStatusHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository,
                                    IRepository<Domain.Entities.Seat, int> seatRepository,
                                    IRepository<Domain.Entities.Train, int> trainRepository
                                   )
        {
            _compartmentRepository = compartmentRepository;
            _seatRepository = seatRepository;
            _trainRepository = trainRepository;
        }
        public async Task<Unit> Handle(UpdateSeatStatusQuery request, CancellationToken cancellationToken)
        {
            var val = request.TotalConFirmTicket;
            var compartment = await _compartmentRepository.GetAllAsync();
            var seat = await _seatRepository.GetAllAsync();
            foreach (var item in compartment)
            {
                if (item.CompartmentType == request.CompartmentType&&item.TrainID==request.TrainID)
                {
                    foreach (var item2 in seat)
                    {
                        if (item2.CompartmentID == item.CompartmentID && val > 0 && item2.SeatStatus == "InQueue")
                        {
                            var copy = item2;
                            copy.SeatStatus = "Unavailable";
                            _seatRepository.UpdateAsync(copy);
                            val--;
                        }
                    }
                }
            }
            return Unit.Value;
        }
    }
}
