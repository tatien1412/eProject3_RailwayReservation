using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Station;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class GetAllStationsQueryHandler : IRequestHandler<GetAllStationsQuery, List<Domain.Entities.Dtos.Response.independent.StationResponse>>
    {
        private readonly IRepository<Domain.Entities.Station,int> _stationRepository;

        public GetAllStationsQueryHandler(IRepository<Domain.Entities.Station, int> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<List<Domain.Entities.Dtos.Response.independent.StationResponse>> Handle(GetAllStationsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Station> thành List<Station>
            return (await _stationRepository.GetAllAsync()).Select(s => StationMapper.ConvertToResponse(s)).ToList();
        }
    }
}
