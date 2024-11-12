using Microsoft.EntityFrameworkCore;
using Law_Connect.IAM.Domain.Aggregates;
using Law_Connect.IAM.Domain.Entities;

namespace Law_Connect.IAM.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAudit> UserAudits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
