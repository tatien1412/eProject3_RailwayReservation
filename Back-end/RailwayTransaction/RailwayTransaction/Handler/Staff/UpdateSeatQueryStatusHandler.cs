using MediatR;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.Staff
{
    public class UpdateSeatQueryStatusHandler : IRequestHandler<UpdateSeatQueueStatusQuery>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        public UpdateSeatQueryStatusHandler(IRepository<Domain.Entities.Train,int> trainRepository,
                                            IRepository<Domain.Entities.Seat,int>   seatRepository,
                                            IRepository<Domain.Entities.Compartment,int> compartmentRepository)
        {
            _trainRepository = trainRepository;
            _seatRepository = seatRepository;
            _compartmentRepository = compartmentRepository;
        }
        public async Task<Unit> Handle(UpdateSeatQueueStatusQuery request, CancellationToken cancellationToken)
        {
            var val = request.TotalConFirmTicket;
            var compartment = await _compartmentRepository.GetAllAsync();
            var seat = await _seatRepository.GetAllAsync();
            foreach (var item in compartment)
            {
                if (item.CompartmentType == request.CompartmentType && item.TrainID == request.TrainID)
                {
                    foreach (var item2 in seat)
                    {
                        if (item2.CompartmentID == item.CompartmentID && val > 0 && item2.SeatStatus == "Available")
                        {
                            var copy = item2;
                            copy.SeatStatus = "InQueue";
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
