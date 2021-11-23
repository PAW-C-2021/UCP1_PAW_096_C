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
    public class PemesansController : Controller
    {
        private readonly JajanOnlineContext _context;

        public PemesansController(JajanOnlineContext context)
        {
            _context = context;
        }

        // GET: Pemesans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pemesans.ToListAsync());
        }

        // GET: Pemesans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesan = await _context.Pemesans
                .FirstOrDefaultAsync(m => m.IdPemesan == id);
            if (pemesan == null)
            {
                return NotFound();
            }

            return View(pemesan);
        }

        // GET: Pemesans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pemesans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPemesan,NamaPemesan,AlamatPemesan,NoHpPemesan,TotalHarga")] Pemesan pemesan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemesan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pemesan);
        }

        // GET: Pemesans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesan = await _context.Pemesans.FindAsync(id);
            if (pemesan == null)
            {
                return NotFound();
            }
            return View(pemesan);
        }

        // POST: Pemesans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPemesan,NamaPemesan,AlamatPemesan,NoHpPemesan,TotalHarga")] Pemesan pemesan)
        {
            if (id != pemesan.IdPemesan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemesan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemesanExists(pemesan.IdPemesan))
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
            return View(pemesan);
        }

        // GET: Pemesans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesan = await _context.Pemesans
                .FirstOrDefaultAsync(m => m.IdPemesan == id);
            if (pemesan == null)
            {
                return NotFound();
            }

            return View(pemesan);
        }

        // POST: Pemesans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pemesan = await _context.Pemesans.FindAsync(id);
            _context.Pemesans.Remove(pemesan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemesanExists(int id)
        {
            return _context.Pemesans.Any(e => e.IdPemesan == id);
        }
    }
}
