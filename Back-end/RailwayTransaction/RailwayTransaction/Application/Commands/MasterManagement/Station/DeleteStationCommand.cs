using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Station
{
    public class DeleteStationCommand : IRequest
    {
        public int StationID { get; set; }
    }
}
