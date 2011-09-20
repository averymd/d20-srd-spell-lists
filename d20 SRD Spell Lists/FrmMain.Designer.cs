namespace d20_SRD_Spell_Lists {
    partial class FrmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.spellListTab = new System.Windows.Forms.TabPage();
            this.spellsDataGridView = new System.Windows.Forms.DataGridView();
            this.prepColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.spellNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.charCustomColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.characterTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStrength = new System.Windows.Forms.MaskedTextBox();
            this.lblDexMod = new System.Windows.Forms.Label();
            this.lblConMod = new System.Windows.Forms.Label();
            this.lblIntMod = new System.Windows.Forms.Label();
            this.lblWisMod = new System.Windows.Forms.Label();
            this.lblChaMod = new System.Windows.Forms.Label();
            this.lblStrMod = new System.Windows.Forms.Label();
            this.lblModifiers = new System.Windows.Forms.Label();
            this.txtDexterity = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConstitution = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIntelligence = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWisdom = new System.Windows.Forms.MaskedTextBox();
            this.lblIntelligence = new System.Windows.Forms.Label();
            this.txtCharisma = new System.Windows.Forms.MaskedTextBox();
            this.lblWisdom = new System.Windows.Forms.Label();
            this.lblCharisma = new System.Windows.Forms.Label();
            this.txtCharacter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDirections = new System.Windows.Forms.Label();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainTabControl.SuspendLayout();
            this.spellListTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsDataGridView)).BeginInit();
            this.characterTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.spellListTab);
            this.mainTabControl.Controls.Add(this.characterTab);
            this.mainTabControl.Location = new System.Drawing.Point(0, 30);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(784, 534);
            this.mainTabControl.TabIndex = 0;
            // 
            // spellListTab
            // 
            this.spellListTab.Controls.Add(this.spellsDataGridView);
            this.spellListTab.Controls.Add(this.classComboBox);
            this.spellListTab.Controls.Add(this.label1);
            this.spellListTab.Location = new System.Drawing.Point(4, 22);
            this.spellListTab.Name = "spellListTab";
            this.spellListTab.Padding = new System.Windows.Forms.Padding(3);
            this.spellListTab.Size = new System.Drawing.Size(776, 508);
            this.spellListTab.TabIndex = 0;
            this.spellListTab.Text = "Spell List";
            this.spellListTab.UseVisualStyleBackColor = true;
            // 
            // spellsDataGridView
            // 
            this.spellsDataGridView.AllowUserToOrderColumns = true;
            this.spellsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spellsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spellsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prepColumn,
            this.spellNameColumn,
            this.componentColumn,
            this.descColumn,
            this.customColumn,
            this.charCustomColumn});
            this.spellsDataGridView.Location = new System.Drawing.Point(3, 44);
            this.spellsDataGridView.Name = "spellsDataGridView";
            this.spellsDataGridView.Size = new System.Drawing.Size(770, 461);
            this.spellsDataGridView.TabIndex = 2;
            // 
            // prepColumn
            // 
            this.prepColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prepColumn.DataPropertyName = "IsPrepped";
            this.prepColumn.HeaderText = "Prep?";
            this.prepColumn.Name = "prepColumn";
            this.prepColumn.Width = 41;
            // 
            // spellNameColumn
            // 
            this.spellNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.spellNameColumn.DataPropertyName = "Name";
            this.spellNameColumn.HeaderText = "Name";
            this.spellNameColumn.Name = "spellNameColumn";
            this.spellNameColumn.Width = 60;
            // 
            // componentColumn
            // 
            this.componentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.componentColumn.DataPropertyName = "Components";
            this.componentColumn.HeaderText = "Comp";
            this.componentColumn.Name = "componentColumn";
            this.componentColumn.Width = 59;
            // 
            // descColumn
            // 
            this.descColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descColumn.DataPropertyName = "ShortDescription";
            this.descColumn.HeaderText = "Description";
            this.descColumn.Name = "descColumn";
            // 
            // customColumn
            // 
            this.customColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.customColumn.DataPropertyName = "IsCustom";
            this.customColumn.HeaderText = "Custom?";
            this.customColumn.Name = "customColumn";
            this.customColumn.ReadOnly = true;
            this.customColumn.Width = 54;
            // 
            // charCustomColumn
            // 
            this.charCustomColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.charCustomColumn.DataPropertyName = "IsCharCustom";
            this.charCustomColumn.HeaderText = "Char?";
            this.charCustomColumn.Name = "charCustomColumn";
            this.charCustomColumn.ReadOnly = true;
            this.charCustomColumn.Width = 41;
            // 
            // classComboBox
            // 
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(49, 6);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(121, 21);
            this.classComboBox.TabIndex = 1;
            this.classComboBox.Text = "Choose a class:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class:";
            // 
            // characterTab
            // 
            this.characterTab.Controls.Add(this.groupBox1);
            this.characterTab.Controls.Add(this.txtCharacter);
            this.characterTab.Controls.Add(this.label2);
            this.characterTab.Controls.Add(this.lblDirections);
            this.characterTab.Location = new System.Drawing.Point(4, 22);
            this.characterTab.Name = "characterTab";
            this.characterTab.Padding = new System.Windows.Forms.Padding(3);
            this.characterTab.Size = new System.Drawing.Size(776, 508);
            this.characterTab.TabIndex = 1;
            this.characterTab.Text = "Character";
            this.characterTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStrength);
            this.groupBox1.Controls.Add(this.lblDexMod);
            this.groupBox1.Controls.Add(this.lblConMod);
            this.groupBox1.Controls.Add(this.lblIntMod);
            this.groupBox1.Controls.Add(this.lblWisMod);
            this.groupBox1.Controls.Add(this.lblChaMod);
            this.groupBox1.Controls.Add(this.lblStrMod);
            this.groupBox1.Controls.Add(this.lblModifiers);
            this.groupBox1.Controls.Add(this.txtDexterity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtConstitution);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIntelligence);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWisdom);
            this.groupBox1.Controls.Add(this.lblIntelligence);
            this.groupBox1.Controls.Add(this.txtCharisma);
            this.groupBox1.Controls.Add(this.lblWisdom);
            this.groupBox1.Controls.Add(this.lblCharisma);
            this.groupBox1.Location = new System.Drawing.Point(15, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 229);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(104, 40);
            this.txtStrength.Mask = "00";
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(33, 20);
            this.txtStrength.TabIndex = 20;
            this.txtStrength.Text = "10";
            this.txtStrength.ValidatingType = typeof(int);
            this.txtStrength.TextChanged += new System.EventHandler(txtStrength_TextChanged);
            // 
            // lblDexMod
            // 
            this.lblDexMod.AutoSize = true;
            this.lblDexMod.Location = new System.Drawing.Point(163, 69);
            this.lblDexMod.Name = "lblDexMod";
            this.lblDexMod.Size = new System.Drawing.Size(13, 13);
            this.lblDexMod.TabIndex = 21;
            this.lblDexMod.Text = "0";
            // 
            // lblConMod
            // 
            this.lblConMod.AutoSize = true;
            this.lblConMod.Location = new System.Drawing.Point(163, 95);
            this.lblConMod.Name = "lblConMod";
            this.lblConMod.Size = new System.Drawing.Size(13, 13);
            this.lblConMod.TabIndex = 20;
            this.lblConMod.Text = "0";
            // 
            // lblIntMod
            // 
            this.lblIntMod.AutoSize = true;
            this.lblIntMod.Location = new System.Drawing.Point(163, 121);
            this.lblIntMod.Name = "lblIntMod";
            this.lblIntMod.Size = new System.Drawing.Size(13, 13);
            this.lblIntMod.TabIndex = 19;
            this.lblIntMod.Text = "0";
            // 
            // lblWisMod
            // 
            this.lblWisMod.AutoSize = true;
            this.lblWisMod.Location = new System.Drawing.Point(163, 147);
            this.lblWisMod.Name = "lblWisMod";
            this.lblWisMod.Size = new System.Drawing.Size(13, 13);
            this.lblWisMod.TabIndex = 18;
            this.lblWisMod.Text = "0";
            // 
            // lblChaMod
            // 
            this.lblChaMod.AutoSize = true;
            this.lblChaMod.Location = new System.Drawing.Point(163, 173);
            this.lblChaMod.Name = "lblChaMod";
            this.lblChaMod.Size = new System.Drawing.Size(13, 13);
            this.lblChaMod.TabIndex = 17;
            this.lblChaMod.Text = "0";
            // 
            // lblStrMod
            // 
            this.lblStrMod.AutoSize = true;
            this.lblStrMod.Location = new System.Drawing.Point(163, 43);
            this.lblStrMod.Name = "lblStrMod";
            this.lblStrMod.Size = new System.Drawing.Size(13, 13);
            this.lblStrMod.TabIndex = 16;
            this.lblStrMod.Text = "0";
            // 
            // lblModifiers
            // 
            this.lblModifiers.AutoSize = true;
            this.lblModifiers.Location = new System.Drawing.Point(153, 16);
            this.lblModifiers.Name = "lblModifiers";
            this.lblModifiers.Size = new System.Drawing.Size(52, 13);
            this.lblModifiers.TabIndex = 15;
            this.lblModifiers.Text = "Modifiers:";
            // 
            // txtDexterity
            // 
            this.txtDexterity.Location = new System.Drawing.Point(104, 66);
            this.txtDexterity.Name = "txtDexterity";
            this.txtDexterity.Size = new System.Drawing.Size(33, 20);
            this.txtDexterity.TabIndex = 21;
            this.txtDexterity.Text = "10";
            this.txtDexterity.TextChanged += new System.EventHandler(this.txtDexterity_TextChanged);
            this.txtDexterity.Mask = "00";
            this.txtDexterity.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Strength:";
            // 
            // txtConstitution
            // 
            this.txtConstitution.Location = new System.Drawing.Point(104, 92);
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.Size = new System.Drawing.Size(33, 20);
            this.txtConstitution.TabIndex = 13;
            this.txtConstitution.Text = "10";
            this.txtConstitution.TextChanged += new System.EventHandler(this.txtConstitution_TextChanged);
            this.txtConstitution.Mask = "00";
            this.txtConstitution.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dexterity:";
            // 
            // txtIntelligence
            // 
            this.txtIntelligence.Location = new System.Drawing.Point(104, 118);
            this.txtIntelligence.Name = "txtIntelligence";
            this.txtIntelligence.Size = new System.Drawing.Size(33, 20);
            this.txtIntelligence.TabIndex = 12;
            this.txtIntelligence.Text = "10";
            this.txtIntelligence.TextChanged += new System.EventHandler(this.txtIntelligence_TextChanged);
            this.txtIntelligence.Mask = "00";
            this.txtIntelligence.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Constitution:";
            // 
            // txtWisdom
            // 
            this.txtWisdom.Location = new System.Drawing.Point(104, 144);
            this.txtWisdom.Name = "txtWisdom";
            this.txtWisdom.Size = new System.Drawing.Size(33, 20);
            this.txtWisdom.TabIndex = 11;
            this.txtWisdom.Text = "10";
            this.txtWisdom.TextChanged += new System.EventHandler(this.txtWisdom_TextChanged);
            this.txtWisdom.Mask = "00";
            this.txtWisdom.ValidatingType = typeof(int);
            // 
            // lblIntelligence
            // 
            this.lblIntelligence.AutoSize = true;
            this.lblIntelligence.Location = new System.Drawing.Point(6, 121);
            this.lblIntelligence.Name = "lblIntelligence";
            this.lblIntelligence.Size = new System.Drawing.Size(64, 13);
            this.lblIntelligence.TabIndex = 5;
            this.lblIntelligence.Text = "Intelligence:";
            // 
            // txtCharisma
            // 
            this.txtCharisma.Location = new System.Drawing.Point(104, 170);
            this.txtCharisma.Name = "txtCharisma";
            this.txtCharisma.Size = new System.Drawing.Size(33, 20);
            this.txtCharisma.TabIndex = 10;
            this.txtCharisma.Text = "10";
            this.txtCharisma.TextChanged += new System.EventHandler(this.txtCharisma_TextChanged);
            this.txtCharisma.Mask = "00";
            this.txtCharisma.ValidatingType = typeof(int);
            // 
            // lblWisdom
            // 
            this.lblWisdom.AutoSize = true;
            this.lblWisdom.Location = new System.Drawing.Point(6, 147);
            this.lblWisdom.Name = "lblWisdom";
            this.lblWisdom.Size = new System.Drawing.Size(48, 13);
            this.lblWisdom.TabIndex = 6;
            this.lblWisdom.Text = "Wisdom:";
            // 
            // lblCharisma
            // 
            this.lblCharisma.AutoSize = true;
            this.lblCharisma.Location = new System.Drawing.Point(6, 173);
            this.lblCharisma.Name = "lblCharisma";
            this.lblCharisma.Size = new System.Drawing.Size(53, 13);
            this.lblCharisma.TabIndex = 7;
            this.lblCharisma.Text = "Charisma:";
            // 
            // txtCharacter
            // 
            this.txtCharacter.Location = new System.Drawing.Point(110, 37);
            this.txtCharacter.Name = "txtCharacter";
            this.txtCharacter.Size = new System.Drawing.Size(156, 20);
            this.txtCharacter.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Character\'s name:";
            // 
            // lblDirections
            // 
            this.lblDirections.AutoSize = true;
            this.lblDirections.Location = new System.Drawing.Point(8, 12);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(578, 13);
            this.lblDirections.TabIndex = 0;
            this.lblDirections.Text = "Provide as much or as little information as you\'d like. We\'ll use your class and " +
    "spellcasting attribute to determine spell DCs.";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(784, 25);
            this.mainToolStrip.TabIndex = 1;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainTabControl);
            this.Name = "FrmMain";
            this.Text = "D&D 3.5 SRD Spell Lists";
            this.mainTabControl.ResumeLayout(false);
            this.spellListTab.ResumeLayout(false);
            this.spellListTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsDataGridView)).EndInit();
            this.characterTab.ResumeLayout(false);
            this.characterTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage spellListTab;
        private System.Windows.Forms.TabPage characterTab;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView spellsDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn prepColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spellNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn customColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn charCustomColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.Label lblCharisma;
        private System.Windows.Forms.Label lblWisdom;
        private System.Windows.Forms.Label lblIntelligence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCharacter;
        private System.Windows.Forms.MaskedTextBox txtDexterity;
        private System.Windows.Forms.MaskedTextBox txtConstitution;
        private System.Windows.Forms.MaskedTextBox txtIntelligence;
        private System.Windows.Forms.MaskedTextBox txtWisdom;
        private System.Windows.Forms.MaskedTextBox txtCharisma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDexMod;
        private System.Windows.Forms.Label lblConMod;
        private System.Windows.Forms.Label lblIntMod;
        private System.Windows.Forms.Label lblWisMod;
        private System.Windows.Forms.Label lblChaMod;
        private System.Windows.Forms.Label lblStrMod;
        private System.Windows.Forms.Label lblModifiers;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox txtStrength;
    }
}

