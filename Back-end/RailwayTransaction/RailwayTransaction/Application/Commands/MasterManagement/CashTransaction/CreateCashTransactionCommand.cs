using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.CashTransaction
{
    public class CreateCashTransactionCommand : IRequest<int>
    {
        public string DateOftransaction { get; set; }
        public decimal Cashreceived { get; set; }
        public decimal CashRefunded { get; set; }
    }
}
