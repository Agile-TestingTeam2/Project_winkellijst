﻿using System;
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

namespace Winkellijst_ASP.Controllers
{
    [Authorize]
    public class WinkelLijstController : Controller
    {
        private readonly GebruikerContext _context;
        private UserManager<AppGebruiker> _userManager;

        public WinkelLijstController(GebruikerContext context, UserManager<AppGebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: WinkelLijst
        public async Task<IActionResult> Index()
        {
            var gebruikerContext = _context.WinkelLijsten.Include(w => w.Gebruiker).Include(x => x.WinkelLijstProducts);
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
            WinkelLijst winkelLijst = await _context.WinkelLijsten.SingleOrDefaultAsync(x => x.Naam == winkellijstCreateViewModel.Winkellijst.Naam);
            if (winkelLijst != null)
            {
                ModelState.AddModelError(string.Empty, "De naam voor deze winkellijst bestaat al.");
            }
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
            WinkellijstEditViewModel winkellijstEditViewModel = new WinkellijstEditViewModel();
            winkellijstEditViewModel.Winkellijst = winkelLijst;
            return View(winkellijstEditViewModel);
        }

        // POST: WinkelLijst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WinkellijstEditViewModel winkellijstEditViewModel)
        {
            if (id != winkellijstEditViewModel.Winkellijst.WinkelLijstId)
            {
                return NotFound();
            }
            WinkelLijst controleWinkelLijst = await _context.WinkelLijsten.SingleOrDefaultAsync(x => x.Naam == winkellijstEditViewModel.Winkellijst.Naam);
            if (controleWinkelLijst != null)
            {
                ModelState.AddModelError(string.Empty, "De naam voor deze winkellijst bestaat al.");
            }

            if (ModelState.IsValid)
            {
                WinkelLijst winkelLijst = await _context.WinkelLijsten.SingleOrDefaultAsync(x => x.WinkelLijstId == id);
                if (winkelLijst != null)
                {
                    winkelLijst.Naam = winkellijstEditViewModel.Winkellijst.Naam;
                    _context.Update(winkelLijst);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kon uw winkellijst niet bewerken, probeer later nog eens.");
                }
            }
                    
            return View(winkellijstEditViewModel);
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
