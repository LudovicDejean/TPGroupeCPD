using LibTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTP.src
{
    class EtagereRepoEF : IEtagereRepo
    {
        private readonly AppDbContext ctx;

        public EtagereRepoEF(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddEtagere(Etagere etagere)
        {
            ctx.Etageres.Add(etagere);
            ctx.SaveChanges();
        }

        public void DelEtagere(Etagere etagere)
        {
            ctx.Etageres.Remove(etagere);
            ctx.SaveChanges();
        }

        public List<Etagere> GetAllEtageres()
        {
            List<Etagere> etageres = ctx.Etageres.ToList();
            return etageres;
        }

        public Etagere GetEtagereByID(int ID)
        {
            Etagere etagere = ctx.Etageres.Where(q => q.Id == ID).First();
            return etagere;
        }

        public List<Etagere> GetEtageresByArticle(Article article)
            => ctx.Etageres.Where(a => a.PositionMagasins.Any(p => p.IdArticle == article.Id)).ToList();


        public List<Etagere> GetEtageresBySecteur(Secteur secteur)
            => ctx.Etageres.Where(m => m.PositionMagasins.Any(a => a.Etagere.IdSecteur == secteur.Id)).ToList();

        public void UpdateEtagere(Etagere etagere)
        {
            ctx.Etageres.Update(etagere);
            ctx.SaveChanges();
        }
        public void InsertEtagereInSecteur(Etagere etagere, Secteur secteur)
        {
            List<Etagere> EtagereInSecteur = GetEtageresBySecteur(secteur);

            foreach (Etagere e in EtagereInSecteur)
            {
                if (e == etagere)
                {
                    Console.WriteLine("L'étagère existe déjà");
                    return;
                }
                else
                    EtagereInSecteur.Add(etagere);
            }
            Secteur s = new Secteur
            {
                Etageres = EtagereInSecteur
            };
        }
    }
}
