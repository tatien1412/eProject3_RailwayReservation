using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.CashTransaction;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.CashTransaction
{
    public class GetAllCashTransactionsQueryHandler : IRequestHandler<GetAllCashTransactionsQuery, List<Domain.Entities.Dtos.Response.independent.CashTransactionResponse>>
    {
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public GetAllCashTransactionsQueryHandler(IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
        }
        
        public async Task<List<Domain.Entities.Dtos.Response.independent.CashTransactionResponse>> Handle(GetAllCashTransactionsQuery request, CancellationToken cancellationToken)
        {
            // Chuyển đổi IEnumerable<Trip> thành List<Trip>
            return (await _cashTransactionRepository.GetAllAsync()).Select(c => CashTransactionMapper.ConvertToResponse(c)).ToList();
        }
    }
}
