using Microsoft.EntityFrameworkCore;
using Law_Connect.Notifications.Domain.Entities;
using Law_Connect.Notifications.Domain.ValueObjects;

namespace Law_Connect.Notifications.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
