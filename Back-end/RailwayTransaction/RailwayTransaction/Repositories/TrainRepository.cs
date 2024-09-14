using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Repositories
{
    public class TrainRepository : Repository<Train>
    {
        public TrainRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    //    public class TrainRepository : IRepository<Train, int>
    //    {
    //        private readonly  ApplicationDbContext _context;
    //        public TrainRepository(ApplicationDbContext context)
    //        {
    //            _context = context;
    //        }
    //        public async Task<Train> GetByIdAsync(int id)
    //        {
    //            return await _context.Trains.FindAsync(id);
    //        }
    //        public async Task<IEnumerable<Train>> GetAllAsync()
    //        {
    //            return await _context.Trains.ToListAsync();
    //        }
    //        public async Task<Train> AddAsync(Train entity)
    //        {
    //            var result = await _context.Trains.AddAsync(entity);
    //            await _context.SaveChangesAsync();
    //            return result.Entity;
    //        }
    //        public async Task UpdateAsync(Train entity)
    //        {
    //            _context.Trains.Update(entity);
    //            await _context.SaveChangesAsync();
    //        }
    //        public async Task DeleteAsync(Train entity)
    //        {
    //            _context.Trains.Remove(entity);
    //            await _context.SaveChangesAsync();
    //        }
    //    }
}
