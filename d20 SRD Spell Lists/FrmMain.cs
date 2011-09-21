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

namespace d20_SRD_Spell_Lists {
    public partial class FrmMain : Form {
        private SpellSet spells;
        private Character character;

        public FrmMain() {
            InitializeComponent();

            character = new Character();
            spells = new SpellSet();
            spellsDataGridView.AutoGenerateColumns = false;

            setupAttributes();
            setupClassList();

            txtIntelligence.LostFocus += new EventHandler(txtIntelligence_LostFocus);
            txtWisdom.LostFocus += new EventHandler(txtWisdom_LostFocus);
            txtCharisma.LostFocus += new EventHandler(txtCharisma_LostFocus);
        }

        private void setupAttributes() {
            txtStrength_TextChanged(txtStrength, new EventArgs());
            txtDexterity_TextChanged(txtDexterity, new EventArgs());
            txtConstitution_TextChanged(txtConstitution, new EventArgs());
            txtIntelligence_TextChanged(txtIntelligence, new EventArgs());
            txtWisdom_TextChanged(txtWisdom, new EventArgs());
            txtCharisma_TextChanged(txtCharisma, new EventArgs());
        }

        private void setupClassList() {
            classComboBox.DataSource = Character.ClassNames;
            classComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            classComboBox.SelectedIndexChanged += new System.EventHandler(classComboBox_SelectedIndexChanged);
            classComboBox_SelectedIndexChanged(classComboBox, new EventArgs());

            charClassComboBox.DataSource = Character.ClassNames;
            charClassComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            charClassComboBox.SelectedIndexChanged += new System.EventHandler(charClassComboBox_SelectedIndexChanged);
            charClassComboBox_SelectedIndexChanged(charClassComboBox, new EventArgs());
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox classList = (ComboBox)sender;

            string charClass = classList.SelectedItem.ToString();
            BindingList<Spell> spellList = new BindingList<Spell>(spells.byClass((Character.SpellCastingClasses)Enum.Parse(typeof(Character.SpellCastingClasses), charClass, true)));
            this.spellsDataGridView.DataSource = spellList;
        }

        private void charClassComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox classList = (ComboBox)sender;

            string charClass = classList.SelectedItem.ToString();
            character.CharacterClass = (Character.SpellCastingClasses)Enum.Parse(typeof(Character.SpellCastingClasses), charClass);
            this.classComboBox.SelectedItem = charClassComboBox.SelectedItem;
            updateSpellDCs();
            updateExtraSpells();
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

        private void txtIntelligence_LostFocus(object sender, EventArgs e) {
            if (character.SpellCastingAttribute == character.Intelligence) {
                updateSpellDCs();
                updateExtraSpells();
            }
        }

        private void txtWisdom_TextChanged(object sender, EventArgs e) {
            if (txtWisdom.Text != "") {
                character.Wisdom = int.Parse(txtWisdom.Text);
                lblWisMod.Text = String.Format((character.Wisdom >= 0) ? "+{0:D}" : "{0:D}", character.WisdomMod);
            }
        }

        private void txtWisdom_LostFocus(object sender, EventArgs e) {
            if (character.SpellCastingAttribute == character.Wisdom) {
                updateSpellDCs();
                updateExtraSpells();
            }
        }

        private void txtCharisma_TextChanged(object sender, EventArgs e) {
            if (txtCharisma.Text != "") {
                character.Charisma = int.Parse(txtCharisma.Text);
                lblChaMod.Text = String.Format((character.Charisma >= 0) ? "+{0:D}" : "{0:D}", character.CharismaMod);
            }
        }

        private void txtCharisma_LostFocus(object sender, EventArgs e) {
            if (character.SpellCastingAttribute == character.Charisma) {
                updateSpellDCs();
                updateExtraSpells();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e) {
            try {
                spells.save();
                character.save();
            } catch (NoCharacterFileException) {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.Filter = "Character files (*.xml)|*.xml|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK) {
                    string filename = sfd.FileName;
                    character.FileName = filename;
                    character.save();
                }
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
                    character = new Character(ofd.FileName);
                    loadValues();
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read the character file. Original error: " + ex.Message);
                }
            }
        }

        private void loadValues() {
            txtCharacter.Text = character.Name;
            txtStrength.Text = character.Strength.ToString();
            txtDexterity.Text = character.Dexterity.ToString();
            txtConstitution.Text = character.Constitution.ToString();
            txtIntelligence.Text = character.Intelligence.ToString();
            txtWisdom.Text = character.Wisdom.ToString();
            txtCharisma.Text = character.Charisma.ToString();
            charClassComboBox.SelectedItem = Character.getClassName(character.CharacterClass);
        }
    }
}
