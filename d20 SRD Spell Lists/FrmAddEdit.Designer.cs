namespace d20_SRD_Spell_Lists {
    partial class FrmAddEdit {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baseSpellComboBox = new System.Windows.Forms.ComboBox();
            this.customSpellGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLevel = new System.Windows.Forms.NumericUpDown();
            this.txtComponents = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.customSpellGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a base spell or create a custom spell.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Base spell:";
            // 
            // baseSpellComboBox
            // 
            this.baseSpellComboBox.FormattingEnabled = true;
            this.baseSpellComboBox.Location = new System.Drawing.Point(76, 33);
            this.baseSpellComboBox.Name = "baseSpellComboBox";
            this.baseSpellComboBox.Size = new System.Drawing.Size(215, 21);
            this.baseSpellComboBox.TabIndex = 2;
            this.baseSpellComboBox.SelectedIndexChanged += new System.EventHandler(this.baseSpellComboBox_SelectedIndexChanged);
            // 
            // customSpellGroup
            // 
            this.customSpellGroup.Controls.Add(this.txtDescription);
            this.customSpellGroup.Controls.Add(this.txtComponents);
            this.customSpellGroup.Controls.Add(this.txtLevel);
            this.customSpellGroup.Controls.Add(this.txtName);
            this.customSpellGroup.Controls.Add(this.label6);
            this.customSpellGroup.Controls.Add(this.label5);
            this.customSpellGroup.Controls.Add(this.label4);
            this.customSpellGroup.Controls.Add(this.label3);
            this.customSpellGroup.Location = new System.Drawing.Point(15, 71);
            this.customSpellGroup.Name = "customSpellGroup";
            this.customSpellGroup.Size = new System.Drawing.Size(276, 169);
            this.customSpellGroup.TabIndex = 3;
            this.customSpellGroup.TabStop = false;
            this.customSpellGroup.Text = "Custom Spell";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Components:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(82, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(82, 45);
            this.txtLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(41, 20);
            this.txtLevel.TabIndex = 5;
            // 
            // txtComponents
            // 
            this.txtComponents.Location = new System.Drawing.Point(82, 71);
            this.txtComponents.Name = "txtComponents";
            this.txtComponents.Size = new System.Drawing.Size(188, 20);
            this.txtComponents.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(82, 99);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(188, 59);
            this.txtDescription.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(131, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 283);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.customSpellGroup);
            this.Controls.Add(this.baseSpellComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddEdit";
            this.Text = "Add a Spell";
            this.customSpellGroup.ResumeLayout(false);
            this.customSpellGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baseSpellComboBox;
        private System.Windows.Forms.GroupBox customSpellGroup;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtComponents;
        private System.Windows.Forms.NumericUpDown txtLevel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}