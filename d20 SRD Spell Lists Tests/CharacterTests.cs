using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using d20_SRD_Spell_Lists.Models;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace d20_SRD_Spell_Lists_Tests {
    public class CharacterTests {

        private string charFile;

        public CharacterTests() {
            charFile = "AppData/TestCharacter.xml";

            string defaultCharSpells = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Character><Name>Thomasina</Name><CharacterClass>Cleric</CharacterClass><Spells><Spell><Name>Dummy Character Spell</Name><ShortDescription>A short description.</ShortDescription></Spell></Spells></Character>";
            using (StreamWriter outfile = new StreamWriter(charFile)) {
                outfile.Write(defaultCharSpells);
            }
        }

        [Fact]
        public void loadingValidCharacterShouldResultInOneCharacterSpell() {
            Character c;
            XmlSerializer ser = new XmlSerializer(typeof(Character));
            using (FileStream f = new FileStream(charFile, FileMode.Open)) {
                c = (Character)ser.Deserialize(f);
            }
            Assert.Equal<int>(1, c.Spells.Count);
        }

        [Fact]
        public void loadingValidCharacterShouldLoadAName() {
            Character c;
            XmlSerializer ser = new XmlSerializer(typeof(Character));
            using (FileStream f = new FileStream(charFile, FileMode.Open)) {
                c = (Character)ser.Deserialize(f);
            }
            Assert.Equal<string>("Thomasina", c.Name);
        }

        [Fact]
        public void loadingValidCharacterShouldLoadAClass() {
            Character c;
            XmlSerializer ser = new XmlSerializer(typeof(Character));
            using (FileStream f = new FileStream(charFile, FileMode.Open)) {
                c = (Character)ser.Deserialize(f);
            }
            Assert.Equal<string>("Cleric", c.CharacterClass.ToString());
        }

        [Fact]
        public void useCorrectAttributeModifiers() {
            Character c = new Character();

            c.SpellCastingAttribute = 8;
            Assert.Equal<int>(-1, c.SpellCastingAttributeMod);

            c.SpellCastingAttribute = 9;
            Assert.Equal<int>(-1, c.SpellCastingAttributeMod);

            c.SpellCastingAttribute = 10;
            Assert.Equal<int>(0, c.SpellCastingAttributeMod);

            c.SpellCastingAttribute = 11;
            Assert.Equal<int>(0, c.SpellCastingAttributeMod);

            c.SpellCastingAttribute = 22;
            Assert.Equal<int>(6, c.SpellCastingAttributeMod);

            c.SpellCastingAttribute = 17;
            Assert.Equal<int>(3, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectBardSpellCastingAttribute() {
            Character c = new Character();

            c.CharacterClass = Character.SpellCastingClasses.Bard;
            Assert.Equal<string>("Charisma", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectClericSpellCastingAttribute() {
            Character c = new Character();

            c.CharacterClass = Character.SpellCastingClasses.Cleric;
            Assert.Equal<string>("Wisdom", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectDruidSpellCastingAttribute() {
            Character c = new Character();

            c.CharacterClass = Character.SpellCastingClasses.Druid;
            Assert.Equal<string>("Wisdom", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectPaladinSpellCastingAttribute() {
            Character c = new Character();
           
            c.CharacterClass = Character.SpellCastingClasses.Paladin;
            Assert.Equal<string>("Wisdom", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectRangerSpellCastingAttribute() {
            Character c = new Character();

            c.CharacterClass = Character.SpellCastingClasses.Ranger;
            Assert.Equal<string>("Wisdom", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectSorcererSpellCastingAttribute() {
            Character c = new Character();

            c.CharacterClass = Character.SpellCastingClasses.Sorcerer;
            Assert.Equal<string>("Charisma", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectWizardSpellCastingAttribute() {
            Character c = new Character();

            c.CharacterClass = Character.SpellCastingClasses.Wizard;
            Assert.Equal<string>("Intelligence", c.SpellCastingAttributeName);
        }

        [Fact]
        public void useCorrectBonusSpells() {
            Character c = new Character();

            Assert.Equal<int>(10, c.BonusSpells.Length);
            c.SpellCastingAttribute = 17;
            c.CharacterClass = Character.SpellCastingClasses.Wizard;
            Assert.Equal<int>(0, c.BonusSpells[0]);
            Assert.Equal<int>(1, c.BonusSpells[1]);
            Assert.Equal<int>(1, c.BonusSpells[3]);
            Assert.Equal<int>(0, c.BonusSpells[4]);

            c.SpellCastingAttribute = 13;
            c.CharacterClass = Character.SpellCastingClasses.Bard;
            Assert.Equal<int>(0, c.BonusSpells[0]);
            Assert.Equal<int>(1, c.BonusSpells[1]);
            Assert.Equal<int>(0, c.BonusSpells[2]);
            Assert.Equal<int>(0, c.BonusSpells[4]);

            c.SpellCastingAttribute = 22;
            c.CharacterClass = Character.SpellCastingClasses.Cleric;
            Assert.Equal<int>(0, c.BonusSpells[0]);
            Assert.Equal<int>(2, c.BonusSpells[1]);
            Assert.Equal<int>(2, c.BonusSpells[2]);
            Assert.Equal<int>(1, c.BonusSpells[4]);
            Assert.Equal<int>(1, c.BonusSpells[6]);
            Assert.Equal<int>(0, c.BonusSpells[7]);
        }

        [Fact]
        public void addingClassSpellsShouldAddClassSpells() {
            Character c = new Character();
            c.CharacterClass = Character.SpellCastingClasses.Cleric;
            c.addAllClassSpells();

            Assert.Equal<int>(237, c.Spells.Count);
        }
    }
}
