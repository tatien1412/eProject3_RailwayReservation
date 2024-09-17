using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class TicketRepository : Repository<Ticket>
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
