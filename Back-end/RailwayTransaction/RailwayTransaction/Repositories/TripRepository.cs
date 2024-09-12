using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories
{
    public class TripRepository : Repository<Trip>
    {
        public TripRepository(ApplicationDbContext context) : base (context)
        { 
        }
    }
}
