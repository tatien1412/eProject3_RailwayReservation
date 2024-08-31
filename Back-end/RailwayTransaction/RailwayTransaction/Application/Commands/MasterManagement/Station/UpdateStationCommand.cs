using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Station
{
    public class UpdateStationCommand : IRequest
    {
        public int StationID { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string RailwayDivisionName { get; set; }
    }
}
