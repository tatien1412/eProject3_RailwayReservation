using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class Station
    {
        [Key]
        public int StationID { get; set; }  // Khóa chính

        [Required]
        [MaxLength(10)]
        public string StationCode { get; set; }  // Mã ga

        [Required]
        [MaxLength(100)]
        public string StationName { get; set; }  // Tên ga

        [MaxLength(100)]
        public string RailwayDivisionName { get; set; }  // Tên đơn vị quản lý

        // Navigation Property: Một ga có thể thuộc nhiều tuyến đường
        public ICollection<RouteStation> RouteStations { get; set; }

    }
}
