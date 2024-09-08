using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }  // Khóa chính

        // Khóa ngoại đến bảng Train
        [ForeignKey("Train")]
        public int TrainID { get; set; }
        public Train Train { get; set; }

        // Khóa ngoại đến bảng TrainRoute
        [ForeignKey("TrainTrainRoute")]
        public int TrainRouteID { get; set; }
        public TrainRoute TrainRoute { get; set; }

        public TimeSpan DepartureTime { get; set; }  // Thời gian khởi hành từ ga đầu
        public TimeSpan ArrivalTime { get; set; }    // Thời gian dự kiến đến ga cuối

        // Ngày trong tuần chuyến tàu hoạt động
        [MaxLength(50)]
        public string DayOfWeek { get; set; }
    }
}
