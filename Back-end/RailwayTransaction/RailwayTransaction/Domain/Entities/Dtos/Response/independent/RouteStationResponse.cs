using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class RouteStationResponse
    {
        public int RouteStationID { get; set; }
        public int TrainRouteID { get; set; }
        public int StationID { get; set; }
        public int Order { get; set; }
    }
}