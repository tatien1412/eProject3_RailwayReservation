using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Repositories
{
    public class UsersRepository : IRepository<AppUser, string>
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
        public async Task<AppUser> AddAsync(AppUser entity)
        {
            var result = await _context.Users.AddAsync(entity);  
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task UpdateAsync(AppUser entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(AppUser entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
