using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using d20_SRD_Spell_Lists.Models;

namespace d20_SRD_Spell_Lists {
    public partial class FrmMain : Form {
        private SpellSet spells;
        private Character character;

        public FrmMain() {
            InitializeComponent();

            character = new Character();
            spells = new SpellSet();
            spellsDataGridView.AutoGenerateColumns = false;

            setupClassList();
        }

        private void setupClassList() {
            classComboBox.DataSource = Character.ClassNames;
            classComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            classComboBox.SelectedIndexChanged += new System.EventHandler(classComboBox_SelectedIndexChanged);
            classComboBox_SelectedIndexChanged(classComboBox, new EventArgs());
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox classList = (ComboBox)sender;

            string charClass = classList.SelectedItem.ToString();
            this.spellsDataGridView.DataSource = spells.byClass((Character.SpellCastingClasses)Enum.Parse(typeof(Character.SpellCastingClasses), charClass, true));            
        }

        private void txtStrength_Validating(object sender, CancelEventArgs e) {
            int val;
            if (txtStrength.Text != "" && !int.TryParse(txtStrength.Text, out val)) {
                errorProvider.SetError(txtStrength, "Strength should be a number or empty.");
                e.Cancel = true;
            }
        }

        private void txtStrength_TextChanged(object sender, EventArgs e) {
            if (txtStrength.Text != "") {
                character.Strength = int.Parse(txtStrength.Text);
                lblStrMod.Text = String.Format((character.StrengthMod >= 0) ? "+{0:D}" : "{0:D}", character.StrengthMod);
            }
        }

        private void txtDexterity_TextChanged(object sender, EventArgs e) {
            if (txtDexterity.Text != "") {
                character.Dexterity = int.Parse(txtDexterity.Text);
                lblDexMod.Text = String.Format((character.DexterityMod >= 0) ? "+{0:D}" : "{0:D}", character.DexterityMod);
            }
        }

        private void txtConstitution_TextChanged(object sender, EventArgs e) {
            if (txtConstitution.Text != "") {
                character.Constitution = int.Parse(txtConstitution.Text);
                lblConMod.Text = String.Format((character.Constitution >= 0) ? "+{0:D}" : "{0:D}", character.ConstitutionMod);
            }
        }

        private void txtIntelligence_TextChanged(object sender, EventArgs e) {
            if (txtIntelligence.Text != "") {
                character.Intelligence = int.Parse(txtIntelligence.Text);
                lblIntMod.Text = String.Format((character.Intelligence >= 0) ? "+{0:D}" : "{0:D}", character.IntelligenceMod);
            }
        }

        private void txtWisdom_TextChanged(object sender, EventArgs e) {
            if (txtWisdom.Text != "") {
                character.Wisdom = int.Parse(txtWisdom.Text);
                lblWisMod.Text = String.Format((character.Wisdom >= 0) ? "+{0:D}" : "{0:D}", character.WisdomMod);
            }
        }

        private void txtCharisma_TextChanged(object sender, EventArgs e) {
            if (txtCharisma.Text != "") {
                character.Charisma = int.Parse(txtCharisma.Text);
                lblChaMod.Text = String.Format((character.Charisma >= 0) ? "+{0:D}" : "{0:D}", character.CharismaMod);
            }
        }
    }
}
