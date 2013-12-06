using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using d20_SRD_Spell_Lists.Exceptions;
using System.Text.RegularExpressions;
using System.Collections;

namespace d20_SRD_Spell_Lists.Models {
    public class MasterSpellSet {
        private XElement masterSpellList;
        
        public MasterSpellSet() {
            loadXML(Properties.Settings.Default.MasterSpells);
        }

        private void loadXML(string _masterXmlFile) {
            // Load the XML file.
            if (_masterXmlFile == null) {
                _masterXmlFile = Properties.Settings.Default.MasterSpells;
            }
            masterSpellList = XElement.Load(_masterXmlFile);
        }      

        public List<Spell> byClass(Character.SpellCastingClasses spellCastingClass) {
            List<Spell> spells = new List<Spell>();

            filterMasterSpellsByClass(spellCastingClass, spells);

            return spells;
        }

        private void filterMasterSpellsByClass(Character.SpellCastingClasses spellCastingClass, List<Spell> spells) {
            spells.AddRange(querySpellsByClass(masterSpellList, spellCastingClass, false, false).ToList<Spell>());
        }

        public List<Spell> byClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level) {
            List<Spell> spells = new List<Spell>();

            filterMasterSpellsByClassAndLevel(spellCastingClass, level, spells);
            
            return spells;
        }

        private List<Spell> querySpellsByClassAndLevel(XElement list, Character.SpellCastingClasses spellCastingClass, int level, bool isCustom, bool isCharCustom) {
            string c = Character.getSpellcastingClassName(spellCastingClass);
            Regex levelReg = new Regex(@" (\d+)?");
            return (from sp in list.Elements("spell")
                    let xmlLevel = (string)sp.Element("level")
                    where xmlLevel != null && xmlLevel.Contains(c + " " + level.ToString())
                    orderby levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value
                    select new Spell {
                        Name = (string)sp.Element("name"),
                        AltName = (string)sp.Element("altname"),
                        School = (string)sp.Element("school"),
                        Subschool = (string)sp.Element("subschool"),
                        Descriptor = (string)sp.Element("descriptor"),
                        FullLevel = (string)sp.Element("level"),
                        Level = int.Parse(levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value),
                        Components = (string)sp.Element("components"),
                        CastingTime = (string)sp.Element("casting_time"),
                        Range = (string)sp.Element("range"),
                        Effect = (string)sp.Element("effect"),
                        Target = (string)sp.Element("target"),
                        Duration = (string)sp.Element("duration"),
                        SavingThrow = (string)sp.Element("saving_throw"),
                        SpellResistance = (string)sp.Element("sp_resistance"),
                        ShortDescription = (string)sp.Element("short_description"),
                        ArcaneMaterialComponents = (string)sp.Element("arcane_material_components"),
                        Description = (string)sp.Element("description"),
                        FullText = (string)sp.Element("full_text"),
                        Reference = (string)sp.Element("reference")
                    }).ToList();
        }

        private List<Spell> querySpellsByClass(XElement list, Character.SpellCastingClasses spellCastingClass, bool isCustom, bool isCharCustom) {
            string c = Character.getSpellcastingClassName(spellCastingClass);
            Regex levelReg = new Regex(@" (\d+),?");
            return (from sp in list.Elements("spell")
                    let xmlLevel = (string)sp.Element("level")
                    where xmlLevel != null && xmlLevel.Contains(c)
                    orderby levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value
                    select new Spell {
                        Name = (string)sp.Element("name"),
                        AltName = (string)sp.Element("altname"),
                        School = (string)sp.Element("school"),
                        Subschool = (string)sp.Element("subschool"),
                        Descriptor = (string)sp.Element("descriptor"),
                        FullLevel = (string)sp.Element("level"),
                        Level = int.Parse(levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value),
                        Components = (string)sp.Element("components"),
                        CastingTime = (string)sp.Element("casting_time"),
                        Range = (string)sp.Element("range"),
                        Effect = (string)sp.Element("effect"),
                        Target = (string)sp.Element("target"),
                        Duration = (string)sp.Element("duration"),
                        SavingThrow = (string)sp.Element("saving_throw"),
                        SpellResistance = (string)sp.Element("sp_resistance"),
                        ShortDescription = (string)sp.Element("short_description"),
                        ArcaneMaterialComponents = (string)sp.Element("arcane_material_components"),
                        Description = (string)sp.Element("description"),
                        FullText = (string)sp.Element("full_text"),
                        Reference = (string)sp.Element("reference")
                    }).ToList();
        }

        private void filterMasterSpellsByClassAndLevel(Character.SpellCastingClasses spellCastingClass, int level, List<Spell> spells) {
            spells.AddRange(querySpellsByClassAndLevel(masterSpellList, spellCastingClass, level, false, false).ToList<Spell>());
        }

        public int totalCount() {
            return masterSpellList.Elements("spell").Count();
        }

        public IList asChoosableList() {
            ArrayList spells = new ArrayList();
            spells.Add(new { Name = "--", Display = "Base spells..."});
            foreach (XElement spell in (from sp in masterSpellList.Elements("spell")
                                        orderby (string)sp.Element("name")
                                        select sp)){
                spells.Add(new {
                    Name = (string)spell.Element("name"),
                    Display = (string)spell.Element("name") + (spell.Element("level") != null ? " (" + (string)spell.Element("level") + ")" : "")
                });
            }

            return spells;
        }

        public Spell byName(string name, Character.SpellCastingClasses characterClass) {
            string c = Character.getSpellcastingClassName(characterClass);
            Regex levelReg = new Regex(@" (\d+),?");
            return (from sp in masterSpellList.Elements("spell")
                    let xmlLevel = (string)sp.Element("level") ?? "0"
                    orderby (string)sp.Element("name")
                    where (string)sp.Element("name") == name
                    select new Spell {
                        Name = (string)sp.Element("name"),
                        AltName = (string)sp.Element("altname"),
                        School = (string)sp.Element("school"),
                        Subschool = (string)sp.Element("subschool"),
                        Descriptor = (string)sp.Element("descriptor"),
                        FullLevel = (string)sp.Element("level"),
                        Level = int.Parse((xmlLevel.IndexOf(c) >= 0 ? levelReg.Match(xmlLevel, xmlLevel.IndexOf(c)).Groups[1].Value : levelReg.Match(xmlLevel).Groups[1].Value)),
                        Components = (string)sp.Element("components"),
                        CastingTime = (string)sp.Element("casting_time"),
                        Range = (string)sp.Element("range"),
                        Effect = (string)sp.Element("effect"),
                        Target = (string)sp.Element("target"),
                        Duration = (string)sp.Element("duration"),
                        SavingThrow = (string)sp.Element("saving_throw"),
                        SpellResistance = (string)sp.Element("sp_resistance"),
                        ShortDescription = (string)sp.Element("short_description"),
                        ArcaneMaterialComponents = (string)sp.Element("arcane_material_components"),
                        Description = (string)sp.Element("description"),
                        FullText = (string)sp.Element("full_text"),
                        Reference = (string)sp.Element("reference")
                    }).FirstOrDefault<Spell>();
        }
    }
}
