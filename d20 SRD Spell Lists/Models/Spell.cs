using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace d20_SRD_Spell_Lists.Models {
    public class Spell {
        public bool IsPrepped { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Component { get; set; }
        public string ShortDescription { get; set; }
        public bool IsCustom { get; set; }
        public bool IsCharCustom { get; set; }

    }

    public class SpellComparer : IEqualityComparer<Spell> {
        public bool Equals(Spell x, Spell y) {
            return x.Name == y.Name;
        }

        public int GetHashCode(Spell obj) {
            return obj.Name.GetHashCode();
        }
    }
}
