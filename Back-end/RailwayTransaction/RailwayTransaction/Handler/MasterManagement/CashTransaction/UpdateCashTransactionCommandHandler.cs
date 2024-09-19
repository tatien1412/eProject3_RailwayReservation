using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.CashTransaction;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.CashTransaction
{
    public class UpdateCashTransactionCommandHandler : IRequestHandler<UpdateCashTransactionCommand>
    {
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public UpdateCashTransactionCommandHandler(IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
        }

        public async Task<Unit> Handle(UpdateCashTransactionCommand request, CancellationToken cancellationToken)
        {
            var cashTransaction = await _cashTransactionRepository.GetByIdAsync(request.CashTransactionID);

            if (cashTransaction == null)
            {
                throw new Exception("Train not found");
            }

            cashTransaction.CashReceived = request.CashReceived;
            cashTransaction.CashRefunded = request.CashRefunded;
            cashTransaction.DateOftransaction = request.DateOftransaction;

            await _cashTransactionRepository.UpdateAsync(cashTransaction);

            return Unit.Value;
        }
    }
}
