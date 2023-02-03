using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public interface IBairroService
    { 
        Task<IEnumerable<BairroViewModel>> ObterTodosBairros();
       // Task<ResponseResult> AdicionarItemCarrinho(ItemProdutoViewModel produto);
       // Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
       // Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
    }
}