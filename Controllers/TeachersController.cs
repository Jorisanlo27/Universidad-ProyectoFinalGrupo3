using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        private readonly UniversidadContext _context;

        public TeachersController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var universidadContext = _context.Profesores.Include(p => p.IdPersonaNavigation);
            return View(await universidadContext.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,IdPersona")] Profesore profesore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", profesore.IdPersona);
            return View(profesore);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", profesore.IdPersona);
            return View(profesore);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,IdPersona")] Profesore profesore)
        {
            if (id != profesore.IdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoreExists(profesore.IdProfesor))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", profesore.IdPersona);
            return View(profesore);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesores == null)
            {
                return Problem("Entity set 'UniversidadContext.Profesores'  is null.");
            }
            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore != null)
            {
                _context.Profesores.Remove(profesore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoreExists(int id)
        {
          return (_context.Profesores?.Any(e => e.IdProfesor == id)).GetValueOrDefault();
        }
    }
}
