using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories
{
    public class TrainRouteRepository : Repository<TrainRoute>
    {
        public TrainRouteRepository(ApplicationDbContext context) : base (context)
        { 
        }
    }
}
