using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Station;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Station
{
    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand>
    {
        private readonly IRepository<Domain.Entities.Station> _stationRepository;

        public DeleteStationCommandHandler(IRepository<Domain.Entities.Station> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Unit> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            var station = await _stationRepository.GetByIdAsync(request.StationID);

            if (station == null)
            {
                throw new Exception("Station not found");
            }

            await _stationRepository.DeleteAsync(station);

            return Unit.Value;
        }
    }
}
