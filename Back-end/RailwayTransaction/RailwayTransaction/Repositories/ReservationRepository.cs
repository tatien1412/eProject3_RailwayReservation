using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories
{
    public class ReservationRepository : Repository<Reservation>
    {
        public ReservationRepository(ApplicationDbContext context) : base (context)
        { 
        }
    }
}
