using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class TripRepository : Repository<Trip>
    {
        public TripRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
