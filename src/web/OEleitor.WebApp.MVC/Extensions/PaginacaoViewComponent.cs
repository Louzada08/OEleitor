using Microsoft.AspNetCore.Mvc;
using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Extensions
{
    public class PaginacaoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList modeloPaginado)
        {
            return View(modeloPaginado);
        }
    }
}