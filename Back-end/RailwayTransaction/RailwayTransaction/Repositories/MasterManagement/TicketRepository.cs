using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class TicketRepository : Repository<Ticket, int>
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
