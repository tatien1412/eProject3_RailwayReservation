using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities
{
    public class Train
    {
        [Key]
        public int TrainID { get; set; }  // Khóa chính

        [Required]
        [MaxLength(100)]
        public string TrainName { get; set; }

        [MaxLength(255)]
        public string TrainStatus { get; set; }

        public int NumberOfCompartments { get; set; }

        // Khóa ngoại đến bảng TrainRoute để xác định tuyến đường của tàu
        [ForeignKey("TrainRoute")]
        public int TrainRouteID { get; set; }
        public TrainRoute TrainRoute { get; set; }

        // Navigation Property: Một tàu có nhiều khoang
        public ICollection<Compartment> Compartments { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
