﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    public class CondenaDelito
    {
        public int ID { get; set; }
        public int? CondenaId { get; set; }
        public int? DelitoId { get; set; }
        public int Condena { get; set; }
    }
}