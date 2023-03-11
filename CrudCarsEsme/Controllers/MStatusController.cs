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
    public class MStatusController : Controller
    {
        private readonly DbcarsContext _context;

        public MStatusController(DbcarsContext context)
        {
            _context = context;
        }

        // GET: MStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.MStatuses.ToListAsync());
        }

        // GET: MStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MStatuses == null)
            {
                return NotFound();
            }

            var mStatus = await _context.MStatuses
                .FirstOrDefaultAsync(m => m.Idstatus == id);
            if (mStatus == null)
            {
                return NotFound();
            }

            return View(mStatus);
        }

        // GET: MStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idstatus,Status")] MStatus mStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mStatus);
        }

        // GET: MStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MStatuses == null)
            {
                return NotFound();
            }

            var mStatus = await _context.MStatuses.FindAsync(id);
            if (mStatus == null)
            {
                return NotFound();
            }
            return View(mStatus);
        }

        // POST: MStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idstatus,Status")] MStatus mStatus)
        {
            if (id != mStatus.Idstatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MStatusExists(mStatus.Idstatus))
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
            return View(mStatus);
        }

        // GET: MStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MStatuses == null)
            {
                return NotFound();
            }

            var mStatus = await _context.MStatuses
                .FirstOrDefaultAsync(m => m.Idstatus == id);
            if (mStatus == null)
            {
                return NotFound();
            }

            return View(mStatus);
        }

        // POST: MStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MStatuses == null)
            {
                return Problem("Entity set 'DbcarsContext.MStatuses'  is null.");
            }
            var mStatus = await _context.MStatuses.FindAsync(id);
            if (mStatus != null)
            {
                _context.MStatuses.Remove(mStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MStatusExists(int id)
        {
          return _context.MStatuses.Any(e => e.Idstatus == id);
        }
    }
}
