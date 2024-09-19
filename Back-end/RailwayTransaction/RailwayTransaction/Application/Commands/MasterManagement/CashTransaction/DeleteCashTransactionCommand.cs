using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.CashTransaction
{
    public class DeleteCashTransactionCommand : IRequest
    {
        public int CashTransactionID { get; set; }
    }
}
