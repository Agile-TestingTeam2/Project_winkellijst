using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Winkellijst_ASP.Areas.Identity.Data;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.ViewModel;
using Winkellijst_ASP.Helpers;

namespace Winkellijst_ASP.Controllers
{
    [Authorize]
    public class WinkelLijstController : Controller
    {
        private readonly GebruikerContext _context;
        private readonly UserManager<AppGebruiker> _userManager;

        public WinkelLijstController(GebruikerContext context, UserManager<AppGebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: WinkelLijst
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var gebruiker = _context.Gebruikers.Where(gebruiker => gebruiker.AppGebruikerId == userId).FirstOrDefault();
                var gebruikerId = gebruiker.GebruikerId;

                var list = _context.WinkelLijsten
                    .Where(w => w.GebruikerId == gebruikerId)
                    .Include(w => w.Gebruiker)
                    .Include(w => w.WinkelLijstProducts)
                    .OrderByDescending(w => w.AanmaakDatum)
                    .ToList();

                return View(list);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
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
            WinkellijstCreateViewModel viewModel = new WinkellijstCreateViewModel();
            viewModel.Winkellijst = new WinkelLijst();
            return View(viewModel);
        }

        // POST: WinkelLijst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WinkellijstCreateViewModel winkellijstCreateViewModel)
        {
            var userId = _userManager.GetUserId(User);
            Gebruiker gebruiker = await _context.Gebruikers.FirstOrDefaultAsync(x => x.AppGebruikerId == userId);
            if (ModelState.IsValid && gebruiker != null)
            {
                winkellijstCreateViewModel.Winkellijst.GebruikerId = gebruiker.GebruikerId;
                winkellijstCreateViewModel.Winkellijst.AanmaakDatum = DateTime.Now;
                _context.Add(winkellijstCreateViewModel.Winkellijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(winkellijstCreateViewModel);
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
            return View(winkelLijst);
        }

        // POST: WinkelLijst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WinkelLijstId,GebruikerId,AanmaakDatum")] WinkelLijst winkelLijst)
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
