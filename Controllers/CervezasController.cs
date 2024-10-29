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
    public class CervezasController : Controller
    {
        private readonly MSMA_ProyectoContext _context;

        public CervezasController(MSMA_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Cervezas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cervezas.ToListAsync());
        }

        // GET: Cervezas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cervezas = await _context.Cervezas
                .FirstOrDefaultAsync(m => m.IDCerveza == id);
            if (cervezas == null)
            {
                return NotFound();
            }

            return View(cervezas);
        }

        // GET: Cervezas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cervezas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCerveza,Nombre,Tamaño,AVC")] Cervezas cervezas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cervezas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cervezas);
        }

        // GET: Cervezas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cervezas = await _context.Cervezas.FindAsync(id);
            if (cervezas == null)
            {
                return NotFound();
            }
            return View(cervezas);
        }

        // POST: Cervezas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCerveza,Nombre,Tamaño,AVC")] Cervezas cervezas)
        {
            if (id != cervezas.IDCerveza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cervezas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CervezasExists(cervezas.IDCerveza))
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
            return View(cervezas);
        }

        // GET: Cervezas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cervezas = await _context.Cervezas
                .FirstOrDefaultAsync(m => m.IDCerveza == id);
            if (cervezas == null)
            {
                return NotFound();
            }

            return View(cervezas);
        }

        // POST: Cervezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cervezas = await _context.Cervezas.FindAsync(id);
            if (cervezas != null)
            {
                _context.Cervezas.Remove(cervezas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CervezasExists(int id)
        {
            return _context.Cervezas.Any(e => e.IDCerveza == id);
        }
    }
}
