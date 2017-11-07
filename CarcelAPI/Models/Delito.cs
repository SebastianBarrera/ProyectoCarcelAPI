using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class Delito
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int CondenaMinima { get; set; }
        public int CondenaMaxima { get; set; }
    }
}