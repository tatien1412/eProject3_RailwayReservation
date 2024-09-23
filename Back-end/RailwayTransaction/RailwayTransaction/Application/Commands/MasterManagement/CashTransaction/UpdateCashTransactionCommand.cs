using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Application.Commands.MasterManagement.CashTransaction
{
    public class UpdateCashTransactionCommand : IRequest
    {
        public int CashTransactionID { get; set; }
        public String DateOftransaction { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashRefunded { get; set; }


    }
}
