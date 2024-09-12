using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class ScheduleResponse_joined
    {
        public int ScheduleID { get; set; }
        public int TrainID { get; set; }
        public int TrainRouteID { get; set; }
        public TimeSpan DepartureTime { get; set; } 
        public TimeSpan ArrivalTime { get; set; }    
        public string DayOfWeek { get; set; }
        public TrainResponse Train { get; set; }
        public TrainRouteResponse TrainRoute { get; set; }


    }
}
