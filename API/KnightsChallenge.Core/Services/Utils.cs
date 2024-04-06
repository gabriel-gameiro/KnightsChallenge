using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Services
{
    internal static class Utils
    {
        public static int ModValue(int attributeValue) 
        {
            if (attributeValue < 9) return -2;
            if (attributeValue < 11) return -1;
            if (attributeValue < 13) return 0;
            if (attributeValue < 16) return 1;
            if (attributeValue < 19) return 2;
            return 3;
        }
    }
}
