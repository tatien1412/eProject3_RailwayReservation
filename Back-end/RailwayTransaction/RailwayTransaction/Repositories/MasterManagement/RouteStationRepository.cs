using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class RouteStationRepository : Repository<RouteStation>
    {
        public RouteStationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
