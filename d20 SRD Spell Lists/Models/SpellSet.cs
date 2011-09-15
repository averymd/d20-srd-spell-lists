using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using d20_SRD_Spell_Lists.Exceptions;

namespace d20_SRD_Spell_Lists.Models {
    public class SpellSet {
        private XElement masterSpellList;
        private XElement userSpellList;
        private XElement charSpellList;
        private string userXmlFile;
        private Character character;

        public SpellSet(string _masterXmlFile = null, string _userXmlFile = null, Character _character = null) {
            userXmlFile = _userXmlFile;
            character = _character;
            loadXML(ref _masterXmlFile);
        }

        private void loadXML(ref string _masterXmlFile) {
            // Load the XML file.
            if (_masterXmlFile == null) {
                _masterXmlFile = Properties.Settings.Default.MasterSpells;
            }
            if (userXmlFile == null) {
                userXmlFile = Properties.Settings.Default.UserSpells;
            }
            masterSpellList = XElement.Load(_masterXmlFile);
            userSpellList = XElement.Load(userXmlFile);

            if (character != null) {
                charSpellList = character.spells();
            }
        }      

        /// <summary>
        /// Adds a spell to the application's list of custom spells.
        /// </summary>
        /// <param name="xElement">The XML details of the new spell.</param>
        public void addUserSpell(XElement xElement) {
            userSpellList.Add(xElement);
        }

        public IEnumerable<XElement> byClass(Character.SpellCastingClasses spellCastingClass) {
            XElement spells = new XElement("spells");

            filterMasterSpellsByClass(spellCastingClass, spells);
            filterUserSpellsByClass(spellCastingClass, spells);
            filterCharacterSpellsByClass(spellCastingClass, spells);

            removeHiddenSpells(spells);

            return spells.Elements("spell");
        }

        private void filterMasterSpellsByClass(Character.SpellCastingClasses spellCastingClass, XElement spells) {
            spells.Add((from sp in masterSpellList.Elements("spell")
                        let level = (string)sp.Element("level")
                        where level != null && level.Contains(Character.getClassName(spellCastingClass))
                        select sp));
        }

        private void filterCharacterSpellsByClass(Character.SpellCastingClasses spellCastingClass, XElement spells) {
            if (characterSpellCount() > 0) {
                spells.Add((from sp in charSpellList.Elements("spell")
                            let level = (string)sp.Element("level")
                            where level != null && level.Contains(Character.getClassName(spellCastingClass))
                            select sp));
            }
        }

        private void filterUserSpellsByClass(Character.SpellCastingClasses spellCastingClass, XElement spells) {
            if (userSpellCount() > 0) {
                spells.Add((from sp in userSpellList.Elements("spell")
                            let level = (string)sp.Element("level")
                            where level != null && level.Contains(Character.getClassName(spellCastingClass))
                            select sp));
            }
        }

        private void removeHiddenSpells(XElement spells) {
            if (hiddenSpellCount() > 0) {
                foreach (string hiddenSpellName in (from hp in userSpellList.Elements("hidden_spell").Elements("spell")
                                                  select (string)hp.Element("name"))) {
                                                      (from sp in spells.Elements("spell")
                                                       where (string)sp.Element("name") == hiddenSpellName
                                                       select sp).Remove();
                }
            }

            if (hiddenCharacterSpellCount() > 0) {
                foreach (string hiddenSpellName in (from hp in charSpellList.Elements("hidden_spell").Elements("spell")
                                                    select (string)hp.Element("name"))) {
                    (from sp in spells.Elements("spell")
                     where (string)sp.Element("name") == hiddenSpellName
                     select sp).Remove();
                }
            }
        }

        public IEnumerable<XElement> byClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level) {
            XElement spells = new XElement("spells");

            filterMasterSpellsByClassAndLevel(spellCastingClass, level, spells);
            filterUserSpellsByClassAndLevel(spellCastingClass, level, spells);
            filterCharacterSpellsByClassAndLevel(spellCastingClass, level, spells);

            removeHiddenSpells(spells);

            return spells.Elements("spell");
        }

        private void filterCharacterSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, XElement spells) {
            if (characterSpellCount() > 0) {
                spells.Add((from sp in charSpellList.Elements("spell")
                            let xmlLevel = (string)sp.Element("level")
                            where xmlLevel != null && xmlLevel.Contains(Character.getClassName(spellCastingClass) + " " + level.ToString())
                            select sp));
            }
        }

        private void filterUserSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, XElement spells) {
            if (userSpellCount() > 0) {
                spells.Add((from sp in userSpellList.Elements("spell")
                            let xmlLevel = (string)sp.Element("level")
                            where xmlLevel != null && xmlLevel.Contains(Character.getClassName(spellCastingClass) + " " + level.ToString())
                            select sp));
            }
        }

        private void filterMasterSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, XElement spells) {
            spells.Add((from sp in masterSpellList.Elements("spell")
                        let xmlLevel = (string)sp.Element("level")
                        where xmlLevel != null && xmlLevel.Contains(Character.getClassName(spellCastingClass) + " " + level.ToString())
                        select sp));
        }

        /// <summary>
        /// Saves all XML files to the system.
        /// </summary>
        public void save() {
            userSpellList.Save(userXmlFile);
            if (character != null) {
                character.save();
            }
        }

        /// <summary>
        /// Remove a node from the application's custom spell list.
        /// </summary>
        /// <param name="nodeName">The name of the node to be searched on. Could be "name", "school", etc.</param>
        /// <param name="nodeValue">The value of the node matching the nodeName.</param>
        public void removeUserSpell(string nodeName, string nodeValue) {
            (from sp in userSpellList.Elements("spell")
             where (string)sp.Element(nodeName) == nodeValue
             select sp).Remove();
        }

        public void hideMasterSpell(string nodeName, string nodeValue) {
            userSpellList.Add(new XElement("hidden_spell", (from msp in masterSpellList.Elements("spell")
                                                            where (string)msp.Element(nodeName) == nodeValue
                                                            select msp)));
        }

        public void hideMasterSpellForCharacter(string nodeName, string nodeValue) {
            charSpellList.Add(new XElement("hidden_spell", (from msp in masterSpellList.Elements("spell")
                                                            where (string)msp.Element(nodeName) == nodeValue
                                                            select msp)));
        }

        public void showMasterSpell(string nodeName, string nodeValue) {
            (from hsp in userSpellList.Elements("hidden_spell")
             where (string)hsp.Element("spell").Element(nodeName) == nodeValue
             select hsp).Remove();
        }        

        public void showMasterSpellForCharacter(string nodeName, string nodeValue) {
            (from hsp in charSpellList.Elements("hidden_spell")
             where (string)hsp.Element("spell").Element(nodeName) == nodeValue
             select hsp).Remove();
        }

        public int hiddenSpellCount() {
            return userSpellList.Descendants("hidden_spell").Count();
        }

        public int hiddenCharacterSpellCount() {
            if (charSpellList != null) {
                return charSpellList.Descendants("hidden_spell").Count();
            }
            return 0;
        }

        public int totalCount() {
            int total = masterSpellList.Elements("spell").Count() + userSpellList.Elements("spell").Count();
            if (charSpellList != null) {
                total += charSpellList.Elements("spell").Count();
            }
            return total;
        }

        public int masterSpellCount() {
            return masterSpellList.Elements("spell").Count();
        }

        public int userSpellCount() {
            return userSpellList.Elements("spell").Count();
        }

        public int characterSpellCount() {
            if (character != null) {
                return character.spells().Elements("spell").Count();
            }

            return 0;
        }
    }
}
