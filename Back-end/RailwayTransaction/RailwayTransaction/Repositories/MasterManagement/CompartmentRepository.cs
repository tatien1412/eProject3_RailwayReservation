using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class CompartmentRepository : Repository<Compartment>
    {
        public CompartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
