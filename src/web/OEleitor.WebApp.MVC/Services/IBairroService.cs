using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public interface IBairroService
    { 
        Task<PagedViewModel<BairroViewModel>> ObterTodosBairros(int pageSize, int pageIndex, string query = null);
        // Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
        Task<BairroViewModel> ObterPorId(Guid? bairroId);
        Task<ResponseResult> AdicionarBairro(BairroViewModel bairro);
    }
}