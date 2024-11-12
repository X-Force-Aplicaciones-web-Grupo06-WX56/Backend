using Microsoft.EntityFrameworkCore;
using Law_Connect.Payments.Domain.Entities;
using Law_Connect.Payments.Domain.ValueObjects;

namespace Law_Connect.Payments.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
