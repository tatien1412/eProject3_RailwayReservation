using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.CashTransaction;
using RailwayTransaction.Application.Commands.MasterManagement.Trip;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Trip
{
    public class DeleteCashTransactionCommandHandler : IRequestHandler<DeleteCashTransactionCommand>
    {
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public DeleteCashTransactionCommandHandler(IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
        }

        public async Task<Unit> Handle(DeleteCashTransactionCommand request, CancellationToken cancellationToken)
        {
            var cashTransaction = await _cashTransactionRepository.GetByIdAsync(request.CashTransactionID);

            if (cashTransaction == null)
            {
                throw new Exception("CashTransaction not found");
            }

            await _cashTransactionRepository.DeleteAsync(cashTransaction);

            return Unit.Value;
        }
    }
}
