using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RailwayTransaction.Domain.Entities
{
    public class RouteStation
    {
        [Key]
        public int RouteStationID { get; set; }  // Khóa chính

        // Khóa ngoại đến bảng TrainRoute
        [ForeignKey("TrainRoute")]
        public int TrainRouteID { get; set; }
        public TrainRoute TrainRoute { get; set; }

        // Khóa ngoại đến bảng Station
        [ForeignKey("Station")]
        public int StationID { get; set; }
        public Station Station { get; set; }

        public int OrderInRoute { get; set; }  // Thứ tự của ga trong tuyến (số bé nhất là ga đầu, số lớn nhất là ga cuối)
    }
}
