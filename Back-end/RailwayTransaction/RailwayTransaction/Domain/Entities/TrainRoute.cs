using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class TrainRoute
    {
        [Key]
        public int TrainRouteID { get; set; }  // Khóa chính

        [Required]
        [MaxLength(100)]
        public string TrainRouteName { get; set; }  // Tên tuyến đường

        // Navigation Property: Liên kết với bảng RouteStations để lưu danh sách các ga
        public ICollection<RouteStation> RouteStations { get; set; }

    }
}
