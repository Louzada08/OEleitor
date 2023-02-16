using OEleitor.Domain.Dtos;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Filtros;
using System.Threading.Tasks;

namespace OEleitor.Application.Query.Interface
{
    public interface IBairroQuery
    {
        Task<PagedResult<BairroDto>> ObterPaginadoTodos(int pageSize, int pageIndex, BairroQueryFiltro query = null);
    }
}
