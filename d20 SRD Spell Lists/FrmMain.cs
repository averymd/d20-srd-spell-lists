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
    }
}
