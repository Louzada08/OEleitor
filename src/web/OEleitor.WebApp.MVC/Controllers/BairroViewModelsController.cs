using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OEleitor.WebApp.MVC.Data;
using OEleitor.WebApp.MVC.Models;
using OEleitor.WebApp.MVC.Services;

namespace OEleitor.WebApp.MVC.Controllers
{
    [Authorize]
    public class BairroViewModelsController : MainController
    {
        private readonly OEleitorWebAppMVCContext _context;
        private readonly IBairroService _bairroService;

        public BairroViewModelsController(OEleitorWebAppMVCContext context, IBairroService bairroService)
        {
            _context = context;
            _bairroService= bairroService;
        }

        // GET: BairroViewModels
        [HttpGet]
        [Route("")]
        [Route("bairros")]
        public async Task<IActionResult> Index()
        {
              return View(await _bairroService.ObterTodosBairros());
        }

        // GET: BairroViewModels/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Bairros == null)
            {
                return NotFound();
            }

            var bairroViewModel = await _context.Bairros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bairroViewModel == null)
            {
                return NotFound();
            }

            return View(bairroViewModel);
        }

        // GET: BairroViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BairroViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BairroNome")] BairroViewModel bairroViewModel)
        {
            if (ModelState.IsValid)
            {
                bairroViewModel.Id = Guid.NewGuid();
                _context.Add(bairroViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bairroViewModel);
        }

        // GET: BairroViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Bairros == null)
            {
                return NotFound();
            }

            var bairroViewModel = await _context.Bairros.FindAsync(id);
            if (bairroViewModel == null)
            {
                return NotFound();
            }
            return View(bairroViewModel);
        }

        // POST: BairroViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BairroNome")] BairroViewModel bairroViewModel)
        {
            if (id != bairroViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bairroViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BairroViewModelExists(bairroViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bairroViewModel);
        }

        // GET: BairroViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Bairros == null)
            {
                return NotFound();
            }

            var bairroViewModel = await _context.Bairros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bairroViewModel == null)
            {
                return NotFound();
            }

            return View(bairroViewModel);
        }

        // POST: BairroViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Bairros == null)
            {
                return Problem("Entity set 'OEleitorWebAppMVCContext.BairroViewModel'  is null.");
            }
            var bairroViewModel = await _context.Bairros.FindAsync(id);
            if (bairroViewModel != null)
            {
                _context.Bairros.Remove(bairroViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BairroViewModelExists(Guid id)
        {
          return _context.Bairros.Any(e => e.Id == id);
        }
    }
}
