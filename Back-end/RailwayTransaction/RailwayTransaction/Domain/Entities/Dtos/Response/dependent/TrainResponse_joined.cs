using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class TrainResponse_joined
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }
        public string TrainStatus { get; set; }

        public int NumberOfCompartments { get; set; }
        public int TrainRouteID { get; set; }
        public TrainRouteResponse TrainRoute { get; set; }
        public ICollection<CompartmentResponse> Compartments { get; set; }
        public ICollection<ScheduleResponse> Schedules { get; set; }
    }
}