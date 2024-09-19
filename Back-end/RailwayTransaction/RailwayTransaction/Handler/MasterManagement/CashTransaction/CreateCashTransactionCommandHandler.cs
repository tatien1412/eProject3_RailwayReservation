using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.CashTransaction;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.CashTransaction
{
    public class CreateCashTransactionCommandHandler : IRequestHandler<CreateCashTransactionCommand, int>
    {
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public CreateCashTransactionCommandHandler(IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
        }

        public async Task<int> Handle(CreateCashTransactionCommand request, CancellationToken cancellationToken)
        {
            var cashTransaction = new Domain.Entities.CashTransaction
            {
                CashReceived = request.Cashreceived,
                CashRefunded = request.CashRefunded,
                DateOftransaction = request.DateOftransaction,
            };

            await _cashTransactionRepository.AddAsync(cashTransaction);

            return cashTransaction.CashTransactionID;
        }
    }
}
