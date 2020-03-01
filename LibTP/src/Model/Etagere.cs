using System;
using System.Collections.Generic;
using System.Text;

namespace LibTP.Model
{
    public class Etagere
    {
        public int Id { get; set; }
        public decimal PoidsMaximum { get; set; }
        public int IdSecteur { get; set; }
        public ICollection<PositionMagasin> PositionMagasins { get; set; }
        public PositionMagasin Position { get; set; } 
        public Secteur Secteur { get; set; }
    }
}
