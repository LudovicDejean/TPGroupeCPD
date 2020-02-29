using System;
using System.Collections.Generic;
using System.Text;

namespace LibTP.src
{
    interface ISecteurRepo
    {
        void AddSecteur(Secteur secteur);
        void DelSecteur(Secteur Secteur);
        void UpdateSecteur(Secteur Secteur);
    }
}
