using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class CashTransactionResponse_joined
    {
        public int CashTransactionID { get; set; }
        public String DateOftransaction { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashRefunded { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}