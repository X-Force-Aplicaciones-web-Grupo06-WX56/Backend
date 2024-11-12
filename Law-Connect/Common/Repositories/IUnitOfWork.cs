using System.Threading.Tasks;

namespace Law_Connect.Common.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
