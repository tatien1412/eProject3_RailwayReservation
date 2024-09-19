using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class CashTransactionResponse
    {
        public int CashTransactionID { get; set; }
        public String DateOftransaction { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashRefunded { get; set; }

    }
}