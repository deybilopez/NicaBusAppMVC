using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Configuration;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Controllers
{
    public class RutasController : Controller
    {
        private readonly NicaBusMVCContext _context;
        private readonly IUnidOfWork _unitOfWork;

        public RutasController(NicaBusMVCContext context, IUnidOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Rutas
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.UserRepository.GetAllAsync());
        }

        // GET: Rutas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ruta = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // GET: Rutas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ubicacion,Destino")] Ruta ruta)
        {
            _unitOfWork.RutaRepository.Add(ruta);
            _unitOfWork.commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: Rutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ruta == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // POST: Rutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ubicacion,Destino")] Ruta ruta)
        {
            if (id != ruta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutaExists(ruta.Id))
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
            return View(ruta);
        }

        // GET: Rutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ruta == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ruta == null)
            {
                return Problem("Entity set 'NicaBusMVCContext.Ruta'  is null.");
            }
            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta != null)
            {
                _context.Ruta.Remove(ruta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutaExists(int id)
        {
            return _context.Ruta.Any(e => e.Id == id);
        }
    }
}
