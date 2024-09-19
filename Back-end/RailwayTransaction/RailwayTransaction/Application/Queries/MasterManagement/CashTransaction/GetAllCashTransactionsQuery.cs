using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.CashTransaction
{
    public class GetAllCashTransactionsQuery : IRequest<List<Domain.Entities.Dtos.Response.independent.CashTransactionResponse>>
    {
    }
}
