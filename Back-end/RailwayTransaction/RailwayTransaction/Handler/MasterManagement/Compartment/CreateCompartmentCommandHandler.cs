using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class CreateCompartmentCommandHandler : IRequestHandler<CreateCompartmentCommand, int>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;

        public CreateCompartmentCommandHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository)
        {
            _compartmentRepository = compartmentRepository;
        }

        public async Task<int> Handle(CreateCompartmentCommand request, CancellationToken cancellationToken)
        {
            var train = new Domain.Entities.Compartment
            {
                TrainID = request.TrainID,
                CompartmentType = request.CompartmentType,
                NumberOfSeats = request.NumberOfSeats,
            };

            await _compartmentRepository.AddAsync(train);

            return train.TrainID;
        }
    }
}
