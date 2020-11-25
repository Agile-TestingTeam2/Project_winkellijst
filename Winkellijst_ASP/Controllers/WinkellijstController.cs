using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.Controllers
{
    public class WinkelLijstController : Controller
    {
        private readonly GebruikerContext _context;

        public WinkelLijstController(GebruikerContext context)
        {
            _context = context;
        }

        // GET: WinkelLijst
        public async Task<IActionResult> Index()
        {
            var gebruikerContext = _context.WinkelLijsten.Include(w => w.Gebruiker).Include(w => w.Winkel);
            return View(await gebruikerContext.ToListAsync());
        }

        // GET: WinkelLijst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelLijst = await _context.WinkelLijsten
                .Include(w => w.Gebruiker)
                .Include(w => w.Winkel)
                .FirstOrDefaultAsync(m => m.WinkelLijstId == id);
            if (winkelLijst == null)
            {
                return NotFound();
            }

            return View(winkelLijst);
        }

        // GET: WinkelLijst/Create
        public IActionResult Create()
        {
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "GebruikerId", "GebruikerId");
            ViewData["WinkelId"] = new SelectList(_context.Winkels, "WinkelId", "Huisnummer");
            return View();
        }

        // POST: WinkelLijst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WinkelLijstId,GebruikerId,WinkelId,AanmaakDatum")] WinkelLijst winkelLijst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(winkelLijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "GebruikerId", "GebruikerId", winkelLijst.GebruikerId);
            ViewData["WinkelId"] = new SelectList(_context.Winkels, "WinkelId", "Huisnummer", winkelLijst.WinkelId);
            return View(winkelLijst);
        }

        // GET: WinkelLijst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelLijst = await _context.WinkelLijsten.FindAsync(id);
            if (winkelLijst == null)
            {
                return NotFound();
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "GebruikerId", "GebruikerId", winkelLijst.GebruikerId);
            ViewData["WinkelId"] = new SelectList(_context.Winkels, "WinkelId", "Huisnummer", winkelLijst.WinkelId);
            return View(winkelLijst);
        }

        // POST: WinkelLijst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WinkelLijstId,GebruikerId,WinkelId,AanmaakDatum")] WinkelLijst winkelLijst)
        {
            if (id != winkelLijst.WinkelLijstId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(winkelLijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WinkelLijstExists(winkelLijst.WinkelLijstId))
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
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "GebruikerId", "GebruikerId", winkelLijst.GebruikerId);
            ViewData["WinkelId"] = new SelectList(_context.Winkels, "WinkelId", "Huisnummer", winkelLijst.WinkelId);
            return View(winkelLijst);
        }

        // GET: WinkelLijst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelLijst = await _context.WinkelLijsten
                .Include(w => w.Gebruiker)
                .Include(w => w.Winkel)
                .FirstOrDefaultAsync(m => m.WinkelLijstId == id);
            if (winkelLijst == null)
            {
                return NotFound();
            }

            return View(winkelLijst);
        }

        // POST: WinkelLijst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var winkelLijst = await _context.WinkelLijsten.FindAsync(id);
            _context.WinkelLijsten.Remove(winkelLijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WinkelLijstExists(int id)
        {
            return _context.WinkelLijsten.Any(e => e.WinkelLijstId == id);
        }
    }
}
