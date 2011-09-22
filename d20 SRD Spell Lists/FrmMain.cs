using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using d20_SRD_Spell_Lists.Models;
using d20_SRD_Spell_Lists.Exceptions;
using System.Xml.Serialization;
using System.IO;

namespace d20_SRD_Spell_Lists {
    public partial class FrmMain : Form {
        private MasterSpellSet spells;
        private Character character;
        private string characterFile;

        public FrmMain() {
            InitializeComponent();

            character = new Character();
            spells = new MasterSpellSet();
            spellsDataGridView.AutoGenerateColumns = false;

            setupAttributes();
            setupClassList();
            setupSpells();

            //spellsDataGridView.CellValueChanged += new DataGridViewCellEventHandler(spellsDataGridView_CellValueChanged);
        }

        private void setupSpells() {
            this.spellsDataGridView.DataSource = character.Spells;
        }

        //private void spellsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
        //    string question = "Should this update apply to just this character's spell list?";
        //    string title = "Spell Update";

        //    var result = MessageBox.Show(question, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        //    if (result == DialogResult.Yes) {
        //        string newValue = spellsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
        //        Spell newSpell = spellsDataGridView.Rows[e.RowIndex].DataBoundItem as Spell;
        //        // If it's a custom app spell already, hide that one for the character, then add the character spell.
        //        if (newSpell.IsCustom) {
        //            if (spellsDataGridView.Columns[e.ColumnIndex].HeaderText != "Name") {
        //                spells.hideMasterSpellForCharacter("name", newSpell.Name);
        //            } else {
        //                spells.hideMasterSpellForCharacter("short_description", newSpell.ShortDescription);
        //            }
        //            spells.addCharacterSpell(newSpell, Character.getSpellcastingClass(charClassComboBox.SelectedItem.ToString()));
        //            newSpell.IsCharCustom = true;
        //        } else if (newSpell.IsCharCustom) {
        //            // But what if it's already a character-specific spell?! ...then I just need to save it.
        //            // ...so... does that mean do nothing?
        //        }
        //    } else if (result == DialogResult.No) {
        //        Spell newSpell = spellsDataGridView.Rows[e.RowIndex].DataBoundItem as Spell;
        //        if (newSpell.IsCharCustom) {
        //            // It's a custom character spell, which means I should hide the chara
        //        }
        //    }
        //}

        private void setupAttributes() {
            txtSpellCastingAttribute.LostFocus += new EventHandler(txtSpellCastingAttribute_LostFocus);
            txtSpellCastingAttribute_TextChanged(txtSpellCastingAttribute, new EventArgs());
        }

        private void setupClassList() {
            List<string> classOptions = new List<string>();
            classOptions.Add("Choose a class...");
            classOptions.AddRange(Character.ClassNames);
            charClassComboBox.DataSource = classOptions;
            charClassComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            charClassComboBox.SelectedIndexChanged += new System.EventHandler(charClassComboBox_SelectedIndexChanged);
        }

        private void charClassComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox classList = (ComboBox)sender;

            if (classList.SelectedItem.ToString() != "Choose a class...") {
                updateClassInformation(classList);
                updateSpellDCs();
                updateExtraSpells();
                offerNewSpells();
            }
        }

        private void offerNewSpells() {
            string question = "Would you like to add all base " + character.CharacterClass.ToString() + " spells to the list?";
            string title = "Add all spells?";
            var result = MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                character.addAllClassSpells();
                refreshSpellList();
            }
        }

        private void refreshSpellList() {
            spellsDataGridView.DataSource = null;
            setupSpells();
        }

        private void updateClassInformation(ComboBox classList) {
            string charClass = classList.SelectedItem.ToString();
            character.CharacterClass = (Character.SpellCastingClasses)Enum.Parse(typeof(Character.SpellCastingClasses), charClass);
            lblSpellCastingAttribute.Text = character.SpellCastingAttributeName + ":";
        }

        private void updateExtraSpells() {
            for (int i = 0; i < character.BonusSpells.Length; i++) {
                if (character.BonusSpells[i] >= 0) {
                    ((Label)this.Controls.Find("lblExtra" + i, true)[0]).Text = character.BonusSpells[i].ToString();
                } else {
                    ((Label)this.Controls.Find("lblExtra" + i, true)[0]).Text = "\u2014";
                }
            }
        }

        private void updateSpellDCs() {
            for (int i = 0; i < 10; i++) {
                ((Label)this.Controls.Find("lblDC" + i, true)[0]).Text = (10 + i + character.SpellCastingAttributeMod).ToString();
            }
        }

        private void txtSpellCastingAttribute_TextChanged(object sender, EventArgs e) {
            if (txtSpellCastingAttribute.Text != "") {
                character.SpellCastingAttribute = int.Parse(txtSpellCastingAttribute.Text);
                lblSpellCastingAttributeMod.Text = String.Format((character.SpellCastingAttributeMod >= 0) ? "+{0:D}" : "{0:D}", character.SpellCastingAttributeMod);
            }
        }

        private void txtSpellCastingAttribute_LostFocus(object sender, EventArgs e) {
            updateSpellDCs();
            updateExtraSpells();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e) {
            if (characterFile != "") {
                try {
                    saveCharacter();
                } catch (IOException) {
                    getFilenameFromUserAndSave();
                }
            } else {
                getFilenameFromUserAndSave();
            }
        }

        private void getFilenameFromUserAndSave() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Character files (*.xml)|*.xml|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK) {
                this.characterFile = sfd.FileName;
                saveCharacter();
            }
        }
       
        private void saveCharacter() {
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            using (TextWriter writer = new StreamWriter(characterFile)) {
                serializer.Serialize(writer, character);
            }
        }
        
        private void txtCharacter_TextChanged(object sender, EventArgs e) {
            character.Name = txtCharacter.Text;
        }

        private void openToolStripButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Character files (*.xml)|*.xml|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK) {
                try {
                    characterFile = ofd.FileName;
                    loadCharacter();
                    loadValues();
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read the character file. Original error: " + ex.Message);
                }
            }
        }

        private void loadCharacter() {
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            using (FileStream f = new FileStream(characterFile, FileMode.Open)) {
                character = (Character)serializer.Deserialize(f);
            }
        }

        private void loadValues() {
            txtCharacter.Text = character.Name;
            txtSpellCastingAttribute.Text = character.SpellCastingAttribute.ToString();
            charClassComboBox.SelectedItem = Character.getSpellcastingClassName(character.CharacterClass);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            FrmAddEdit addForm = new FrmAddEdit(false, character);
            var result = addForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK) {
                character.Spells.Add(addForm.spell);
                refreshSpellList();
            }
        }
    }
}
