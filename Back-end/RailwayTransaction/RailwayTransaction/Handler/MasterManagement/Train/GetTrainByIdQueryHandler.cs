using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Train;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class GetTrainByIdQueryHandler : IRequestHandler<GetTrainByIdQuery, Domain.Entities.Train>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;

        public GetTrainByIdQueryHandler(IRepository<Domain.Entities.Train, int> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Domain.Entities.Train> Handle(GetTrainByIdQuery request, CancellationToken cancellationToken)
        {
            var train = await _trainRepository.GetByIdAsync(request.TrainID);

            if (train == null)
            {
                throw new Exception("Train not found");
            }

            return train;
        }
    }
}
