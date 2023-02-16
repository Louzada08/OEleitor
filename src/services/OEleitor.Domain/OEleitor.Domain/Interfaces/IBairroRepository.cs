using OEleitor.Domain.Entities;
using OEleitor.Infra.CrossCurtting.Data;

namespace OEleitor.Domain.Interfaces
{
    public interface IBairroRepository : IBaseRepository<Bairro>
    {
        //Task<PagedResult<BairroDto>> ObterTodos(int pageSize, int pageIndex, string query = null);
    }
}
