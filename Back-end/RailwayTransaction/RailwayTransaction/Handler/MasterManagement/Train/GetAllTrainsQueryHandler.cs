using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Train;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Train
{
    public class GetAllTrainsQueryHandler : IRequestHandler<GetAllTrainsQuery, List<Domain.Entities.Train>>
    {
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;

        public GetAllTrainsQueryHandler(IRepository<Domain.Entities.Train, int> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<List<Domain.Entities.Train>> Handle(GetAllTrainsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Train> thành List<Train>
            return (await _trainRepository.GetAllAsync()).ToList();
        }
    }
}
