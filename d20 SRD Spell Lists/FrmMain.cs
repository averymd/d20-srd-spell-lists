﻿using System;
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
using Printing.DataGridViewPrint.Tools;
using System.Reflection;
using System.Collections.ObjectModel;

namespace d20_SRD_Spell_Lists {
    public partial class FrmMain : Form {
        private MasterSpellSet spells;
        private Character character;
        private string characterFile;
        private bool loadingCharacter;
        private bool dirtyCharacter;
        private PrintingDataGridViewProvider printProvider;

        public FrmMain() {
            InitializeComponent();

            this.Text = AssemblyTitle;

            character = new Character();
            spells = new MasterSpellSet();
            spellsDataGridView.AutoGenerateColumns = false;
            loadingCharacter = false;
            dirtyCharacter = false;

            setupAttributes();
            setupClassList();
            setupSpells();

            //spellsDataGridView.CellValueChanged += new DataGridViewCellEventHandler(spellsDataGridView_CellValueChanged);
        }

        private void setupPrinting() {
            printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.DocumentName = "D20 3.5 SRD Spell List";
            printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(40, 40, 40, 20);
            printDoc.DefaultPageSettings.Landscape = true;
            printProvider = PrintingDataGridViewProvider.Create(printDoc, spellsDataGridView, true, true, true,
                new TitlePrintBlock() {
                    Title = printDoc.DocumentName,
                    DCs = this.tableLayoutPanel1,
                    CharName = character.Name,
                    CharClass = Character.getSpellcastingClassName(character.CharacterClass),
                    CharAttr = character.SpellCastingAttribute.ToString(),
                    CharAttrMod = character.SpellCastingAttributeModAsString(),
                    CharAttrName = character.SpellCastingAttributeName
                },
                new HeaderPrintBlock() {
                    Header = character.Name
                },
                new FooterPrintBlock() {
                    Footer = "Page XX of YY"
                });
        }

        private void setupSpells() {
            this.spellsDataGridView.DataSource = character.Spells;
        }

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
                if (!loadingCharacter) {
                    offerNewSpells();
                }
            }

            dirtyCharacter = true;
        }

        private void offerNewSpells() {
            string question = "Would you like to add all base " + character.CharacterClass.ToString() + " spells to the list?";
            string title = "Add all spells?";
            var result = MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                character.addAllClassSpells();
            }
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
                lblSpellCastingAttributeMod.Text = character.SpellCastingAttributeModAsString();
            }
        }

        

        private void txtSpellCastingAttribute_LostFocus(object sender, EventArgs e) {
            updateSpellDCs();
            updateExtraSpells();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e) {
            if (characterFile != null && characterFile != "") {
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
                dirtyCharacter = false;
            }
        }
        
        private void txtCharacter_TextChanged(object sender, EventArgs e) {
            character.Name = txtCharacter.Text;
            dirtyCharacter = true;
        }

        private bool promptSaveAndContinue() {
            if (dirtyCharacter) {
                string msg = "Do you want to save your current character?";
                string title = "Save?";
                var result = MessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes) {
                    saveToolStripButton.PerformClick();
                    return true;
                } else if (result == System.Windows.Forms.DialogResult.Cancel) {
                    return false;
                }
            }

            return true;
        }

        private void openToolStripButton_Click(object sender, EventArgs e) {
            if (promptSaveAndContinue()) {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Character files (*.xml)|*.xml|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    try {
                        characterFile = ofd.FileName;
                        loadingCharacter = true;
                        loadCharacter();
                        loadValues();
                    } catch (Exception ex) {
                        MessageBox.Show("Error: Could not read the character file. Original error: " + ex.Message);
                    } finally {
                        loadingCharacter = false;
                        dirtyCharacter = false;
                    }
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
                character.Spells.Sort(new SpellInequalityComparer());
                dirtyCharacter = true;
            }
        }

        private void spellsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (isEditButtonCell(e)) {
                Spell editItem = (Spell)spellsDataGridView.Rows[e.RowIndex].DataBoundItem;
                FrmAddEdit editForm = new FrmAddEdit(true, character, editItem);
                var result = editForm.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK) {
                    character.Spells[character.Spells.IndexOf(editItem)] = editForm.spell;
                    dirtyCharacter = true;
                }
            } else if (isDeleteButtonCell(e)) {
                Spell deleteItem = (Spell)spellsDataGridView.Rows[e.RowIndex].DataBoundItem;
                string msg = "Are you sure you want to delete this spell from your character?";
                string title = "Confirm";
                var result = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes) {
                    character.Spells.Remove(deleteItem);
                    dirtyCharacter = true;
                }
            }
        }

        private bool isDeleteButtonCell(DataGridViewCellEventArgs e) {
            if (spellsDataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.ColumnIndex == 6) {
                return true;
            }
            return false;
        }

        private bool isEditButtonCell(DataGridViewCellEventArgs e) {
            if (spellsDataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.ColumnIndex == 5) {
                return true;
            }
            return false;
        }

        private void helpToolStripButton_Click(object sender, EventArgs e) {
            FrmCredits credits = new FrmCredits();
            credits.ShowDialog();
        }

        private void printToolStripButton_Click(object sender, EventArgs e) {
            spellsDataGridView.Columns["editColumn"].Visible = false;
            spellsDataGridView.Columns["deleteColumn"].Visible = false;
            setupPrinting();
            PrintDialog pd = new PrintDialog();
            pd.Document = printDoc;
            pd.ShowDialog();
            spellsDataGridView.Columns["editColumn"].Visible = true;
            spellsDataGridView.Columns["deleteColumn"].Visible = true;
        }

        private void printPreviewToolstripButton_Click(object sender, EventArgs e) {
            spellsDataGridView.Columns["editColumn"].Visible = false;
            spellsDataGridView.Columns["deleteColumn"].Visible = false;
            setupPrinting();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDoc;
            ppd.ShowDialog();
            spellsDataGridView.Columns["editColumn"].Visible = true;
            spellsDataGridView.Columns["deleteColumn"].Visible = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case (Keys.Control | Keys.O):
                    openToolStripButton.PerformClick();
                    return true;
                case (Keys.Control | Keys.S):
                    saveToolStripButton.PerformClick();
                    return true;
                case (Keys.Control | Keys.N):
                    newToolStripButton.PerformClick();
                    return true;
                case (Keys.Control | Keys.P):
                    printToolStripButton.PerformClick();
                    return true;
                case (Keys.Control | Keys.H):
                    helpToolStripButton.PerformClick();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }            
        }

        private void newToolStripButton_Click(object sender, EventArgs e) {
            if (promptSaveAndContinue()) {
                loadingCharacter = true;
                character = new Character();
                character.SpellCastingAttribute = 10;
                loadValues();
                charClassComboBox.SelectedIndex = 0;
                dirtyCharacter = false;
                loadingCharacter = false;
            }
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e) {
            if (sender != this || !promptSaveAndContinue()) {
                e.Cancel = true;
            }
        }

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
    }
}
