using System;
using System.Collections.Generic;
using System.Text;

namespace LibTP.src.Interface
{
    interface ISecteurRepo
    {
        void AddSecteur(Secteur secteur);
        void DelSecteur(Secteur Secteur);
        void UpdateSecteur(Secteur Secteur);
        Secteur GetSecteurByID(int ID);
        Secteur GetSecteurByName(String name);
        List<Secteur> GetAllSecteurs();
    }
}
