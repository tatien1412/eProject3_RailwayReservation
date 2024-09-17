using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class ReservationRepository : Repository<Reservation>
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
