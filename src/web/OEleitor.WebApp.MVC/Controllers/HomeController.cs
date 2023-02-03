using Microsoft.AspNetCore.Mvc;

namespace OEleitor.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
