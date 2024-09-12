using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class DeleteCompartmentCommandHandler : IRequestHandler<DeleteCompartmentCommand>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;

        public DeleteCompartmentCommandHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository)
        {
            _compartmentRepository = compartmentRepository;
        }

        public async Task<Unit> Handle(DeleteCompartmentCommand request, CancellationToken cancellationToken)
        {
            var compartment = await _compartmentRepository.GetByIdAsync(request.CompartmentID);

            if (compartment == null)
            {
                throw new Exception("Compartment not found");
            }

            await _compartmentRepository.DeleteAsync(compartment);

            return Unit.Value;
        }
    }
}
