using Microsoft.EntityFrameworkCore;
using WatchAppApi.Models;

namespace WatchAppApi.Data
{
    public class WatchAppDbContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; }

        public WatchAppDbContext(DbContextOptions<WatchAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Watch>(watch =>
            {
                watch.OwnsMany(entity => entity.Photos);
                watch.OwnsMany(entity => entity.ServiceRecords);
                watch.OwnsMany(entity => entity.BatteryReplacements);
            });
        }
    }
}
