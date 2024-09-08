using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Repositories
{
    public class StationRepository : IRepository<Station, int>
    {
        private readonly ApplicationDbContext _context;

        public StationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Station> GetByIdAsync(int id)
        {
            return await _context.Stations.FindAsync(id);
        }

        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station> AddAsync(Station entity)
        {
            var result = await _context.Stations.AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task UpdateAsync(Station entity)
        {
            _context.Stations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Station entity)
        {
            _context.Stations.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
