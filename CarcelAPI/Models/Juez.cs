﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class Juez
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public bool Sexo { get; set; }
        public string Domicilio { get; set; }
    }
}