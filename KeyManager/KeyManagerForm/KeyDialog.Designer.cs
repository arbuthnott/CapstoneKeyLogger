namespace KeyManagerForm
{
    partial class KeyDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxKeyring = new System.Windows.Forms.ComboBox();
            this.checkBoxBroken = new System.Windows.Forms.CheckBox();
            this.checkBoxMissing = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Serial number or other unique identifier for the key:";
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Location = new System.Drawing.Point(88, 56);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.Size = new System.Drawing.Size(251, 20);
            this.textBoxSerial.TabIndex = 1;
            this.textBoxSerial.TextChanged += new System.EventHandler(this.textBoxSerial_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Identifier:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Keytype (Required):";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(38, 120);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(301, 21);
            this.comboBoxType.TabIndex = 4;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Assigned to Keyring (Optional):";
            // 
            // comboBoxKeyring
            // 
            this.comboBoxKeyring.FormattingEnabled = true;
            this.comboBoxKeyring.Location = new System.Drawing.Point(38, 190);
            this.comboBoxKeyring.Name = "comboBoxKeyring";
            this.comboBoxKeyring.Size = new System.Drawing.Size(301, 21);
            this.comboBoxKeyring.TabIndex = 6;
            this.comboBoxKeyring.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyring_SelectedIndexChanged);
            // 
            // checkBoxBroken
            // 
            this.checkBoxBroken.AutoSize = true;
            this.checkBoxBroken.Location = new System.Drawing.Point(409, 113);
            this.checkBoxBroken.Name = "checkBoxBroken";
            this.checkBoxBroken.Size = new System.Drawing.Size(60, 17);
            this.checkBoxBroken.TabIndex = 7;
            this.checkBoxBroken.Text = "Broken";
            this.checkBoxBroken.UseVisualStyleBackColor = true;
            this.checkBoxBroken.Click += new System.EventHandler(this.checkBoxBroken_Click);
            // 
            // checkBoxMissing
            // 
            this.checkBoxMissing.AutoSize = true;
            this.checkBoxMissing.Location = new System.Drawing.Point(409, 136);
            this.checkBoxMissing.Name = "checkBoxMissing";
            this.checkBoxMissing.Size = new System.Drawing.Size(61, 17);
            this.checkBoxMissing.TabIndex = 8;
            this.checkBoxMissing.Text = "Missing";
            this.checkBoxMissing.UseVisualStyleBackColor = true;
            this.checkBoxMissing.Click += new System.EventHandler(this.checkBoxMissing_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Additional Info:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(408, 242);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(315, 242);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // KeyDialog
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 282);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxMissing);
            this.Controls.Add(this.checkBoxBroken);
            this.Controls.Add(this.comboBoxKeyring);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSerial);
            this.Controls.Add(this.label1);
            this.Name = "KeyDialog";
            this.Text = "Update Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxKeyring;
        private System.Windows.Forms.CheckBox checkBoxBroken;
        private System.Windows.Forms.CheckBox checkBoxMissing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}