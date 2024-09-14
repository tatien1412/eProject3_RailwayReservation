using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Trip;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, List<Domain.Entities.Dtos.Response.independent.TripResponse>>
    {
        private readonly IRepository<Domain.Entities.Trip, int> _tripRepository;

        public GetAllTripsQueryHandler(IRepository<Domain.Entities.Trip, int> tripRepository)
        {
            _tripRepository = tripRepository;
        }
        
        public async Task<List<Domain.Entities.Dtos.Response.independent.TripResponse>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Trip> thành List<Trip>
            return (await _tripRepository.GetAllAsync()).Select(t => TripMapper.ConvertToResponse(t)).ToList();
        }
    }
}
