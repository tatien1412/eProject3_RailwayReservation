using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Station;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class GetAllStationsQueryHandler : IRequestHandler<GetAllStationsQuery, List<Domain.Entities.Station>>
    {
        private readonly IRepository<Domain.Entities.Station> _stationRepository;

        public GetAllStationsQueryHandler(IRepository<Domain.Entities.Station> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<List<Domain.Entities.Station>> Handle(GetAllStationsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Station> thành List<Station>
            return (await _stationRepository.GetAllAsync()).ToList();
        }
    }
}
