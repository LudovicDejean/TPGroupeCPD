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
            throw new NotImplementedException();
        }

        public void DelEtagere(Etagere etagere)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
