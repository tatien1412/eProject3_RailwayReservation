using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.CashTransaction;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;
using System.Diagnostics;


namespace RailwayTransaction.Handler.MasterManagement.CashTransaction
{
    public class GetCashTransactionByIdQueryHandler : IRequestHandler<GetCashTransactionByIdQuery, Domain.Entities.Dtos.Response.independent.CashTransactionResponse>
    {
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public GetCashTransactionByIdQueryHandler(IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.independent.CashTransactionResponse> Handle(GetCashTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var cashTransaction = await _cashTransactionRepository.GetByIdAsync(request.CashTransactionID);

            if (cashTransaction == null)
            {
                throw new Exception("Trip not found");
            }
            return CashTransactionMapper.ConvertToResponse(cashTransaction);
        }
    }
}
