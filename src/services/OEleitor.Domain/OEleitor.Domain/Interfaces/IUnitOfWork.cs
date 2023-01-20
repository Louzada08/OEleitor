using System.Threading;
using System.Threading.Tasks;

namespace OEleitor.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        bool DatabaseExists();
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
