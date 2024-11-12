using Microsoft.EntityFrameworkCore;
using Law_Connect.Cases.Domain.Entities;
using Law_Connect.Cases.Domain.ValueObjects;

namespace Law_Connect.Cases.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseAssignment> CaseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
