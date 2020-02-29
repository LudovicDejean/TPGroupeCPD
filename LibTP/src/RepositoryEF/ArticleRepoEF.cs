using System;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibTP.Model;


namespace LibTP.src
{
    public class ArticleRepoEF : IArticleRepo
    {
        private readonly AppDbContext ctx;

        public ArticleRepoEF(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public Article GetArticleByID(int ID)
        {
            Article article = ctx.Articles.Where(q => q.Id == ID).First();
            return article;
        }

        public List<Article> GetAllArticles()
        {
            List<Article> articles = articles = ctx.Articles.ToList();
            return articles;
        }

        public List<Article> GetArticlesByEtagere(Etagere etagere)
            => ctx.Articles.Where(a => a.PositionMagasins.Any(p => p.IdEtagere == etagere.Id)).ToList(); 

        public List<Article> GetArticlesBySecteur(Secteur secteur)
        {
            List<Article> articles = new List<Article>();
            foreach (Etagere etagere in secteur.Etageres)
            {
                List<Article> articlesByEtageres = GetArticlesByEtagere(etagere);
                foreach(Article article in articlesByEtageres)
                {
                    articles.Add(article);
                }
            }
            return articles;
        }

        public void AddArticle(Article article)
        {
            ctx.Articles.Add(article);
            ctx.SaveChanges();
        }

        public void DelArticle(Article article)
        {
            ctx.Articles.Remove(article);
            ctx.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            ctx.Articles.Update(article);
            ctx.SaveChanges();
        }

        public decimal GetAveragePriceBySecteur(Secteur secteur)
        {
            List<Article> articles = GetArticlesBySecteur(secteur); ;
            decimal AvgPrice = 0;
            
            foreach (Article article in articles)
            {
                AvgPrice += article.PrixInitial;
            }
            AvgPrice /= articles.Count();

            return AvgPrice;
        }

        public void InsertArticleInEtagere(Article article, Etagere etagere, int quantite)
        {
            List<Article> ArticleInEtagere = GetArticlesByEtagere(etagere);
            var CurrentPoids = ArticleInEtagere.Sum(a => a.Poids);

            if (CurrentPoids + (quantite * article.Poids) < etagere.PoidsMaximum)
            {
                PositionMagasin positionMagasin = new PositionMagasin
                {
                    IdArticle = article.Id,
                    IdEtagere = etagere.Id,
                    Quantite = quantite,
                    Article = article,
                    Etagere = etagere
                };
            }
        }
    }
}
