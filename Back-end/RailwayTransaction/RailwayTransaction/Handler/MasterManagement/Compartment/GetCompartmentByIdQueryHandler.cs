using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class GetCompartmentByIdQueryHandler : IRequestHandler<GetCompartmentByIdQuery, Domain.Entities.Compartment>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;

        public GetCompartmentByIdQueryHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository)
        {
            _compartmentRepository = compartmentRepository;
        }

        public async Task<Domain.Entities.Compartment> Handle(GetCompartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var compartment = await _compartmentRepository.GetByIdAsync(request.CompartmentID);

            if (compartment == null)
            {
                throw new Exception("Compartment not found");
            }

            return compartment;
        }
    }
}
