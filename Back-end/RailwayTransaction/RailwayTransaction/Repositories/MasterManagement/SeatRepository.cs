using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class SeatRepository : Repository<Seat>
    {
        public SeatRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
