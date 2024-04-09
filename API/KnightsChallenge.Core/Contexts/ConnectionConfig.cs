using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Contexts
{
    public class ConnectionConfig
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string KnightsCollection { get; set; } = null!;

        public string HallOfHeroesCollection { get; set; } = null!;
    }
}
