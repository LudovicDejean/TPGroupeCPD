﻿using System;
using System.Collections.Generic;
using System.Text;


namespace LibTP.Model
{
    public class Secteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Etagere> Etageres { get; set; }
    }
}
