using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_096_C.Models;

namespace UCP1_PAW_096_C.Controllers
{
    public class PemilikTokoesController : Controller
    {
        private readonly JajanOnlineContext _context;

        public PemilikTokoesController(JajanOnlineContext context)
        {
            _context = context;
        }

        // GET: PemilikTokoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PemilikTokos.ToListAsync());
        }

        // GET: PemilikTokoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemilikToko = await _context.PemilikTokos
                .FirstOrDefaultAsync(m => m.IdPemilikToko == id);
            if (pemilikToko == null)
            {
                return NotFound();
            }

            return View(pemilikToko);
        }

        // GET: PemilikTokoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PemilikTokoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPemilikToko,NamaPemilikToko")] PemilikToko pemilikToko)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemilikToko);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pemilikToko);
        }

        // GET: PemilikTokoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemilikToko = await _context.PemilikTokos.FindAsync(id);
            if (pemilikToko == null)
            {
                return NotFound();
            }
            return View(pemilikToko);
        }

        // POST: PemilikTokoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPemilikToko,NamaPemilikToko")] PemilikToko pemilikToko)
        {
            if (id != pemilikToko.IdPemilikToko)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemilikToko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemilikTokoExists(pemilikToko.IdPemilikToko))
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
            return View(pemilikToko);
        }

        // GET: PemilikTokoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemilikToko = await _context.PemilikTokos
                .FirstOrDefaultAsync(m => m.IdPemilikToko == id);
            if (pemilikToko == null)
            {
                return NotFound();
            }

            return View(pemilikToko);
        }

        // POST: PemilikTokoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pemilikToko = await _context.PemilikTokos.FindAsync(id);
            _context.PemilikTokos.Remove(pemilikToko);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemilikTokoExists(int id)
        {
            return _context.PemilikTokos.Any(e => e.IdPemilikToko == id);
        }
    }
}
