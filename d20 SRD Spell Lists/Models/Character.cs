using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using d20_SRD_Spell_Lists.Exceptions;

namespace d20_SRD_Spell_Lists.Models {
    public class Character {

        private string charXmlFile;
        private XElement charDetails;

        public Character() {
            charDetails = new XElement("character");
            charDetails.Add(new XElement("spells"));
        }

        public Character(string _charXmlFile) {
            charXmlFile = _charXmlFile;
            charDetails = XElement.Load(charXmlFile);
        }

        internal void save() {
            if (charXmlFile == null) {
                throw new NoCharacterFileException("Don't have a file location for the character.");
            }
            charDetails.Save(charXmlFile);
        }

        internal XElement spells() {
            return charDetails.Element("spells");
        }

        private int modifier(int score) {
            return (int)Math.Floor((score - 10) / 2.00);
        }

        public string Name {
            get {
                if (charDetails.Element("name") != null) {
                    return charDetails.Element("name").Value;
                }
                return "";
            }
            set {
                if (charDetails.Element("name") != null) {
                    charDetails.Element("name").Value = value;
                } else {
                    charDetails.Add(new XElement("name", value));
                }
            }
        }

        public int Strength {
            get {
                if (charDetails.Element("strength") != null) {
                    return int.Parse(charDetails.Element("strength").Value);
                }
                return 0;
            }
            set {
                if (charDetails.Element("strength") != null) {
                    charDetails.Element("strength").Value = value.ToString();
                } else {
                    charDetails.Add(new XElement("strength", value));
                }
            }
        }

        public int Dexterity {
            get {
                if (charDetails.Element("dexterity") != null) {
                    return int.Parse(charDetails.Element("dexterity").Value);
                }
                return 0;
            }
            set {
                if (charDetails.Element("dexterity") != null) {
                    charDetails.Element("dexterity").Value = value.ToString();
                } else {
                    charDetails.Add(new XElement("dexterity", value));
                }
            }
        }

        public int Constitution {
            get {
                if (charDetails.Element("constitution") != null) {
                    return int.Parse(charDetails.Element("constitution").Value);
                }
                return 0;
            }
            set {
                if (charDetails.Element("constitution") != null) {
                    charDetails.Element("constitution").Value = value.ToString();
                } else {
                    charDetails.Add(new XElement("constitution", value));
                }
            }
        }

        public int Intelligence {
            get {
                if (charDetails.Element("intelligence") != null) {
                    return int.Parse(charDetails.Element("intelligence").Value);
                }
                return 0;
            }
            set {
                if (charDetails.Element("intelligence") != null) {
                    charDetails.Element("intelligence").Value = value.ToString();
                } else {
                    charDetails.Add(new XElement("intelligence", value));
                }
            }
        }

        public int Wisdom { 
            get {
                if (charDetails.Element("wisdom") != null) {
                    return int.Parse(charDetails.Element("wisdom").Value);
                }
                return 0;
            } 
            set {
                if (charDetails.Element("wisdom") != null) {
                    charDetails.Element("wisdom").Value = value.ToString();
                } else {
                    charDetails.Add(new XElement("wisdom", value));
                }
            }
        }

        public int Charisma {
            get {
                if (charDetails.Element("charisma") != null) {
                    return int.Parse(charDetails.Element("charisma").Value);
                }
                return 0;
            }
            set {
                if (charDetails.Element("charisma") != null) {
                    charDetails.Element("charisma").Value = value.ToString();
                } else {
                    charDetails.Add(new XElement("charisma", value));
                }
            }
        }

        public int SpellCastingAttribute {
            get {
                switch (CharacterClass) {
                    case SpellCastingClasses.Bard:
                        return Charisma;
                    case SpellCastingClasses.Cleric:
                        return Wisdom;
                    case SpellCastingClasses.Druid:
                        return Wisdom;
                    case SpellCastingClasses.Paladin:
                        return Wisdom;
                    case SpellCastingClasses.Ranger:
                        return Wisdom;
                    case SpellCastingClasses.Sorcerer:
                        return Charisma;
                    case SpellCastingClasses.Wizard:
                        return Intelligence;
                    default:
                        return Wisdom;
                }
            }
        }

        public int SpellCastingAttributeMod {
            get {
                switch (CharacterClass) {
                    case SpellCastingClasses.Bard:
                        return CharismaMod;
                    case SpellCastingClasses.Cleric:
                        return WisdomMod;
                    case SpellCastingClasses.Druid:
                        return WisdomMod;
                    case SpellCastingClasses.Paladin:
                        return WisdomMod;
                    case SpellCastingClasses.Ranger:
                        return WisdomMod;
                    case SpellCastingClasses.Sorcerer:
                        return CharismaMod;
                    case SpellCastingClasses.Wizard:
                        return IntelligenceMod;
                    default:
                        return WisdomMod;
                }
            }
        }

        public SpellCastingClasses CharacterClass {
            get {
                if (charDetails.Element("class") != null) {
                    return (SpellCastingClasses)Enum.Parse(typeof(SpellCastingClasses), charDetails.Element("class").Value);
                }
                return 0;
            }
            set {
                if (charDetails.Element("class") != null) {
                    charDetails.Element("class").Value = getClassName(value);
                } else {
                    charDetails.Add(new XElement("class", getClassName(value)));
                }
            }
        }

        public int StrengthMod {
            get {
                return modifier(Strength);
            }
        }

        public int DexterityMod {
            get {
                return modifier(Dexterity);
            }
        }

        public int ConstitutionMod {
            get {
                return modifier(Constitution);
            }
        }

        public int IntelligenceMod {
            get {
                return modifier(Intelligence);
            }
        }        

        public int WisdomMod {
            get {
                return modifier(Wisdom);
            }
        }

        public int CharismaMod {
            get {
                return modifier(Charisma);
            }
        }

        public enum SpellCastingClasses {
            Bard = 0,
            Cleric = 1,
            Druid = 2,
            Paladin = 3,
            Ranger = 4,
            Sorcerer = 5,
            Wizard = 6
        }

        public static string getClassName(SpellCastingClasses spellCastingClass) {
            return Enum.GetName(typeof(SpellCastingClasses), spellCastingClass);
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
    }
}
