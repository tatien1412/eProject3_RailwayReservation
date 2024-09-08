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
        public string CompartmentType { get; set; }  // Loại khoang (ví dụ: Thường, Cao cấp)

        public int NumberOfSeats { get; set; }

        // Navigation Properties
        public ICollection<Seat> Seats { get; set; }
    }
}
