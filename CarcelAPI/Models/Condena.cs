﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class Condena
    {
        public int ID { get; set; }
        public DateTime FechaInicioCondena { get; set; }
        public DateTime FechaCondena { get; set; }
        public int? PresoId { get; set; }
        public Preso Preso { get; set; }
        public int? JuezId { get; set; }
        public Juez Juez { get; set; }
        public List<CondenaDelito> Delitos { get; set; }
    }
}