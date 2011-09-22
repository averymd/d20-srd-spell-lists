using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using d20_SRD_Spell_Lists.Models;
using System.Xml.Linq;
using System.IO;
using d20_SRD_Spell_Lists.Properties;

namespace d20_SRD_Spell_Lists_Tests
{
    public class SpellSetTests
    {
        [Fact]
        public void loadingValidXMLShouldResultInSpells() {
            MasterSpellSet spells = new MasterSpellSet();
            Assert.True(spells.totalCount() > 0);
        }

        [Fact]
        public void loadingValidMasterXMLShouldResultIn699MasterSpells() {
            MasterSpellSet spells = new MasterSpellSet();
            Assert.Equal<int>(699, spells.totalCount());
        }

        [Fact]
        public void thereAre237ClericSpells() {
            MasterSpellSet spells = new MasterSpellSet();

            Assert.Equal<int>(237, spells.byClass(Character.SpellCastingClasses.Cleric).Count());
        }

        [Fact]
        public void thereAre31Cleric1Spells() {
            MasterSpellSet spells = new MasterSpellSet();

            Assert.Equal<int>(31, spells.byClassAndLevel(Character.SpellCastingClasses.Cleric, 1).Count());
        }
    }
}
