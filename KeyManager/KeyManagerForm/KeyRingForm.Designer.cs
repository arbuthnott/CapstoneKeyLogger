﻿namespace KeyManagerForm
{
    partial class KeyRingForm
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
            this.groupBoxKeysetManage = new System.Windows.Forms.GroupBox();
            this.buttonAddKeysetKey = new System.Windows.Forms.Button();
            this.buttonRemoveKeysetKey = new System.Windows.Forms.Button();
            this.listBoxKeysNotInKeyset = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxKeysInKeyset = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeysetEdit = new System.Windows.Forms.Button();
            this.labelKeysetTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxKeysets = new System.Windows.Forms.ListBox();
            this.buttonCreateKeyset = new System.Windows.Forms.Button();
            this.labelKeysetChoice = new System.Windows.Forms.Label();
            this.buttonKeysetDelete = new System.Windows.Forms.Button();
            this.groupBoxKeysetManage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxKeysetManage
            // 
            this.groupBoxKeysetManage.Controls.Add(this.buttonKeysetDelete);
            this.groupBoxKeysetManage.Controls.Add(this.buttonAddKeysetKey);
            this.groupBoxKeysetManage.Controls.Add(this.buttonRemoveKeysetKey);
            this.groupBoxKeysetManage.Controls.Add(this.listBoxKeysNotInKeyset);
            this.groupBoxKeysetManage.Controls.Add(this.label4);
            this.groupBoxKeysetManage.Controls.Add(this.listBoxKeysInKeyset);
            this.groupBoxKeysetManage.Controls.Add(this.label1);
            this.groupBoxKeysetManage.Controls.Add(this.buttonKeysetEdit);
            this.groupBoxKeysetManage.Controls.Add(this.labelKeysetTitle);
            this.groupBoxKeysetManage.Location = new System.Drawing.Point(290, 12);
            this.groupBoxKeysetManage.Name = "groupBoxKeysetManage";
            this.groupBoxKeysetManage.Size = new System.Drawing.Size(324, 404);
            this.groupBoxKeysetManage.TabIndex = 3;
            this.groupBoxKeysetManage.TabStop = false;
            this.groupBoxKeysetManage.Text = "Keys in Keyset";
            // 
            // buttonAddKeysetKey
            // 
            this.buttonAddKeysetKey.Location = new System.Drawing.Point(183, 256);
            this.buttonAddKeysetKey.Name = "buttonAddKeysetKey";
            this.buttonAddKeysetKey.Size = new System.Drawing.Size(130, 23);
            this.buttonAddKeysetKey.TabIndex = 9;
            this.buttonAddKeysetKey.Text = "Add Selected Key";
            this.buttonAddKeysetKey.UseVisualStyleBackColor = true;
            this.buttonAddKeysetKey.Click += new System.EventHandler(this.buttonAddKeysetKey_Click);
            // 
            // buttonRemoveKeysetKey
            // 
            this.buttonRemoveKeysetKey.Location = new System.Drawing.Point(183, 217);
            this.buttonRemoveKeysetKey.Name = "buttonRemoveKeysetKey";
            this.buttonRemoveKeysetKey.Size = new System.Drawing.Size(130, 23);
            this.buttonRemoveKeysetKey.TabIndex = 8;
            this.buttonRemoveKeysetKey.Text = "Remove Selected Key";
            this.buttonRemoveKeysetKey.UseVisualStyleBackColor = true;
            this.buttonRemoveKeysetKey.Click += new System.EventHandler(this.buttonRemoveKeysetKey_Click);
            // 
            // listBoxKeysNotInKeyset
            // 
            this.listBoxKeysNotInKeyset.FormattingEnabled = true;
            this.listBoxKeysNotInKeyset.Location = new System.Drawing.Point(10, 285);
            this.listBoxKeysNotInKeyset.Name = "listBoxKeysNotInKeyset";
            this.listBoxKeysNotInKeyset.Size = new System.Drawing.Size(303, 108);
            this.listBoxKeysNotInKeyset.TabIndex = 7;
            this.listBoxKeysNotInKeyset.SelectedIndexChanged += new System.EventHandler(this.listBoxKeysNotInKeyset_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Available Keys:";
            // 
            // listBoxKeysInKeyset
            // 
            this.listBoxKeysInKeyset.FormattingEnabled = true;
            this.listBoxKeysInKeyset.Location = new System.Drawing.Point(10, 103);
            this.listBoxKeysInKeyset.Name = "listBoxKeysInKeyset";
            this.listBoxKeysInKeyset.Size = new System.Drawing.Size(303, 108);
            this.listBoxKeysInKeyset.TabIndex = 4;
            this.listBoxKeysInKeyset.SelectedIndexChanged += new System.EventHandler(this.listBoxKeysInKeyset_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keys currently in set:";
            // 
            // buttonKeysetEdit
            // 
            this.buttonKeysetEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKeysetEdit.Location = new System.Drawing.Point(197, 23);
            this.buttonKeysetEdit.Name = "buttonKeysetEdit";
            this.buttonKeysetEdit.Size = new System.Drawing.Size(55, 23);
            this.buttonKeysetEdit.TabIndex = 2;
            this.buttonKeysetEdit.Text = "Edit";
            this.buttonKeysetEdit.UseVisualStyleBackColor = true;
            this.buttonKeysetEdit.Click += new System.EventHandler(this.buttonKeysetEdit_Click);
            // 
            // labelKeysetTitle
            // 
            this.labelKeysetTitle.AutoSize = true;
            this.labelKeysetTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeysetTitle.Location = new System.Drawing.Point(6, 20);
            this.labelKeysetTitle.Name = "labelKeysetTitle";
            this.labelKeysetTitle.Size = new System.Drawing.Size(122, 24);
            this.labelKeysetTitle.TabIndex = 1;
            this.labelKeysetTitle.Text = "Keyset Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxKeysets);
            this.groupBox1.Controls.Add(this.buttonCreateKeyset);
            this.groupBox1.Controls.Add(this.labelKeysetChoice);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 404);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keysets";
            // 
            // listBoxKeysets
            // 
            this.listBoxKeysets.FormattingEnabled = true;
            this.listBoxKeysets.Location = new System.Drawing.Point(10, 51);
            this.listBoxKeysets.Name = "listBoxKeysets";
            this.listBoxKeysets.Size = new System.Drawing.Size(249, 342);
            this.listBoxKeysets.TabIndex = 2;
            this.listBoxKeysets.SelectedIndexChanged += new System.EventHandler(this.listBoxKeysets_SelectedIndexChanged);
            // 
            // buttonCreateKeyset
            // 
            this.buttonCreateKeyset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateKeyset.Location = new System.Drawing.Point(184, 23);
            this.buttonCreateKeyset.Name = "buttonCreateKeyset";
            this.buttonCreateKeyset.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateKeyset.TabIndex = 1;
            this.buttonCreateKeyset.Text = "New Keyset";
            this.buttonCreateKeyset.UseVisualStyleBackColor = true;
            this.buttonCreateKeyset.Click += new System.EventHandler(this.buttonCreateKeyset_Click);
            // 
            // labelKeysetChoice
            // 
            this.labelKeysetChoice.AutoSize = true;
            this.labelKeysetChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeysetChoice.Location = new System.Drawing.Point(6, 20);
            this.labelKeysetChoice.Name = "labelKeysetChoice";
            this.labelKeysetChoice.Size = new System.Drawing.Size(152, 24);
            this.labelKeysetChoice.TabIndex = 0;
            this.labelKeysetChoice.Text = "Choose a Keyset";
            // 
            // buttonKeysetDelete
            // 
            this.buttonKeysetDelete.Location = new System.Drawing.Point(258, 23);
            this.buttonKeysetDelete.Name = "buttonKeysetDelete";
            this.buttonKeysetDelete.Size = new System.Drawing.Size(55, 23);
            this.buttonKeysetDelete.TabIndex = 10;
            this.buttonKeysetDelete.Text = "Delete";
            this.buttonKeysetDelete.UseVisualStyleBackColor = true;
            this.buttonKeysetDelete.Click += new System.EventHandler(this.buttonKeysetDelete_Click);
            // 
            // KeyRingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 426);
            this.Controls.Add(this.groupBoxKeysetManage);
            this.Controls.Add(this.groupBox1);
            this.Name = "KeyRingForm";
            this.Text = "KeyRingForm";
            this.groupBoxKeysetManage.ResumeLayout(false);
            this.groupBoxKeysetManage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxKeysetManage;
        private System.Windows.Forms.Button buttonAddKeysetKey;
        private System.Windows.Forms.Button buttonRemoveKeysetKey;
        private System.Windows.Forms.ListBox listBoxKeysNotInKeyset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxKeysInKeyset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeysetEdit;
        private System.Windows.Forms.Label labelKeysetTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxKeysets;
        private System.Windows.Forms.Button buttonCreateKeyset;
        private System.Windows.Forms.Label labelKeysetChoice;
        private System.Windows.Forms.Button buttonKeysetDelete;
    }
}