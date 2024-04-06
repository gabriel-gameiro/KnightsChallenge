using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Models
{
    public class Attributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int GetByName(string name)
        {
            Type type = this.GetType();
            TextInfo cultureinfo = CultureInfo.CurrentCulture.TextInfo;
            name = cultureinfo.ToTitleCase(name).Replace(" ", string.Empty);
            PropertyInfo info = type.GetProperty(name);
            if (info == null)
                return 0;
            return (int)info.GetValue(this, null);
        }
    }
}
