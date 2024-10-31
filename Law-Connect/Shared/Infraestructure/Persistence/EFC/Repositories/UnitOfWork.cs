using Law_Connect.Shared.Infraestructure.Persistence.EFC.Configuration;

namespace Law_Connect.Shared.Infraestructure.Persistence.EFC.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
