using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories
{
    public class RouteStationRepository : Repository<RouteStation>
    {
        public RouteStationRepository(ApplicationDbContext context) : base (context)
        { 
        }
    }
}
