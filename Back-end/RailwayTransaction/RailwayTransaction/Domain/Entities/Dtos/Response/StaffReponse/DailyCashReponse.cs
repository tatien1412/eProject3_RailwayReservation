namespace RailwayTransaction.Domain.Entities.Dtos.Response.StaffReponse
{
    public class DailyCashReponse
    {
        public int CashTransactionID { get; set; }
        public string DateOftransaction { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashRefunded { get; set; }
        public string DayOfWeek { get; set; }
    }
}
