using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class GetAllCompartmentsQueryHandler : IRequestHandler<GetAllCompartmentsQuery, List<Domain.Entities.Compartment>>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;

        public GetAllCompartmentsQueryHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository)
        {
            _compartmentRepository = compartmentRepository;
        }

        public async Task<List<Domain.Entities.Compartment>> Handle(GetAllCompartmentsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Compartment> thành List<Compartment>
            return (await _compartmentRepository.GetAllAsync()).ToList();
        }
    }
}
