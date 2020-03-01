using System;
using System.Collections.Generic;
using System.Text;
using LibTP.Model;

namespace LibTP.src
{
    interface IEtagereRepo
    {
        Etagere GetEtagereByID(int ID);
        List<Etagere> GetAllEtageres();
        List<Etagere> GetEtageresBySecteur(Secteur secteur);
        List<Etagere> GetEtageresByArticle(Article article);
        void AddEtagere(Etagere etagere);
        void DelEtagere(Etagere etagere);
        void UpdateEtagere(Etagere etagere);
    }
}
