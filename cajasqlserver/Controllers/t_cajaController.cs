using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cajasqlserver.Models;

namespace cajasqlserver.Controllers
{
    public class t_cajaController : Controller
    {
        private readonly DbContexto _context;

        public t_cajaController(DbContexto context)
        {
            _context = context;
        }

        // GET: t_caja
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.tcaja.Include(t => t.rtipocaja);
            return View(await dbContexto.ToListAsync());
        }

        // GET: t_caja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_caja = await _context.tcaja
                .Include(t => t.rtipocaja)
                .FirstOrDefaultAsync(m => m.idtcaja == id);
            if (t_caja == null)
            {
                return NotFound();
            }

            return View(t_caja);
        }

        // GET: t_caja/Create
        public IActionResult Create()
        {
            ViewData["tipo"] = new SelectList(_context.ttipocaja, "idtipocaja", "nombre");
            return View();
        }

        // POST: t_caja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idtcaja,fecha_registro,fecha_cierre,usuario,anio,tipo")] t_caja t_caja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_caja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipo"] = new SelectList(_context.ttipocaja, "idtipocaja", "nombre", t_caja.tipo);
            return View(t_caja);
        }

        // GET: t_caja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_caja = await _context.tcaja.FindAsync(id);
            if (t_caja == null)
            {
                return NotFound();
            }
            ViewData["tipo"] = new SelectList(_context.ttipocaja, "idtipocaja", "nombre", t_caja.tipo);
            return View(t_caja);
        }

        // POST: t_caja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idtcaja,fecha_registro,fecha_cierre,usuario,anio,tipo")] t_caja t_caja)
        {
            if (id != t_caja.idtcaja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_caja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!t_cajaExists(t_caja.idtcaja))
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
            ViewData["tipo"] = new SelectList(_context.ttipocaja, "idtipocaja", "nombre", t_caja.tipo);
            return View(t_caja);
        }

        // GET: t_caja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_caja = await _context.tcaja
                .Include(t => t.rtipocaja)
                .FirstOrDefaultAsync(m => m.idtcaja == id);
            if (t_caja == null)
            {
                return NotFound();
            }

            return View(t_caja);
        }

        // POST: t_caja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t_caja = await _context.tcaja.FindAsync(id);
            _context.tcaja.Remove(t_caja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool t_cajaExists(int id)
        {
            return _context.tcaja.Any(e => e.idtcaja == id);
        }
    }
}
