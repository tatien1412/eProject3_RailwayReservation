using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Station;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class CreateStationCommandHandler : IRequestHandler<CreateStationCommand, int>
    {
        private readonly IRepository<Domain.Entities.Station,int> _stationRepository;

        public CreateStationCommandHandler(IRepository<Domain.Entities.Station, int> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<int> Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            var station = new Domain.Entities.Station
            {
                StationCode = request.StationCode,
                StationName = request.StationName,
                RailwayDivisionName = request.RailwayDivisionName
            };

            await _stationRepository.AddAsync(station);

            return station.StationID;
        }
    }
}
