using MediatR;
using RailwayTransaction.Application.Queries.MasterManagement.CashTransaction;
using RailwayTransaction.Application.Queries.Staff.Booking;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.Staff
{
    public class DailyCashHandler : IRequestHandler<DailyCashQuery, Domain.Entities.Dtos.Response.dependent.DailyCash_joined>
    {

        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;
        private readonly IRepository<Domain.Entities.Schedule, int> _scheduleRepository;
        public DailyCashHandler(IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository
            , IRepository<Domain.Entities.Schedule, int> scheduleRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.DailyCash_joined> Handle(DailyCashQuery request, CancellationToken cancellationToken)
        {
            var cashTransaction = await _cashTransactionRepository.GetAllAsync();
            var schedule = await _scheduleRepository.GetAllAsync();
            var dow = schedule.FirstOrDefault(s => s.DateOfTravel == request.DateOfTravel);
            var res =CashTransactionMapper.ConvertToDailyResponse( cashTransaction.FirstOrDefault(ct => ct.DateOftransaction == request.DateOfTravel),dow);
            if (cashTransaction == null)
            {
                throw new Exception("DailyCash not found");
            }
            return res;
        }

    }
}
