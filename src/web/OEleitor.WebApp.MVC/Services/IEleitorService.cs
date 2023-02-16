using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public interface IEleitorService
    {
        Task<PagedViewModel<EleitorViewModel>> ObterTodosEleitores(int pageSize, int pageIndex, string query = null);
        Task<ResponseResult> AdicionarEleitor(EleitorViewModel eleitor);
    }
}
