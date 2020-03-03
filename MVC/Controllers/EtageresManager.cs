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
    public class EtageresManager : Controller
    {
        private readonly AppDbContext ctx;

        public EtageresManager(AppDbContext appDbContext)
        {
            ctx = appDbContext;
        }

        // GET: Etageres
        public async Task<IActionResult> Index()
        {
            return View(await ctx.Etageres.ToListAsync());
        }

        // GET: Etageres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etagere = await ctx.Etageres
                .Include(e => e.Secteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etagere == null)
            {
                return NotFound();
            }

            return View(etagere);
        }

        // GET: Etageres/Create
        public IActionResult Create()
        {
            ViewData["IdSecteur"] = new SelectList(ctx.Secteurs, "Id", "Id");
            return View();
        }

        // POST: Etageres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoidsMaximum,IdSecteur")] Etagere etagere)
        {
            if (ModelState.IsValid)
            {
                ctx.Add(etagere);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSecteur"] = new SelectList(ctx.Secteurs, "Id", "Id", etagere.IdSecteur);
            return View(etagere);
        }

        // GET: Etageres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etagere = await ctx.Etageres.FindAsync(id);
            if (etagere == null)
            {
                return NotFound();
            }
            ViewData["IdSecteur"] = new SelectList(ctx.Secteurs, "Id", "Id", etagere.IdSecteur);
            return View(etagere);
        }

        // POST: Etageres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoidsMaximum,IdSecteur")] Etagere etagere)
        {
            if (id != etagere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Update(etagere);
                    await ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtagereExists(etagere.Id))
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
            ViewData["IdSecteur"] = new SelectList(ctx.Secteurs, "Id", "Id", etagere.IdSecteur);
            return View(etagere);
        }

        // GET: Etageres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etagere = await ctx.Etageres
                .Include(e => e.Secteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etagere == null)
            {
                return NotFound();
            }

            return View(etagere);
        }

        // POST: Etageres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etagere = await ctx.Etageres.FindAsync(id);
            ctx.Etageres.Remove(etagere);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtagereExists(int id)
        {
            return ctx.Etageres.Any(e => e.Id == id);
        }
    }
}
