using RailwayTransaction.Domain.Entities.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [ForeignKey("Trip")]
        public int TripID { get; set; }
        public Trip Trip { get; set; }

        [ForeignKey("Ticket")]
        public int PnrNo { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime DateOfJourney { get; set; }

        // Thông tin về các ga đi và đến đã được loại bỏ vì lưu trong bảng Trip
        public decimal TotalFare { get; set; }  // Tổng tiền vé

        // Navigation property: Một vé có thể đặt nhiều ghế
        public ICollection<Seat> Seats { get; set; }
    }
}
