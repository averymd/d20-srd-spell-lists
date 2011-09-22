using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace d20_SRD_Spell_Lists.Models {
    public class Spell {
        public string IsPrepped { get; set; }
        public string Name { get; set; }
        public string AltName { get; set; }
        public string School { get; set; }
        public string Subschool { get; set; }
        public string Descriptor { get; set; }
        public int Level { get; set; }
        public string FullLevel {get; set;}
        public string Components { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Effect { get; set; }
        public string Target { get; set; }
        public string Duration { get; set; }
        public string SavingThrow { get; set; }
        public string SpellResistance { get; set; }
        public string ShortDescription { get; set; }
        public string ArcaneMaterialComponents { get; set; }
        public string Description { get; set; }
        public string FullText { get; set; }
        public string Reference { get; set; }

        public void fromMasterSpell(XElement spell, string className) {
            Regex levelReg = new Regex(@" (\d+)?");

            Name = (string)spell.Element("name");
            AltName = (string)spell.Element("altname");
            School = (string)spell.Element("school");
            Subschool = (string)spell.Element("subschool");
            Descriptor = (string)spell.Element("descriptor");
            FullLevel = (string)spell.Element("level");
            Level = int.Parse(levelReg.Match(FullLevel, FullLevel.IndexOf(className)).Groups[1].Value);
            Components = (string)spell.Element("components");
            CastingTime = (string)spell.Element("casting_time");
            Range = (string)spell.Element("range");
            Effect = (string)spell.Element("effect");
            Target = (string)spell.Element("target");
            Duration = (string)spell.Element("duration");
            SavingThrow = (string)spell.Element("saving_throw");
            SpellResistance = (string)spell.Element("spell_resistance");
            ShortDescription = (string)spell.Element("short_description");
            ArcaneMaterialComponents = (string)spell.Element("arcane_material_components");
            Description = (string)spell.Element("description");
            FullText = (string)spell.Element("full_text");
            Reference = (string)spell.Element("reference");
        }
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
