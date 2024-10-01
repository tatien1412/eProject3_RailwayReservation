using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Train;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class UpdateTrainCommandHandler : IRequestHandler<UpdateTrainCommand>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;

        public UpdateTrainCommandHandler(IRepository<Domain.Entities.Train, int> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Unit> Handle(UpdateTrainCommand request, CancellationToken cancellationToken)
        {
            var train = await _trainRepository.GetByIdAsync(request.TrainID);

            if (train == null)
            {
                throw new Exception("Train not found");
            }

            train.TrainName = request.TrainName;
            train.TrainRouteID = request.TrainRouteID;
            train.TrainStatus = request.TrainStatus;
            train.NumberOfCompartments = request.NumberOfCompartments;


            if (request.NumberOfCompartments < 0)
            {
                throw new Exception("NumberOfCompartments out of valid range");
            }
            await _trainRepository.UpdateAsync(train);

            return Unit.Value;
        }
    }
}
