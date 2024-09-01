using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Station
{
    public class CreateStationCommand : IRequest<int>
    {
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string RailwayDivisionName { get; set; }
    }
}
