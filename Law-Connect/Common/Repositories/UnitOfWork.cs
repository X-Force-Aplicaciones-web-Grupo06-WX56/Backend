using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Law_Connect.Common.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
