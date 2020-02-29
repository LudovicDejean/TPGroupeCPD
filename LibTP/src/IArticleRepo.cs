using System;
using System.Collections.Generic;
using System.Text;
using LibTP.Model;

namespace LibTP.src.Interface
{
    public interface IArticleRepo
    {
        Article GetArticleByID(int ID);
        List<Article> GetAllArticles();
        List<Article> GetArticlesByEtagere(Etagere etagere);
        List<Article> GetArticlesBySecteur(Secteur secteur);
        void AddArticle(Article article);
        void DelArticle(Article article);
        void UpdateArticle(Article article);
        decimal GetAveragePriceBySecteur(Secteur secteur);
    }
}
