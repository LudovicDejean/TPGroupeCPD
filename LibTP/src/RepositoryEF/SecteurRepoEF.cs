﻿using System;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibTP.Model;


namespace LibTP.src
{
    public class SecteurRepoEF : ISecteurRepo
    {
        private readonly AppDbContext ctx;

        public SecteurRepoEF(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Secteur GetSecteurByID(int ID)
        {
            Secteur secteur = ctx.Secteurs.Where(q => q.Id == ID).First();
            return secteur;
        }

        public List<Secteur> GetAllSecteurs()
        {
            List<Secteur> secteurs = ctx.Secteurs.ToList();
            return secteurs;
        }

        public void AddSecteur(Secteur secteur)
        {
            ctx.Secteurs.Add(secteur);
            ctx.SaveChanges();
        }

        public void DelSecteur(Secteur secteur)
        {
            ctx.Secteurs.Remove(secteur);
            ctx.SaveChanges();
        }

        public void UpdateSecteur(Secteur secteur)
        {
            ctx.Secteurs.Update(secteur);
            ctx.SaveChanges();
        }
    }
}
