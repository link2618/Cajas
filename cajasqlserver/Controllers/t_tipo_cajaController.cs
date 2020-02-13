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
    public class t_tipo_cajaController : Controller
    {
        private readonly DbContexto _context;

        public t_tipo_cajaController(DbContexto context)
        {
            _context = context;
        }

        // GET: t_tipo_caja
        public async Task<IActionResult> Index()
        {
            return View(await _context.ttipocaja.ToListAsync());
        }

        // GET: t_tipo_caja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_tipo_caja = await _context.ttipocaja
                .FirstOrDefaultAsync(m => m.idtipocaja == id);
            if (t_tipo_caja == null)
            {
                return NotFound();
            }

            return View(t_tipo_caja);
        }

        // GET: t_tipo_caja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: t_tipo_caja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idtipocaja,nombre")] t_tipo_caja t_tipo_caja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_tipo_caja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t_tipo_caja);
        }

        // GET: t_tipo_caja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_tipo_caja = await _context.ttipocaja.FindAsync(id);
            if (t_tipo_caja == null)
            {
                return NotFound();
            }
            return View(t_tipo_caja);
        }

        // POST: t_tipo_caja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idtipocaja,nombre")] t_tipo_caja t_tipo_caja)
        {
            if (id != t_tipo_caja.idtipocaja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_tipo_caja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!t_tipo_cajaExists(t_tipo_caja.idtipocaja))
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
            return View(t_tipo_caja);
        }

        // GET: t_tipo_caja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_tipo_caja = await _context.ttipocaja
                .FirstOrDefaultAsync(m => m.idtipocaja == id);
            if (t_tipo_caja == null)
            {
                return NotFound();
            }

            return View(t_tipo_caja);
        }

        // POST: t_tipo_caja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t_tipo_caja = await _context.ttipocaja.FindAsync(id);
            _context.ttipocaja.Remove(t_tipo_caja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool t_tipo_cajaExists(int id)
        {
            return _context.ttipocaja.Any(e => e.idtipocaja == id);
        }
    }
}
