using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class TrainRouteResponse
    {
        public int TrainRouteID { get; set; } 
        public string TrainRouteName { get; set; }

    }
}