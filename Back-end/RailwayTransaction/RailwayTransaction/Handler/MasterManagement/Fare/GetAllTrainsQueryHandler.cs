using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Fare;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Fare
{
    public class GetAllFaresQueryHandler : IRequestHandler<GetAllFaresQuery, List<Domain.Entities.Fare>>
    {
        private readonly IRepository<Domain.Entities.Fare, int> _fareRepository;

        public GetAllFaresQueryHandler(IRepository<Domain.Entities.Fare, int> fareRepository)
        {
            _fareRepository = fareRepository;
        }

        public async Task<List<Domain.Entities.Fare>> Handle(GetAllFaresQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Fare> thành List<Fare>
            return (await _fareRepository.GetAllAsync()).ToList();
        }
    }
}
