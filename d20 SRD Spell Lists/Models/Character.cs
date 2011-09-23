using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using d20_SRD_Spell_Lists.Exceptions;
using System.Xml.Serialization;

namespace d20_SRD_Spell_Lists.Models {
    public class Character {

        public List<Spell> Spells { get; set; }

        public Character() {
            Spells = new List<Spell>();
        }

        private int modifier(int score) {
            return (int)Math.Floor((score - 10) / 2.00);
        }

        public string Name { get; set; }

        public string SpellCastingAttributeName {
            get {
                switch (CharacterClass) {
                    case SpellCastingClasses.Bard:
                        return "Charisma";
                    case SpellCastingClasses.Cleric:
                        return "Wisdom";
                    case SpellCastingClasses.Druid:
                        return "Wisdom";
                    case SpellCastingClasses.Paladin:
                        return "Wisdom";
                    case SpellCastingClasses.Ranger:
                        return "Wisdom";
                    case SpellCastingClasses.Sorcerer:
                        return "Charisma";
                    case SpellCastingClasses.Wizard:
                        return "Intelligence";
                    default:
                        return "Wisdom";
                }
            }
        }

        public int SpellCastingAttribute { get; set; }

        public int SpellCastingAttributeMod {
            get {
                return modifier(SpellCastingAttribute);
            }
        }

        public SpellCastingClasses CharacterClass { get; set; }

        public enum SpellCastingClasses {
            Bard = 0,
            Cleric = 1,
            Druid = 2,
            Paladin = 3,
            Ranger = 4,
            Sorcerer = 5,
            Wizard = 6
        }

        public static string getSpellcastingClassName(SpellCastingClasses spellCastingClass) {
            return Enum.GetName(typeof(SpellCastingClasses), spellCastingClass);
        }

        public static SpellCastingClasses getSpellcastingClass(string className) {
            return (Character.SpellCastingClasses)Enum.Parse(typeof(Character.SpellCastingClasses), className);
        }

        public int[] BonusSpells {
            get {
                int[] bs = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                for (int i = 1; i < bs.Length; i++ ) {
                    bs[i] = (int)Math.Floor((SpellCastingAttribute - ((i + 1) * 2)) / 8.00);
                }
                return bs;

            }
        }

        public static string[] ClassNames {
            get {
                List<string> classes = new List<string>();
                foreach (SpellCastingClasses cl in Enum.GetValues(typeof(SpellCastingClasses))) {
                    classes.Add(getSpellcastingClassName(cl));
                }

                return classes.ToArray<string>();
            }
        }

        public void addAllClassSpells() {
            Spells.AddRange(new MasterSpellSet().byClass(CharacterClass));
            Spells.Sort(new SpellInequalityComparer());
        }

        public string SpellCastingAttributeModAsString() {
            return String.Format((SpellCastingAttributeMod >= 0) ? "+{0:D}" : "{0:D}", SpellCastingAttributeMod);
        }
    }
}
