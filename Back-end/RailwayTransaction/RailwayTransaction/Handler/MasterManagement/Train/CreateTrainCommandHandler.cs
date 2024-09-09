using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Train;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class CreateTrainCommandHandler : IRequestHandler<CreateTrainCommand, int>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;

        public CreateTrainCommandHandler(IRepository<Domain.Entities.Train, int> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<int> Handle(CreateTrainCommand request, CancellationToken cancellationToken)
        {
            var train = new Domain.Entities.Train
            {
                TrainName = request.TrainName,
                TrainRouteDetails = request.TrainRouteDetails,
                TrainRouteID = request.TrainRouteID,
                NumberOfCompartments = request.NumberOfCompartments
            };

            await _trainRepository.AddAsync(train);

            return train.TrainID;
        }
    }
}
