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
    public class OjeksController : Controller
    {
        private readonly JajanOnlineContext _context;

        public OjeksController(JajanOnlineContext context)
        {
            _context = context;
        }

        // GET: Ojeks
        public async Task<IActionResult> Index()
        {
            var jajanOnlineContext = _context.Ojeks.Include(o => o.IdJenisKendaraanNavigation);
            return View(await jajanOnlineContext.ToListAsync());
        }

        // GET: Ojeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ojek = await _context.Ojeks
                .Include(o => o.IdJenisKendaraanNavigation)
                .FirstOrDefaultAsync(m => m.IdOjek == id);
            if (ojek == null)
            {
                return NotFound();
            }

            return View(ojek);
        }

        // GET: Ojeks/Create
        public IActionResult Create()
        {
            ViewData["IdJenisKendaraan"] = new SelectList(_context.JenisKendaraans, "IdJenisKendaraan", "IdJenisKendaraan");
            return View();
        }

        // POST: Ojeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOjek,NamaOjek,PlatNomor,IdJenisKendaraan")] Ojek ojek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ojek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJenisKendaraan"] = new SelectList(_context.JenisKendaraans, "IdJenisKendaraan", "IdJenisKendaraan", ojek.IdJenisKendaraan);
            return View(ojek);
        }

        // GET: Ojeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ojek = await _context.Ojeks.FindAsync(id);
            if (ojek == null)
            {
                return NotFound();
            }
            ViewData["IdJenisKendaraan"] = new SelectList(_context.JenisKendaraans, "IdJenisKendaraan", "IdJenisKendaraan", ojek.IdJenisKendaraan);
            return View(ojek);
        }

        // POST: Ojeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOjek,NamaOjek,PlatNomor,IdJenisKendaraan")] Ojek ojek)
        {
            if (id != ojek.IdOjek)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ojek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OjekExists(ojek.IdOjek))
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
            ViewData["IdJenisKendaraan"] = new SelectList(_context.JenisKendaraans, "IdJenisKendaraan", "IdJenisKendaraan", ojek.IdJenisKendaraan);
            return View(ojek);
        }

        // GET: Ojeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ojek = await _context.Ojeks
                .Include(o => o.IdJenisKendaraanNavigation)
                .FirstOrDefaultAsync(m => m.IdOjek == id);
            if (ojek == null)
            {
                return NotFound();
            }

            return View(ojek);
        }

        // POST: Ojeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ojek = await _context.Ojeks.FindAsync(id);
            _context.Ojeks.Remove(ojek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OjekExists(int id)
        {
            return _context.Ojeks.Any(e => e.IdOjek == id);
        }
    }
}
