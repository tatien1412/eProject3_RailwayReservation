using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class TrainRouteResponse_joined
    {
        public int TrainRouteID { get; set; } 
        public string TrainRouteName { get; set; }
        public ICollection<RouteStationResponse> RouteStations { get; set; }

    }
}