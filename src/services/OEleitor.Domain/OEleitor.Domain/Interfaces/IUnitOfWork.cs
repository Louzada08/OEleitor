using System.Threading;
using System.Threading.Tasks;

namespace OEleitor.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
