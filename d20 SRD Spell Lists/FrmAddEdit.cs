using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using d20_SRD_Spell_Lists.Models;
using System.Collections;

namespace d20_SRD_Spell_Lists {
    public partial class FrmAddEdit : Form {
        private MasterSpellSet spellList;
        public Spell spell;
        private Character character;

        public FrmAddEdit(bool editMode, Character _character, Spell _spell = null) {
            InitializeComponent();

            if (editMode) {
                this.Text = "Edit a Spell";
            }

            if (_spell != null) {
                spell = _spell;
                loadSpell();
            } else {
                spell = new Spell();
            }
            character = _character;
            setupBaseSpells();
            txtName.LostFocus += new EventHandler(txtName_LostFocus);
        }

        private void loadSpell() {
            txtName.Text = spell.Name;
            txtLevel.Value = spell.Level;
            txtComponents.Text = spell.Components;
            txtDescription.Text = spell.ShortDescription;
        }

        void txtName_LostFocus(object sender, EventArgs e) {
            if (txtName.Text != "") {
                baseSpellComboBox.SelectedValue = "--";
            }
        }

        private void setupBaseSpells() {
            spellList = new MasterSpellSet();
            baseSpellComboBox.DisplayMember = "Display";
            baseSpellComboBox.ValueMember = "Name";
            baseSpellComboBox.DataSource = spellList.asChoosableList();
            baseSpellComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void baseSpellComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (baseSpellComboBox.SelectedValue.ToString() != "--") {
                clearCustomSpellFields();
            }
        }

        private void clearCustomSpellFields() {
            txtName.Text = "";
            txtLevel.Value = 0;
            txtComponents.Text = "";
            txtDescription.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e) {
            storeSpell();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void storeSpell() {
            if (baseSpellComboBox.SelectedValue.ToString() == "--") {
                // Use the custom Spell
                spell.Name = txtName.Text;
                spell.Components = txtComponents.Text;
                spell.Level = (int)txtLevel.Value;
                spell.FullLevel = Character.getSpellcastingClassName(character.CharacterClass) + " " + spell.Level.ToString();
                spell.ShortDescription = txtDescription.Text;
            } else {
                spell = spellList.byName(baseSpellComboBox.SelectedValue.ToString(), character.CharacterClass);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
