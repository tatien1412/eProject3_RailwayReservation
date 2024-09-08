using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Repositories
{
    public class FareRepository : IRepository<Fare, int>
    {
        private readonly ApplicationDbContext _context;

        public FareRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fare> GetByIdAsync(int id)
        {
            return await _context.Fares.FindAsync(id);
        }

        public async Task<IEnumerable<Fare>> GetAllAsync()
        {
            return await _context.Fares.ToListAsync();
        }

        public async Task<Fare> AddAsync(Fare entity)
        {
            var result = await _context.Fares.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(Fare entity)
        {
            _context.Fares.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Fare entity)
        {
            _context.Fares.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
