using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibTP.Model
{
    public class Article

    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string SKU { get; set; }
        public DateTime DateSortie { get; set; }
        public decimal PrixInitial { get; set; }
        public decimal Poids { get; set; } 
        public ICollection<PositionMagasin> PositionMagasins { get; set; }
        public PositionMagasin Position { get; set; }
    }
}