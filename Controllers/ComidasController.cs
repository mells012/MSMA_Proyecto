using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSMA_Proyecto.Data;
using MSMA_Proyecto.Models;

namespace MSMA_Proyecto.Controllers
{
    public class ComidasController : Controller
    {
        private readonly MSMA_ProyectoContext _context;

        public ComidasController(MSMA_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Comidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comida.ToListAsync());
        }

        // GET: Comidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comida = await _context.Comida
                .FirstOrDefaultAsync(m => m.IDPlato == id);
            if (comida == null)
            {
                return NotFound();
            }

            return View(comida);
        }

        // GET: Comidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPlato,Plato,Descripción,Precio_Comida")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comida);
        }

        // GET: Comidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comida = await _context.Comida.FindAsync(id);
            if (comida == null)
            {
                return NotFound();
            }
            return View(comida);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPlato,Plato,Descripción,Precio_Comida")] Comida comida)
        {
            if (id != comida.IDPlato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComidaExists(comida.IDPlato))
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
            return View(comida);
        }

        // GET: Comidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comida = await _context.Comida
                .FirstOrDefaultAsync(m => m.IDPlato == id);
            if (comida == null)
            {
                return NotFound();
            }

            return View(comida);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comida = await _context.Comida.FindAsync(id);
            if (comida != null)
            {
                _context.Comida.Remove(comida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComidaExists(int id)
        {
            return _context.Comida.Any(e => e.IDPlato == id);
        }
    }
}
