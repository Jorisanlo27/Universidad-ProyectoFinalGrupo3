using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class AreasController : Controller
    {
        private readonly UniversidadContext _context;

        public AreasController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var universidadContext = _context.Areas.Include(a => a.IdAsignaturaNavigation).Include(a => a.IdDepartamentoNavigation);
            return View(await universidadContext.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Areas == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .Include(a => a.IdAsignaturaNavigation)
                .Include(a => a.IdDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura");
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,IdDepartamento,IdAsignatura,Nombre")] Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", area.IdAsignatura);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", area.IdDepartamento);
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Areas == null)
            {
                return NotFound();
            }

            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", area.IdAsignatura);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", area.IdDepartamento);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArea,IdDepartamento,IdAsignatura,Nombre")] Area area)
        {
            if (id != area.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.IdArea))
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
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", area.IdAsignatura);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", area.IdDepartamento);
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Areas == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .Include(a => a.IdAsignaturaNavigation)
                .Include(a => a.IdDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Areas == null)
            {
                return Problem("Entity set 'UniversidadContext.Areas'  is null.");
            }
            var area = await _context.Areas.FindAsync(id);
            if (area != null)
            {
                _context.Areas.Remove(area);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
          return (_context.Areas?.Any(e => e.IdArea == id)).GetValueOrDefault();
        }
    }
}
