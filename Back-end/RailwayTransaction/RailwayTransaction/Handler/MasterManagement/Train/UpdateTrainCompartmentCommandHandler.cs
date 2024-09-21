using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Train;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class UpdateTrainCompartmentCommandHandler : IRequestHandler<UpdateTrainCompartmentCommand>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;

        public UpdateTrainCompartmentCommandHandler(IRepository<Domain.Entities.Train, int> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Unit> Handle(UpdateTrainCompartmentCommand request, CancellationToken cancellationToken)
        {
            var train = await _trainRepository.GetByIdAsync(request.TrainID);
            if (train == null)
            {
                throw new Exception("Train not found");
            }
            train.NumberOfCompartments = request.NumberOfCompartments;
            await _trainRepository.UpdateAsync(train);
            return Unit.Value;
        }
    }
}
