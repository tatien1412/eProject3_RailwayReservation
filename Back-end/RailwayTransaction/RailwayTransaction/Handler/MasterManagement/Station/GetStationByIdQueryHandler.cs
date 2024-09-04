using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Station;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class GetStationByIdQueryHandler : IRequestHandler<GetStationByIdQuery, Domain.Entities.Station>
    {
        private readonly IRepository<Domain.Entities.Station> _trainRepository;

        public GetStationByIdQueryHandler(IRepository<Domain.Entities.Station> stationRepository)
        {
            _trainRepository = stationRepository;
        }

        public async Task<Domain.Entities.Station> Handle(GetStationByIdQuery request, CancellationToken cancellationToken)
        {
            var station = await _trainRepository.GetByIdAsync(request.StationID);

            if (station == null)
            {
                throw new Exception("Station not found");
            }

            return station;
        }
    }
}
