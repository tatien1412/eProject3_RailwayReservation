using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class ScheduleResponse_joined
    {
        public int ScheduleID { get; set; }
        public int TrainID { get; set; }
        public string DepartureTime { get; set; } 
        public string ArrivalTime { get; set; }    
        public string DayOfWeek { get; set; }
        public TrainResponse Train { get; set; }
    }
}
