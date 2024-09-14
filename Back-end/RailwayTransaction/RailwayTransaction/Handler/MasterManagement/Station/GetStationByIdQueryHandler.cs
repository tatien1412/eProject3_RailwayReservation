using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Station;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;


namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class GetStationByIdQueryHandler : IRequestHandler<GetStationByIdQuery, Domain.Entities.Dtos.Response.dependent.StationResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Station, int> _stationRepository;
        private readonly IRepository<Domain.Entities.RouteStation, int> _routeStationRepository;

        public GetStationByIdQueryHandler(IRepository<Domain.Entities.Station, int> stationRepository,
                                            IRepository<Domain.Entities.RouteStation, int> routeStationRepository)
        {
            _stationRepository = stationRepository;
            _routeStationRepository = routeStationRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.StationResponse_joined> Handle(GetStationByIdQuery request, CancellationToken cancellationToken)
        {
            var station = await _stationRepository.GetByIdAsync(request.StationID);

            if (station == null)
            {
                throw new Exception("Station not found");
            }

            List<Domain.Entities.RouteStation> routeStation = (await _routeStationRepository.GetAllAsync()).ToList();
            return StationMapper.ConvertToResponseAll(station, routeStation);
        }
    }
}
