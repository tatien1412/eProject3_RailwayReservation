using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Data.DataContext;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Repositories.MasterManagement
{
    public class ScheduleRepository : Repository<Schedule, int>
    {
        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    //public class ScheduleRepository : IRepository<Schedule, int>
    //{
    //    private readonly ApplicationDbContext _context;

    //    public ScheduleRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Schedule> GetByIdAsync(int id)
    //    {
    //        return await _context.Schedules.FindAsync(id);
    //    }

    //    public async Task<IEnumerable<Schedule>> GetAllAsync()
    //    {
    //        return await _context.Schedules.ToListAsync();
    //    }

    //    public async Task<Schedule> AddAsync(Schedule entity)
    //    {

    //        var result = await _context.Schedules.AddAsync(entity);
    //        await _context.SaveChangesAsync();
    //        return result.Entity;
    //    }

    //    public async Task UpdateAsync(Schedule entity)
    //    {
    //        _context.Schedules.Update(entity);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeleteAsync(Schedule entity)
    //    {
    //        _context.Schedules.Remove(entity);
    //        await _context.SaveChangesAsync();
    //    }
    //}
}
