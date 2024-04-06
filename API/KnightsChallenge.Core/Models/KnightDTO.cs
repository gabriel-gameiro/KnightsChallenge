using KnightsChallenge.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Models
{
    public class KnightDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int Armas { get; set; }

        public string Atributo { get; set; }

        public int Ataque { get; set; }

        public int Exp { get; set; }

    }
}
