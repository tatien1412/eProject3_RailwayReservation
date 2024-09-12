using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories
{
    public class TicketRepository : Repository<Ticket>
    {
        public TicketRepository(ApplicationDbContext context) : base (context)
        { 
        }
    }
}
