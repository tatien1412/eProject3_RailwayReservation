using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class Compartment
    {
        [Key]
        public int CompartmentID { get; set; }

        [ForeignKey("Train")]
        public int TrainID { get; set; }
        public Train Train { get; set; }

        [MaxLength(50)]
        [RegularExpression("^(AC1|AC2|AC3)$", ErrorMessage = "CompartmentType must be either 'AC1', 'AC2', or 'AC3'")]
        public string CompartmentType { get; set; }  // Loại khoang (ví dụ: Thường, Cao cấp)

        [MaxLength(50)]
        [RegularExpression("^(General|Sleep)$", ErrorMessage = "SeatType must be either 'General' or 'Sleep'")]
        public string SeatType { get; set; }  // Loại ghế (ví dụ: Ghế mềm, Ghế cứng)
        public int NumberOfSeats { get; set; }

        // Navigation Properties
        public ICollection<Seat> Seats { get; set; }
    }
}
