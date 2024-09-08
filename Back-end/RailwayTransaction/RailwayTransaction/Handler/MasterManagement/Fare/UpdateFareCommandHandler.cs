using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Fare;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Fare
{
    public class UpdateFareCommandHandler : IRequestHandler<UpdateFareCommand>
    {
        private readonly IRepository<Domain.Entities.Fare, int> _fareRepository;

        public UpdateFareCommandHandler(IRepository<Domain.Entities.Fare, int> fareRepository)
        {
            _fareRepository = fareRepository;
        }

        public async Task<Unit> Handle(UpdateFareCommand request, CancellationToken cancellationToken)
        {
            var fare = await _fareRepository.GetByIdAsync(request.FareID);

            if (fare == null)
            {
                throw new Exception("Fare not found");
            }

            fare.ReservationID = request.ReservationID;
            fare.Distance = request.Distance;
            fare.CompartmentType = request.CompartmentType;
            fare.TrainType = request.TrainType;
            fare.Amount = request.Amount;
            await _fareRepository.UpdateAsync(fare);

            return Unit.Value;
        }
    }
}
