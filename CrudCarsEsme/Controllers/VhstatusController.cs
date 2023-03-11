using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudCarsEsme.Models;

namespace CrudCarsEsme.Controllers
{
    public class VhstatusController : Controller
    {
        private readonly DbcarsContext _context;

        public VhstatusController(DbcarsContext context)
        {
            _context = context;
        }

        // GET: Vhstatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vhstatuses.ToListAsync());
        }

        // GET: Vhstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vhstatuses == null)
            {
                return NotFound();
            }

            var vhstatus = await _context.Vhstatuses
                .FirstOrDefaultAsync(m => m.Idstatus == id);
            if (vhstatus == null)
            {
                return NotFound();
            }

            return View(vhstatus);
        }

        // GET: Vhstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vhstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idstatus,Descripcion")] Vhstatus vhstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vhstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vhstatus);
        }

        // GET: Vhstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vhstatuses == null)
            {
                return NotFound();
            }

            var vhstatus = await _context.Vhstatuses.FindAsync(id);
            if (vhstatus == null)
            {
                return NotFound();
            }
            return View(vhstatus);
        }

        // POST: Vhstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idstatus,Descripcion")] Vhstatus vhstatus)
        {
            if (id != vhstatus.Idstatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vhstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VhstatusExists(vhstatus.Idstatus))
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
            return View(vhstatus);
        }

        // GET: Vhstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vhstatuses == null)
            {
                return NotFound();
            }

            var vhstatus = await _context.Vhstatuses
                .FirstOrDefaultAsync(m => m.Idstatus == id);
            if (vhstatus == null)
            {
                return NotFound();
            }

            return View(vhstatus);
        }

        // POST: Vhstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vhstatuses == null)
            {
                return Problem("Entity set 'DbcarsContext.Vhstatuses'  is null.");
            }
            var vhstatus = await _context.Vhstatuses.FindAsync(id);
            if (vhstatus != null)
            {
                _context.Vhstatuses.Remove(vhstatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VhstatusExists(int id)
        {
          return _context.Vhstatuses.Any(e => e.Idstatus == id);
        }
    }
}
