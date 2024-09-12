using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class ScheduleResponse
    {
        public int ScheduleID { get; set; }
        public int TrainID { get; set; }
        public int TrainRouteID { get; set; }
        public TimeSpan DepartureTime { get; set; } 
        public TimeSpan ArrivalTime { get; set; }    
        public string DayOfWeek { get; set; }


    }
}
