﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UniversidadContext _context;

        public StudentsController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var universidadContext = _context.Estudiantes.Include(e => e.IdCarreraNavigation).Include(e => e.IdPersonaNavigation);
            return View(await universidadContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.IdCarreraNavigation)
                .Include(e => e.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiantes == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera");
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiantes,IdPersona,IdCarrera")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", estudiante.IdCarrera);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", estudiante.IdPersona);
            return View(estudiante);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", estudiante.IdCarrera);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", estudiante.IdPersona);
            return View(estudiante);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiantes,IdPersona,IdCarrera")] Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiantes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.IdEstudiantes))
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
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", estudiante.IdCarrera);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", estudiante.IdPersona);
            return View(estudiante);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.IdCarreraNavigation)
                .Include(e => e.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiantes == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudiantes == null)
            {
                return Problem("Entity set 'UniversidadContext.Estudiantes'  is null.");
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
          return (_context.Estudiantes?.Any(e => e.IdEstudiantes == id)).GetValueOrDefault();
        }
    }
}