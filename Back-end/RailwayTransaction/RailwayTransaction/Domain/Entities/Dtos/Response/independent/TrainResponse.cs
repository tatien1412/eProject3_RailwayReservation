using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class TrainResponse
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }
        public string TrainRouteDetails { get; set; }

        public int NumberOfCompartments { get; set; }
        public int TrainRouteID { get; set; }

    }
}