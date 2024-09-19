using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.CashTransaction
{
    public class GetCashTransactionByIdQuery : IRequest<Domain.Entities.Dtos.Response.independent.CashTransactionResponse>
    {
        public int CashTransactionID { get; set; }

        public GetCashTransactionByIdQuery(int cashTransactionID)
        {
            CashTransactionID = cashTransactionID;
        }
    }
}
