using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
namespace Law_Connect.Shared.Infraestructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.AddCreatedUpdatedInterceptor();
        }


        // TODO
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        // }
    }
}
