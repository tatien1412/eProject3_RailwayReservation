using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Repositories
{
    public class Repository<T> : IRepository<T, int> where T : class
    {
        public readonly ApplicationDbContext _context;
        public readonly DbSet<T> _entity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            var result = await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);  
            await _context.SaveChangesAsync();
        }
    }
}
