using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Station;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class UpdateStationCommandHandler : IRequestHandler<UpdateStationCommand>
    {
        private readonly IRepository<Domain.Entities.Station, int> _stationRepository;

        public UpdateStationCommandHandler(IRepository<Domain.Entities.Station, int> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Unit> Handle(UpdateStationCommand request, CancellationToken cancellationToken)
        {
            var station = await _stationRepository.GetByIdAsync(request.StationID);

            if (station == null)
            {
                throw new Exception("Station not found");
            }

            station.StationCode = request.StationCode;
            station.StationName = request.StationName;
            station.RailwayDivisionName = request.RailwayDivisionName;

            await _stationRepository.UpdateAsync(station);

            return Unit.Value;
        }
    }
}
