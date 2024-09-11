using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, Domain.Entities.Trip>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;

        public GetTripByIdQueryHandler(IRepository<Domain.Entities.Trip, int> tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Domain.Entities.Trip> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            var Trip = await _tripRepository.GetByIdAsync(request.TripID);

            if (Trip == null)
            {
                throw new Exception("Trip not found");
            }

            return Trip;
        }
    }
}
