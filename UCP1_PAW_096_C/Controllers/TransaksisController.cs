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
    public class TransaksisController : Controller
    {
        private readonly JajanOnlineContext _context;

        public TransaksisController(JajanOnlineContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var jajanOnlineContext = _context.Transaksis.Include(t => t.IdOjekNavigation).Include(t => t.IdPemesanNavigation).Include(t => t.IdPemilikTokoNavigation);
            return View(await jajanOnlineContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdOjekNavigation)
                .Include(t => t.IdPemesanNavigation)
                .Include(t => t.IdPemilikTokoNavigation)
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["IdOjek"] = new SelectList(_context.Ojeks, "IdOjek", "IdOjek");
            ViewData["IdPemesan"] = new SelectList(_context.Pemesans, "IdPemesan", "IdPemesan");
            ViewData["IdPemilikToko"] = new SelectList(_context.PemilikTokos, "IdPemilikToko", "IdPemilikToko");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,NamaBarang,HargaBarang,JumlahBarang,IdPemesan,IdOjek,IdPemilikToko,TotalHarga")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOjek"] = new SelectList(_context.Ojeks, "IdOjek", "IdOjek", transaksi.IdOjek);
            ViewData["IdPemesan"] = new SelectList(_context.Pemesans, "IdPemesan", "IdPemesan", transaksi.IdPemesan);
            ViewData["IdPemilikToko"] = new SelectList(_context.PemilikTokos, "IdPemilikToko", "IdPemilikToko", transaksi.IdPemilikToko);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["IdOjek"] = new SelectList(_context.Ojeks, "IdOjek", "IdOjek", transaksi.IdOjek);
            ViewData["IdPemesan"] = new SelectList(_context.Pemesans, "IdPemesan", "IdPemesan", transaksi.IdPemesan);
            ViewData["IdPemilikToko"] = new SelectList(_context.PemilikTokos, "IdPemilikToko", "IdPemilikToko", transaksi.IdPemilikToko);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarang,NamaBarang,HargaBarang,JumlahBarang,IdPemesan,IdOjek,IdPemilikToko,TotalHarga")] Transaksi transaksi)
        {
            if (id != transaksi.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.IdBarang))
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
            ViewData["IdOjek"] = new SelectList(_context.Ojeks, "IdOjek", "IdOjek", transaksi.IdOjek);
            ViewData["IdPemesan"] = new SelectList(_context.Pemesans, "IdPemesan", "IdPemesan", transaksi.IdPemesan);
            ViewData["IdPemilikToko"] = new SelectList(_context.PemilikTokos, "IdPemilikToko", "IdPemilikToko", transaksi.IdPemilikToko);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdOjekNavigation)
                .Include(t => t.IdPemesanNavigation)
                .Include(t => t.IdPemilikTokoNavigation)
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksis.FindAsync(id);
            _context.Transaksis.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksis.Any(e => e.IdBarang == id);
        }
    }
}
