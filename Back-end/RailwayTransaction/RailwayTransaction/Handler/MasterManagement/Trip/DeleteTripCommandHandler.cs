using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;

        public DeleteTripCommandHandler(IRepository<Domain.Entities.Trip, int> tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByIdAsync(request.TripID);

            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            await _tripRepository.DeleteAsync(trip);

            return Unit.Value;
        }
    }
}
