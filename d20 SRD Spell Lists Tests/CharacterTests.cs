using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using d20_SRD_Spell_Lists.Models;
using System.Xml.Linq;
using System.IO;

namespace d20_SRD_Spell_Lists_Tests {
    public class CharacterTests {

        private string masterSpellList;
        private string userSpellList;
        private string charFile;

        public CharacterTests() {
            masterSpellList = "AppData/MasterSpellList.xml";
            userSpellList = "AppData/UserSpellList.xml";
            charFile = "AppData/TestCharacter.xml";
            string defaultUserSpells = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><spells><spell><name>Dummy Spell</name><short_description>A short description.</short_description></spell></spells>";
            using (StreamWriter outfile = new StreamWriter(userSpellList)) {
                outfile.Write(defaultUserSpells);
            }

            string defaultCharSpells = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><character><name>Thomasina</name><class>Cleric</class><spells><spell><name>Dummy Character Spell</name><short_description>A short description.</short_description></spell></spells></character>";
            using (StreamWriter outfile = new StreamWriter(charFile)) {
                outfile.Write(defaultCharSpells);
            }
        }

        [Fact]
        public void loadingValidCharacterShouldResultInOneCharacterSpell() {
            Character c = new Character(charFile);
            SpellSet s = new SpellSet(masterSpellList, userSpellList, c);
            Assert.Equal<int>(1, s.characterSpellCount());
        }

        [Fact]
        public void loadingValidCharacterShouldLoadAName() {
            Character c = new Character(charFile);
            Assert.Equal<string>("Thomasina", c.Name);
        }

        [Fact]
        public void loadingValidCharacterShouldLoadAClass() {
            Character c = new Character(charFile);
            Assert.Equal<string>("Cleric", c.CharacterClass.ToString());
        }

        [Fact]
        public void useCorrectAttributeModifiers() {
            Character c = new Character(charFile);

            c.Wisdom = 8;
            Assert.Equal<int>(-1, c.WisdomMod);

            c.Wisdom = 9;
            Assert.Equal<int>(-1, c.WisdomMod);

            c.Wisdom = 10;
            Assert.Equal<int>(0, c.WisdomMod);

            c.Wisdom = 11;
            Assert.Equal<int>(0, c.WisdomMod);

            c.Wisdom = 22;
            Assert.Equal<int>(6, c.WisdomMod);

            c.Wisdom = 17;
            Assert.Equal<int>(3, c.WisdomMod);
        }

        [Fact]
        public void useCorrectBardSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Bard;
            Assert.Equal<int>(c.Charisma, c.SpellCastingAttribute);
            Assert.Equal<int>(c.CharismaMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectClericSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Cleric;
            Assert.Equal<int>(c.Wisdom, c.SpellCastingAttribute);
            Assert.Equal<int>(c.WisdomMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectDruidSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Druid;
            Assert.Equal<int>(c.Wisdom, c.SpellCastingAttribute);
            Assert.Equal<int>(c.WisdomMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectPaladinSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Paladin;
            Assert.Equal<int>(c.Wisdom, c.SpellCastingAttribute);
            Assert.Equal<int>(c.WisdomMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectRangerSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Ranger;
            Assert.Equal<int>(c.Wisdom, c.SpellCastingAttribute);
            Assert.Equal<int>(c.WisdomMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectSorcererSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Sorcerer;
            Assert.Equal<int>(c.Charisma, c.SpellCastingAttribute);
            Assert.Equal<int>(c.CharismaMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectWizardSpellCastingAttribute() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 19;
            c.Intelligence = 17;

            c.CharacterClass = Character.SpellCastingClasses.Wizard;
            Assert.Equal<int>(c.Intelligence, c.SpellCastingAttribute);
            Assert.Equal<int>(c.IntelligenceMod, c.SpellCastingAttributeMod);
        }

        [Fact]
        public void useCorrectBonusSpells() {
            Character c = new Character(charFile);
            c.Wisdom = 22;
            c.Charisma = 13;
            c.Intelligence = 17;

            Assert.Equal<int>(10, c.BonusSpells.Length);

            c.CharacterClass = Character.SpellCastingClasses.Wizard;
            Assert.Equal<int>(0, c.BonusSpells[0]);
            Assert.Equal<int>(1, c.BonusSpells[1]);
            Assert.Equal<int>(1, c.BonusSpells[3]);
            Assert.Equal<int>(0, c.BonusSpells[4]);

            c.CharacterClass = Character.SpellCastingClasses.Bard;
            Assert.Equal<int>(0, c.BonusSpells[0]);
            Assert.Equal<int>(1, c.BonusSpells[1]);
            Assert.Equal<int>(0, c.BonusSpells[2]);
            Assert.Equal<int>(0, c.BonusSpells[4]);

            c.CharacterClass = Character.SpellCastingClasses.Cleric;
            Assert.Equal<int>(0, c.BonusSpells[0]);
            Assert.Equal<int>(2, c.BonusSpells[1]);
            Assert.Equal<int>(2, c.BonusSpells[2]);
            Assert.Equal<int>(1, c.BonusSpells[4]);
            Assert.Equal<int>(1, c.BonusSpells[6]);
            Assert.Equal<int>(0, c.BonusSpells[7]);
        }
    }
}
