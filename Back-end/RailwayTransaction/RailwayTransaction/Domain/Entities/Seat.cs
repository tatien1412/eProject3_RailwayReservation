using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; }

        [ForeignKey("Compartment")]
        public int CompartmentID { get; set; }
        public Compartment Compartment { get; set; }

        [MaxLength(10)]
        public string SeatNumber { get; set; }

        [MaxLength(20)]
        public string SeatStatus { get; set; }

        public decimal Fare { get; set; }

        // Khóa ngoại đến bảng Reservation, cho phép null
        [ForeignKey("Reservation")]


        public Reservation? Reservation { get; set; }  // Cũng cần nullable ở đây
    }
}
