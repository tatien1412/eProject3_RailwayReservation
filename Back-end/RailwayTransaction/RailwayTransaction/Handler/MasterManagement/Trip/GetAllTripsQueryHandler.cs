using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, List<Domain.Entities.Trip>>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;

        public GetAllTripsQueryHandler(IRepository<Domain.Entities.Trip, int> tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<List<Domain.Entities.Trip>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Trip> thành List<Trip>
            return (await _tripRepository.GetAllAsync()).ToList();
        }
    }
}
