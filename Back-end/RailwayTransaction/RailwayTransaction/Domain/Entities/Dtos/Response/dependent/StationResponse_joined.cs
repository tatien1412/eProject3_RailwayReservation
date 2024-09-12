using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class StationResponse_joined
    {
        public int StationID { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string RailwayDivisionName { get; set; }
        public ICollection<RouteStationResponse> RouteStations { get; set; }

    }
}
