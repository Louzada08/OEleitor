using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public interface IEleitorService
    {
        Task<PagedViewModel<EleitorViewModel>> ObterTodosEleitores(int pageSize, int pageIndex, string query = null);
        Task<EleitorViewModel> ObterPorId(Guid? eleitorId);
        Task<ResponseResult> AdicionarEleitor(EleitorViewModel eleitor);
    }
}
