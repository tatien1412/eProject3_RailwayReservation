using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class UpdateCompartmentCommandHandler : IRequestHandler<UpdateCompartmentCommand>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;

        public UpdateCompartmentCommandHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository)
        {
            _compartmentRepository = compartmentRepository;
        }

        public async Task<Unit> Handle(UpdateCompartmentCommand request, CancellationToken cancellationToken)
        {
            var compartment = await _compartmentRepository.GetByIdAsync(request.TrainID);

            if (compartment == null)
            {
                throw new Exception("Train not found");
            }

            compartment.TrainID = request.TrainID;
            compartment.CompartmentType = request.CompartmentType;
            compartment.NumberOfSeats   = request.NumberOfSeats;


            await _compartmentRepository.UpdateAsync(compartment);

            return Unit.Value;
        }
    }
}
