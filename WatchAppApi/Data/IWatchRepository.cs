using Microsoft.EntityFrameworkCore;
using WatchAppApi.Models;

namespace WatchAppApi.Data
{
    public interface IWatchRepository
    {
        Task<List<Watch>> GetAllAsync();
        Task<Watch?> GetByIdAsync(int id);
        Task<Watch> CreateAsync(Watch watch);
        Task<bool> UpdateAsync(int id, Watch watch);
        Task<bool> DeleteAsync(int id);
    }

    public class WatchRepository : IWatchRepository
    {
        private readonly WatchAppDbContext _context;

        public WatchRepository(WatchAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Watch>> GetAllAsync()
        {
            return await _context.Watches
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Watch?> GetByIdAsync(int id)
        {
            return await _context.Watches
                .AsNoTracking()
                .FirstOrDefaultAsync(watch => watch.Id == id);
        }

        public async Task<Watch> CreateAsync(Watch watch)
        {
            _context.Watches.Add(watch);
            await _context.SaveChangesAsync();

            return watch;
        }

        public async Task<bool> UpdateAsync(int id, Watch watch)
        {
            var existingWatch = await _context.Watches
                .Include(existing => existing.Photos)
                .Include(existing => existing.ServiceRecords)
                .Include(existing => existing.BatteryReplacements)
                .FirstOrDefaultAsync(existing => existing.Id == id);

            if (existingWatch is null)
            {
                return false;
            }

            _context.Entry(existingWatch).CurrentValues.SetValues(watch);
            existingWatch.Photos = watch.Photos;
            existingWatch.ServiceRecords = watch.ServiceRecords;
            existingWatch.BatteryReplacements = watch.BatteryReplacements;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var watch = await _context.Watches.FindAsync(id);

            if (watch is null)
            {
                return false;
            }

            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
