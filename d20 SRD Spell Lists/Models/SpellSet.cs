using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using d20_SRD_Spell_Lists.Exceptions;
using System.Text.RegularExpressions;

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

        public IEnumerable<Spell> byClass(Character.SpellCastingClasses spellCastingClass) {
            List<Spell> spells = new List<Spell>();

            filterMasterSpellsByClass(spellCastingClass, spells);
            filterUserSpellsByClass(spellCastingClass, spells);
            filterCharacterSpellsByClass(spellCastingClass, spells);

            removeHiddenSpells(spells);

            return spells;
        }

        private void filterMasterSpellsByClass(Character.SpellCastingClasses spellCastingClass, List<Spell> spells) {
            spells.AddRange(querySpellsByClass(masterSpellList, spellCastingClass, false, false).ToList<Spell>());
        }

        private void filterCharacterSpellsByClass(Character.SpellCastingClasses spellCastingClass, List<Spell> spells) {
            if (characterSpellCount() > 0) {
                spells.AddRange(querySpellsByClass(charSpellList, spellCastingClass, false, true));
            }
        }

        private void filterUserSpellsByClass(Character.SpellCastingClasses spellCastingClass, List<Spell> spells) {
            if (userSpellCount() > 0) {
                spells.AddRange(querySpellsByClass(userSpellList, spellCastingClass, true, false).ToList<Spell>());
            }
        }

        private void removeHiddenSpells(List<Spell> spells) {
            if (hiddenSpellCount() > 0) {
                foreach (string hiddenSpellName in (from hp in userSpellList.Elements("hidden_spell").Elements("spell")
                                                  select (string)hp.Element("name"))) {
                                                      spells.RemoveAll(sp => sp.Name == hiddenSpellName);
                }
            }

            if (hiddenCharacterSpellCount() > 0) {
                foreach (string hiddenSpellName in (from hp in charSpellList.Elements("hidden_spell").Elements("spell")
                                                    select (string)hp.Element("name"))) {
                                                        spells.RemoveAll(sp => sp.Name == hiddenSpellName);
                }
            }
        }

        public IEnumerable<Spell> byClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level) {
            List<Spell> spells = new List<Spell>();

            filterMasterSpellsByClassAndLevel(spellCastingClass, level, spells);
            filterUserSpellsByClassAndLevel(spellCastingClass, level, spells);
            filterCharacterSpellsByClassAndLevel(spellCastingClass, level, spells);

            removeHiddenSpells(spells);

            return spells;
        }

        private void filterCharacterSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, List<Spell> spells) {
            if (characterSpellCount() > 0) {
                spells.AddRange(querySpellsByClassAndLevel(charSpellList, spellCastingClass, level, false, true));
            }
        }

        private void filterUserSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, List<Spell> spells) {
            if (userSpellCount() > 0) {
                spells.AddRange(querySpellsByClassAndLevel(userSpellList, spellCastingClass, level, true, false).ToList<Spell>());
            }
        }

        private IEnumerable<Spell> querySpellsByClassAndLevel(XElement list, Character.SpellCastingClasses spellCastingClass, int level, bool isCustom, bool isCharCustom) {
            string c = Character.getClassName(spellCastingClass);
            Regex levelReg = new Regex(@" (\d+)?");
            return (from sp in list.Elements("spell")
                    let xmlLevel = (string)sp.Element("level")
                    let xmlComp = (string)sp.Element("components")
                    let xmlDesc = (string)sp.Element("short_description")
                    where xmlLevel != null && xmlLevel.Contains(c + " " + level.ToString())
                    orderby levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value
                    select new Spell {
                        IsPrepped = false,
                        Name = sp.Element("name").Value,
                        Level = int.Parse(levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value),
                        Component = (xmlComp != null ? xmlComp : ""),
                        ShortDescription = (xmlDesc != null ? xmlDesc : ""),
                        IsCustom = isCustom,
                        IsCharCustom = isCharCustom
                    });
        }

        private IEnumerable<Spell> querySpellsByClass(XElement list, Character.SpellCastingClasses spellCastingClass, bool isCustom, bool isCharCustom) {
            string c = Character.getClassName(spellCastingClass);
            Regex levelReg = new Regex(@" (\d+),?");
            return (from sp in list.Elements("spell")
                    let xmlLevel = (string)sp.Element("level")
                    let xmlComp = (string)sp.Element("components")
                    let xmlDesc = (string)sp.Element("short_description")
                    where xmlLevel != null && xmlLevel.Contains(c)
                    orderby levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value
                    select new Spell {
                        IsPrepped = false,
                        Name = sp.Element("name").Value,
                        Level = int.Parse(levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value),
                        Component = (xmlComp != null ? xmlComp : ""),
                        ShortDescription = (xmlDesc != null ? xmlDesc : ""),
                        IsCustom = isCustom,
                        IsCharCustom = isCharCustom
                    });
        }

        private void filterMasterSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, List<Spell> spells) {
            spells.AddRange(querySpellsByClassAndLevel(masterSpellList, spellCastingClass, level, false, false).ToList<Spell>());
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
