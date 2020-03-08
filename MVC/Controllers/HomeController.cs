using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibTP;
using LibTP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TPGroupeCPD.Models;

namespace TPGroupeCPD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext ctx;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            this.ctx = appDbContext;
            if (ctx.Articles.Count() == 0)
            {
                Article article = new Article()
                {
                    Libelle = "Article1",
                    SKU = "AZERTYUIOP",
                    Poids = 10,
                    PrixInitial = 1000,
                    DateSortie = DateTime.Parse("2020-01-20"),
                };
                ctx.Articles.Add(article);
                //ctx.SaveChanges();
            }
            if (ctx.Secteurs.Count() == 0)
            {
                
                Secteur secteur = new Secteur()
                {
                    
                    Nom = "Secteur1"

                };
                ctx.Secteurs.Add(secteur);
                ctx.SaveChanges();
            }
            if (ctx.Etageres.Count() == 0)
            {
                Etagere etagere = new Etagere()
                {
                    IdSecteur = ctx.Secteurs.Select(p => p.Id).First(),
                    PoidsMaximum = 15000,
                    
                };
                ctx.Etageres.Add(etagere);
                ctx.SaveChanges();
                Secteur secteur = ctx.Secteurs.First();
                secteur.Etageres.Add(etagere);
                ctx.Etageres.Update(etagere);
                ctx.SaveChanges();
            }

            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}