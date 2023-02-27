using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OEleitor.WebApp.MVC.Filtros;
using OEleitor.WebApp.MVC.Models;
using OEleitor.WebApp.MVC.Services;

namespace OEleitor.WebApp.MVC.Controllers
{
    [Authorize]
    public class BairroController : MainController
    {
        private readonly IBairroService _bairroService;

        public BairroController(IBairroService bairroService)
        {
            _bairroService= bairroService;
        }

        [HttpGet]
        [Route("bairros")]
        public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] BairroQueryFiltro q = null)
        {
            var bairros = await _bairroService.ObterTodosBairros(ps, page, q.NomeBairro);
            ViewBag.Pesquisa = q;
            bairros.ReferenceAction = "Index";

            return View(bairros);
        }


        // GET: BairroViewModels/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairroViewModel = await _bairroService.ObterPorId(id);
            if (bairroViewModel == null)
            {
                return NotFound();
            }

            return View(bairroViewModel);
        }

        // GET: Bairro/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NovoBairro(BairroViewModel bairro)
        {
            var response = await _bairroService.AdicionarBairro(bairro);

            if (ResponsePossuiErros(response)) TempData["Erros"] =
                ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("Index", "Bairros");
        }


        //// POST: BairroViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Bairros == null)
        //    {
        //        return Problem("Entity set 'OEleitorWebAppMVCContext.BairroViewModel'  is null.");
        //    }
        //    var bairroViewModel = await _context.Bairros.FindAsync(id);
        //    if (bairroViewModel != null)
        //    {
        //        _context.Bairros.Remove(bairroViewModel);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BairroViewModelExists(Guid id)
        //{
        //  return _context.Bairros.Any(e => e.Id == id);
        //}
    }
}
