using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class ScheduleResponse
    {
        public int ScheduleID { get; set; }
        public int TrainID { get; set; }
        public string DepartureTime { get; set; } 
        public string ArrivalTime { get; set; }    
        public string DayOfWeek { get; set; }
        public string DateOfTravel { get; set; }
    }
}
