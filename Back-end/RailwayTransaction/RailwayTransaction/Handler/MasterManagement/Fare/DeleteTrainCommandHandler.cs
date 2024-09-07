using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Fare;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Fare
{
    public class DeleteFareCommandHandler : IRequestHandler<DeleteFareCommand>
    {
        private readonly IRepository<Domain.Entities.Fare, int> _fareRepository;

        public DeleteFareCommandHandler(IRepository<Domain.Entities.Fare, int> fareRepository)
        {
            _fareRepository = fareRepository;
        }

        public async Task<Unit> Handle(DeleteFareCommand request, CancellationToken cancellationToken)
        {
            var fare = await _fareRepository.GetByIdAsync(request.FareID);

            if (fare == null)
            {
                throw new Exception("Fare not found");
            }

            await _fareRepository.DeleteAsync(fare);

            return Unit.Value;
        }
    }
}
