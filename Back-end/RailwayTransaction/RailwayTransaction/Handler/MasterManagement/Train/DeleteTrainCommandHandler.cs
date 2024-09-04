using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Train;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class DeleteTrainCommandHandler : IRequestHandler<DeleteTrainCommand>
    {
        private readonly IRepository<Domain.Entities.Train> _trainRepository;

        public DeleteTrainCommandHandler(IRepository<Domain.Entities.Train> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Unit> Handle(DeleteTrainCommand request, CancellationToken cancellationToken)
        {
            var train = await _trainRepository.GetByIdAsync(request.TrainID);

            if (train == null)
            {
                throw new Exception("Train not found");
            }

            await _trainRepository.DeleteAsync(train);

            return Unit.Value;
        }
    }
}
