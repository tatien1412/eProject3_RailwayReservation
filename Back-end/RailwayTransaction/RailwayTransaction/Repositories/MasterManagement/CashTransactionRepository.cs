using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class CashTransactionRepository : Repository<CashTransaction, int>
    {
        public CashTransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<CashTransaction> GetByDateAsync(string date)
        {
            return await _entity.Where(c => c.DateOftransaction.Equals(date)).FirstOrDefaultAsync();
        }
    }
}
