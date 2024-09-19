using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class TrainRouteRepository : Repository<TrainRoute, int>
    {
        public TrainRouteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
