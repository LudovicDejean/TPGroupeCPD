using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibTP;
using LibTP.Model;

namespace TPGroupeCPD.Controllers
{
    public class SecteursManager : Controller
    {
        private readonly AppDbContext ctx;

        public SecteursManager(AppDbContext appDbContext)
        {
            this.ctx = appDbContext;
        }

        // GET: Secteurs
        public async Task<IActionResult> Index()
        {
            return View(await ctx.Secteurs.ToListAsync());
        }

        // GET: Secteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secteur = await ctx.Secteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secteur == null)
            {
                return NotFound();
            }

            return View(secteur);
        }

        // GET: Secteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Secteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Secteur secteur)
        {
            if (ModelState.IsValid)
            {
                ctx.Add(secteur);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secteur);
        }

        // GET: Secteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secteur = await ctx.Secteurs.FindAsync(id);
            if (secteur == null)
            {
                return NotFound();
            }
            return View(secteur);
        }

        // POST: Secteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Secteur secteur)
        {
            if (id != secteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Update(secteur);
                    await ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecteurExists(secteur.Id))
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
            return View(secteur);
        }

        // GET: Secteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secteur = await ctx.Secteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secteur == null)
            {
                return NotFound();
            }

            return View(secteur);
        }

        // POST: Secteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secteur = await ctx.Secteurs.FindAsync(id);
            ctx.Secteurs.Remove(secteur);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecteurExists(int id)
        {
            return ctx.Secteurs.Any(e => e.Id == id);
        }
    }
}
