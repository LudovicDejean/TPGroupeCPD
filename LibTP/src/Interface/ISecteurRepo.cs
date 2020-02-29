using System;
using System.Collections.Generic;
using System.Text;
using LibTP.Model;

namespace LibTP.src
{
    interface ISecteurRepo
    {
        void AddSecteur(Secteur secteur);
        void DelSecteur(Secteur Secteur);
        void UpdateSecteur(Secteur Secteur);
        Secteur GetSecteurByID(int ID);
        List<Secteur> GetAllSecteurs();
    }
}
