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
    public class CoctelesController : Controller
    {
        private readonly MSMA_ProyectoContext _context;

        public CoctelesController(MSMA_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Cocteles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cocteles.ToListAsync());
        }

        // GET: Cocteles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocteles = await _context.Cocteles
                .FirstOrDefaultAsync(m => m.IDCocteles == id);
            if (cocteles == null)
            {
                return NotFound();
            }

            return View(cocteles);
        }

        // GET: Cocteles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocteles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCocteles,Coctel,Descripción,Precio_Coctel")] Cocteles cocteles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cocteles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cocteles);
        }

        // GET: Cocteles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocteles = await _context.Cocteles.FindAsync(id);
            if (cocteles == null)
            {
                return NotFound();
            }
            return View(cocteles);
        }

        // POST: Cocteles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCocteles,Coctel,Descripción,Precio_Coctel")] Cocteles cocteles)
        {
            if (id != cocteles.IDCocteles)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cocteles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoctelesExists(cocteles.IDCocteles))
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
            return View(cocteles);
        }

        // GET: Cocteles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocteles = await _context.Cocteles
                .FirstOrDefaultAsync(m => m.IDCocteles == id);
            if (cocteles == null)
            {
                return NotFound();
            }

            return View(cocteles);
        }

        // POST: Cocteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cocteles = await _context.Cocteles.FindAsync(id);
            if (cocteles != null)
            {
                _context.Cocteles.Remove(cocteles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoctelesExists(int id)
        {
            return _context.Cocteles.Any(e => e.IDCocteles == id);
        }
    }
}
