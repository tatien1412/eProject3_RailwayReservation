using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class RouteStationResponse_joined
    {
        public int RouteStationID { get; set; }
        public int TrainRouteID { get; set; }
        public int StationID { get; set; }
        public int OrderInRoute { get; set; }
        public TrainRouteResponse TrainRoute { get; set; }
        public StationResponse Station { get; set; }
    }
}