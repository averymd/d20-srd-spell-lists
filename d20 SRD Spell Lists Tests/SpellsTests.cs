using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using d20_SRD_Spell_Lists.Models;
using System.Xml.Linq;
using System.IO;

namespace d20_SRD_Spell_Lists_Tests
{
    public class SpellsTests
    {
        private string masterSpellList;
        private string userSpellList;
        private string charFile;

        public SpellsTests() {
            masterSpellList = "AppData/MasterSpellList.xml";
            userSpellList = "AppData/UserSpellList.xml";
            charFile = "AppData/TestCharacter.xml";
            string defaultUserSpells = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><spells><spell><name>Dummy Spell</name><short_description>A short description.</short_description></spell></spells>";
            using (StreamWriter outfile = new StreamWriter(userSpellList)) {
                outfile.Write(defaultUserSpells);
            }

            string defaultCharSpells = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><character><spells><spell><name>Dummy Character Spell</name><short_description>A short description.</short_description></spell></spells></character>";
            using (StreamWriter outfile = new StreamWriter(charFile)) {
                outfile.Write(defaultCharSpells);
            }
        }

        [Fact]
        public void loadingValidXMLShouldResultInSpells() {
            SpellSet spells = new SpellSet(masterSpellList, userSpellList);
            Assert.True(spells.totalCount() > 0);
        }

        [Fact]
        public void loadingMissingXMLFails() {
            Assert.Throws<System.IO.FileNotFoundException>(
                delegate {
                    SpellSet spells = new SpellSet("phony.xml");
                });

            Assert.Throws<System.IO.FileNotFoundException>(
                delegate {
                    SpellSet spells = new SpellSet(masterSpellList, "phony.xml");
                });
        }

        [Fact]
        public void loadingValidMasterXMLShouldResultIn699MasterSpells() {
            SpellSet spells = new SpellSet(masterSpellList, userSpellList);
            Assert.Equal<int>(699, spells.masterSpellCount());
        }

        [Fact]
        public void loadingValidCustomSpellsShouldResultInOneUserSpells() {
            SpellSet spells = new SpellSet(masterSpellList, userSpellList);
            Assert.Equal<int>(1, spells.userSpellCount());
        }

        [Fact]
        public void savingNewSpellResultsInTwoSavedUserSpells() {
            SpellSet spells = new SpellSet(masterSpellList, userSpellList);
            spells.addUserSpell(new XElement("spell",
                new XElement("name", "custom test spell")
                ));
            spells.save();
            Assert.Equal<int>(2, spells.userSpellCount());
            Assert.Equal<int>(701, spells.totalCount());

            SpellSet reloadedSet = new SpellSet(masterSpellList, userSpellList);
            Assert.Equal<int>(2, spells.userSpellCount());
            Assert.Equal<int>(701, spells.totalCount());

            spells.removeUserSpell("name", "custom test spell");
            spells.save();
        }

        [Fact]
        public void hidingMasterSpellGloballyResultsInHiddenUserSpell() {
            SpellSet spells = new SpellSet(masterSpellList, userSpellList);
            Assert.Equal<int>(0, spells.hiddenSpellCount());
            spells.hideMasterSpell("name", "Armor of Darkness");
            Assert.Equal<int>(1, spells.hiddenSpellCount());
            spells.save();

            // ensure that a load preserves the hiddenness.
            spells = new SpellSet(masterSpellList, userSpellList);
            Assert.Equal<int>(1, spells.hiddenSpellCount());
            spells.showMasterSpell("name", "Armor of Darkness");
            Assert.Equal<int>(0, spells.hiddenSpellCount());
            spells.save();

            // ensure that a load preserves the showingness.
            spells = new SpellSet(masterSpellList, userSpellList);
            Assert.Equal<int>(0, spells.hiddenSpellCount());
        }

        [Fact]
        public void hidingMasterSpellForCharacterResultsInHiddenCharSpell() {
            Character c = new Character(charFile);
            SpellSet spells = new SpellSet(masterSpellList, userSpellList, c);
            Assert.Equal<int>(0, spells.hiddenCharacterSpellCount());
            spells.hideMasterSpellForCharacter("name", "Armor of Darkness");
            Assert.Equal<int>(1, spells.hiddenCharacterSpellCount());
            spells.save();

            // ensure that a load preserves the hiddenness.
            c = new Character(charFile);
            spells = new SpellSet(masterSpellList, userSpellList, c);
            Assert.Equal<int>(1, spells.hiddenCharacterSpellCount());
            spells.showMasterSpellForCharacter("name", "Armor of Darkness");
            Assert.Equal<int>(0, spells.hiddenCharacterSpellCount());
            spells.save();

            // ensure that a load preserves the showingness.
            c = new Character(charFile);
            spells = new SpellSet(masterSpellList, userSpellList, c);
            Assert.Equal<int>(0, spells.hiddenCharacterSpellCount());
        }

        [Fact]
        public void thereAre237ClericSpells() {
            SpellSet spells = new SpellSet(masterSpellList);

            Assert.Equal<int>(237, spells.byClass(Character.SpellCastingClasses.Cleric).Count());
        }

        [Fact]
        public void thereAre31Cleric1Spells() {
            SpellSet spells = new SpellSet(masterSpellList);

            Assert.Equal<int>(31, spells.byClassAndLevel(Character.SpellCastingClasses.Cleric, 1).Count());

            spells.addUserSpell(new XElement("spell",
                new XElement("name", "custom cleric spell"),
                new XElement("level", "Cleric 1")
                ));

            Assert.Equal<int>(32, spells.byClassAndLevel(Character.SpellCastingClasses.Cleric, 1).Count());
        }

        [Fact]
        public void thereAreFewerClericSpellsIfWeHideSome() {
            Character c = new Character(charFile);
            SpellSet spells = new SpellSet(masterSpellList, userSpellList, c);

            spells.hideMasterSpell("name", "Dismissal");
            spells.hideMasterSpellForCharacter("name", "Darkness");
            Assert.Equal<int>(235, spells.byClass(Character.SpellCastingClasses.Cleric).Count());
        }

    }
}
