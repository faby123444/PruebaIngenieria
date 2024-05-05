using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaIngenieria.Models;

namespace PruebaIngenieria.Controllers
{
    public class CalificacionsController : Controller
    {
        private readonly IngenieriaWebContext _context;

        public CalificacionsController(IngenieriaWebContext context)
        {
            _context = context;
        }

        // GET: Calificacions
        public async Task<IActionResult> Index()
        {
            var ingenieriaWebContext = _context.Calificacions.Include(c => c.Semestre);
            return View(await ingenieriaWebContext.ToListAsync());
        }

        // GET: Calificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacions
                .Include(c => c.Semestre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // GET: Calificacions/Create
        public IActionResult Create()
        {
            ViewData["SemestreId"] = new SelectList(_context.Semestres, "Id", "Id");
            return View();
        }

        // POST: Calificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nota1,Nota2,Nota3,NotaFinal,SemestreId")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SemestreId"] = new SelectList(_context.Semestres, "Id", "Id", calificacion.SemestreId);
            return View(calificacion);
        }

        // GET: Calificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["SemestreId"] = new SelectList(_context.Semestres, "Id", "Id", calificacion.SemestreId);
            return View(calificacion);
        }

        // POST: Calificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nota1,Nota2,Nota3,NotaFinal,SemestreId")] Calificacion calificacion)
        {
            if (id != calificacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionExists(calificacion.Id))
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
            ViewData["SemestreId"] = new SelectList(_context.Semestres, "Id", "Id", calificacion.SemestreId);
            return View(calificacion);
        }

        // GET: Calificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacions
                .Include(c => c.Semestre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: Calificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.Calificacions.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificacions.Remove(calificacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificacions.Any(e => e.Id == id);
        }
    }
}
