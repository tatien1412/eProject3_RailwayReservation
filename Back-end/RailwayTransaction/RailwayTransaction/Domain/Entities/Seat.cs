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

        [MaxLength(50)]
        public string SeatType { get; set; }  // Loại ghế (ví dụ: Ghế mềm, Ghế cứng)

        public decimal Fare { get; set; }  // Giá vé, được tính dựa trên loại ghế, khoang và khoảng cách

        // Khóa ngoại đến bảng Reservation
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
    }
}
