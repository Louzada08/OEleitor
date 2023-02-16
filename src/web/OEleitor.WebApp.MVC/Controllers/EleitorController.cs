using Microsoft.AspNetCore.Mvc;
using OEleitor.WebApp.MVC.Filtros;
using OEleitor.WebApp.MVC.Models;
using OEleitor.WebApp.MVC.Services;

namespace OEleitor.WebApp.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EleitorController : MainController
    {
        private readonly IEleitorService _eleitorService;

        public EleitorController(IEleitorService eleitorService)
        {
            _eleitorService = eleitorService;
        }

        // GET: BairroViewModels
        [HttpGet]
        [Route("eleitores")]
        public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] EleitorQueryFiltro q = null)
        {
            return View(await _eleitorService.ObterTodosEleitores(ps, page, q.Nome));
        }


        [HttpPost]
        public async Task<IActionResult> NovoEleitor(EleitorViewModel eleitor)
        {
            var response = await _eleitorService.AdicionarEleitor(eleitor);

            if (ResponsePossuiErros(response)) TempData["Erros"] =
                ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("Index", "Eleitores");
        }

        // GET: BairroViewModels/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.BairroViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    var bairroViewModel = await _context.BairroViewModel.FindAsync(id);
        //    if (bairroViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(bairroViewModel);
        //}

        // POST: BairroViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,BairroNome")] BairroViewModel bairroViewModel)
        //{
        //    if (id != bairroViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bairroViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BairroViewModelExists(bairroViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(bairroViewModel);
        //}

    }
}
