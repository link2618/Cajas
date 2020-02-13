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
    public class t_carpetaController : Controller
    {
        private readonly DbContexto _context;

        public t_carpetaController(DbContexto context)
        {
            _context = context;
        }

        // GET: t_carpeta
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.tcarpeta.Include(t => t.rcaja);
            return View(await dbContexto.ToListAsync());
        }

        // GET: t_carpeta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_carpeta = await _context.tcarpeta
                .Include(t => t.rcaja)
                .FirstOrDefaultAsync(m => m.idcarpeta == id);
            if (t_carpeta == null)
            {
                return NotFound();
            }

            return View(t_carpeta);
        }

        // GET: t_carpeta/Create
        public IActionResult Create()
        {
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja");
            return View();
        }

        // POST: t_carpeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idcarpeta,nit,fecha_registro,fecha_cierre,caja")] t_carpeta t_carpeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_carpeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja", t_carpeta.caja);
            return View(t_carpeta);
        }

        // GET: t_carpeta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_carpeta = await _context.tcarpeta.FindAsync(id);
            if (t_carpeta == null)
            {
                return NotFound();
            }
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja", t_carpeta.caja);
            return View(t_carpeta);
        }

        // POST: t_carpeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idcarpeta,nit,fecha_registro,fecha_cierre,caja")] t_carpeta t_carpeta)
        {
            if (id != t_carpeta.idcarpeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_carpeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!t_carpetaExists(t_carpeta.idcarpeta))
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
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja", t_carpeta.caja);
            return View(t_carpeta);
        }

        // GET: t_carpeta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_carpeta = await _context.tcarpeta
                .Include(t => t.rcaja)
                .FirstOrDefaultAsync(m => m.idcarpeta == id);
            if (t_carpeta == null)
            {
                return NotFound();
            }

            return View(t_carpeta);
        }

        // POST: t_carpeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t_carpeta = await _context.tcarpeta.FindAsync(id);
            _context.tcarpeta.Remove(t_carpeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool t_carpetaExists(int id)
        {
            return _context.tcarpeta.Any(e => e.idcarpeta == id);
        }
    }
}
