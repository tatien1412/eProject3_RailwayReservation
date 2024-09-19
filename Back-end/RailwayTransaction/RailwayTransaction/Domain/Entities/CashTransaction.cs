using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities
{
    public class CashTransaction
    {
        [Key]
        public int CashTransactionID { get; set; }
        public String DateOftransaction { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashRefunded { get; set; } 

        public ICollection<Reservation> Reservations { get; set; }
    }
}
