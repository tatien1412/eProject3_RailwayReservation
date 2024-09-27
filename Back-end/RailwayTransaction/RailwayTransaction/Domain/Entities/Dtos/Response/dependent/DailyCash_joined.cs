namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class DailyCash_joined
    {
        public int CashTransactionID { get; set; }
        public String DateOftransaction { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashRefunded { get; set; }
        public string DayOfWeek { get; set; }
    }
}
