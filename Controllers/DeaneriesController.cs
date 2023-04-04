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
	public class DeaneriesController : Controller
	{
		private readonly UniversidadContext _context;

		public DeaneriesController(UniversidadContext context)
		{
			_context = context;
		}

		// GET: Deaneries
		public async Task<IActionResult> Index()
		{
			var departamentos = _context.Departamentos
			.Include(d => d.Areas)
			.ThenInclude(d => d.Carreras)
			.ToListAsync();

			return departamentos != null ?
					  View(await departamentos) :
					  Problem("Entity set 'UniversidadContext.Departamentos'  is null.");
		}

		// GET: Deaneries/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Departamentos == null)
			{
				return NotFound();
			}

			var departamento = await _context.Departamentos
				.FirstOrDefaultAsync(m => m.IdDepartamento == id);
			if (departamento == null)
			{
				return NotFound();
			}

			return View(departamento);
		}

		// GET: Deaneries/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Deaneries/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdDepartamento,Nombre")] Departamento departamento)
		{
			if (ModelState.IsValid)
			{
				_context.Add(departamento);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(departamento);
		}

		// GET: Deaneries/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Departamentos == null)
			{
				return NotFound();
			}

			var departamento = await _context.Departamentos.FindAsync(id);
			if (departamento == null)
			{
				return NotFound();
			}
			return View(departamento);
		}

		// POST: Deaneries/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdDepartamento,Nombre")] Departamento departamento)
		{
			if (id != departamento.IdDepartamento)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(departamento);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!DepartamentoExists(departamento.IdDepartamento))
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
			return View(departamento);
		}

		// GET: Deaneries/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Departamentos == null)
			{
				return NotFound();
			}

			var departamento = await _context.Departamentos
				.FirstOrDefaultAsync(m => m.IdDepartamento == id);
			if (departamento == null)
			{
				return NotFound();
			}

			return View(departamento);
		}

		// POST: Deaneries/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Departamentos == null)
			{
				return Problem("Entity set 'UniversidadContext.Departamentos'  is null.");
			}
			var departamento = await _context.Departamentos.FindAsync(id);
			if (departamento != null)
			{
				_context.Departamentos.Remove(departamento);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DepartamentoExists(int id)
		{
			return (_context.Departamentos?.Any(e => e.IdDepartamento == id)).GetValueOrDefault();
		}
	}
}
