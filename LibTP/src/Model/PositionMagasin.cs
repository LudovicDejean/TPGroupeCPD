using System;
using System.Collections.Generic;
using System.Text;

namespace LibTP.Model
{
    public class PositionMagasin
    {
        public int IdArticle { get; set; }
        public int IdEtagere { get; set; }
        public int Quantite { get; set; }
        public Article Article { get; set; }
        public Etagere Etagere { get; set; }
    }
}
