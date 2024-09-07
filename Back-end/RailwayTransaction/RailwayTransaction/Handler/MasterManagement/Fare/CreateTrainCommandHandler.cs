using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Fare;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Fare
{
    public class CreateFareCommandHandler : IRequestHandler<CreateFareCommand, int>
    {
        private readonly IRepository<Domain.Entities.Fare, int> _fareRepository;

        public CreateFareCommandHandler(IRepository<Domain.Entities.Fare, int> fareRepository)
        {
            _fareRepository = fareRepository;
        }

        public async Task<int> Handle(CreateFareCommand request, CancellationToken cancellationToken)
        {
            var fare = new Domain.Entities.Fare
            {
                ReservationID = request.ReservationID,
                Distance = request.Distance,
                CompartmentType = request.CompartmentType,
                TrainType = request.TrainType,
                Amount = request.Amount
            };

            await _fareRepository.AddAsync(fare);

            return fare.FareID;
        }
    }
}
