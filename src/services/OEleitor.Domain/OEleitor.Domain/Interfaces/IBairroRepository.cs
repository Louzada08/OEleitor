using OEleitor.Domain.Entities;
using OEleitor.Infra.CrossCurtting.Data;
using System.Threading.Tasks;

namespace OEleitor.Domain.Interfaces
{
    public interface IBairroRepository : IBaseRepository<Bairro>
    {
        Task<PagedResult<Bairro>> ObterTodos(int pageSize, int pageIndex, string query = null);
    }
}
