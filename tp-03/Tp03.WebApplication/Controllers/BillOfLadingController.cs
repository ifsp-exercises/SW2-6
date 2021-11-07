using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp03.Core.Data;
using Tp03.Core.Entities;

namespace Tp03.WebApplication.Controllers
{
    public class BillOfLadingController : Controller
    {
        private readonly Tp03Context _context;

        public BillOfLadingController(Tp03Context context)
        {
            _context = context;
        }

        // GET: BillOfLading
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillsOfLading.ToListAsync());
        }

        // GET: BillOfLading/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfLading = await _context.BillsOfLading
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billOfLading == null)
            {
                return NotFound();
            }

            return View(billOfLading);
        }

        // GET: BillOfLading/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillOfLading/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,Navio,Id")] BillOfLading billOfLading)
        {
            if (ModelState.IsValid)
            {
                billOfLading.Id = Guid.NewGuid();
                _context.Add(billOfLading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billOfLading);
        }

        // GET: BillOfLading/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfLading = await _context.BillsOfLading.FindAsync(id);
            if (billOfLading == null)
            {
                return NotFound();
            }
            return View(billOfLading);
        }

        // POST: BillOfLading/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Numero,Navio,Id")] BillOfLading billOfLading)
        {
            if (id != billOfLading.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billOfLading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillOfLadingExists(billOfLading.Id))
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
            return View(billOfLading);
        }

        // GET: BillOfLading/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfLading = await _context.BillsOfLading
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billOfLading == null)
            {
                return NotFound();
            }

            return View(billOfLading);
        }

        // POST: BillOfLading/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var billOfLading = await _context.BillsOfLading.FindAsync(id);
            _context.BillsOfLading.Remove(billOfLading);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillOfLadingExists(Guid id)
        {
            return _context.BillsOfLading.Any(e => e.Id == id);
        }
    }
}
