﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Models
{
    public class Weapon
    {
        public string? Name { get; set; }
        public int Mod { get; set; }
        public string? Attr { get; set; }
        public bool Equipped { get; set; }
    }
}
