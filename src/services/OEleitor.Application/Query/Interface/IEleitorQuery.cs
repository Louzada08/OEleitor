using OEleitor.Domain.Dtos;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Filtros;
using System.Threading.Tasks;

namespace OEleitor.Application.Query.Interface
{
    public interface IEleitorQuery
    {
        Task<PagedResult<EleitorDto>> ObterPaginadoTodos(int pageSize, int pageIndex, EleitorQueryFiltro query = null);
    }
}
