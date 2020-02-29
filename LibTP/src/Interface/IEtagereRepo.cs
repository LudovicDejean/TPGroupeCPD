using System;
using System.Collections.Generic;
using System.Text;

namespace LibTP.src
{
    interface IEtagereRepo
    {
        void AddEtagere(Etagere etagere);
        void DelEtagere(Etagere etagere);
        void UpdateEtagere(Etagere etagere);
    }
}
