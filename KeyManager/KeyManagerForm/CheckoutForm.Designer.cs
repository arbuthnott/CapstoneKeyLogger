namespace KeyManagerForm
{
    partial class CheckoutForm
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
            this.components = new System.ComponentModel.Container();
            this.treeViewPeople = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewRings = new System.Windows.Forms.TreeView();
            this.treeViewKeys = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTipCheckout = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPersonnelHint = new System.Windows.Forms.Button();
            this.buttonKeyringHint = new System.Windows.Forms.Button();
            this.buttonKeyHint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewPeople
            // 
            this.treeViewPeople.AllowDrop = true;
            this.treeViewPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPeople.FullRowSelect = true;
            this.treeViewPeople.Indent = 24;
            this.treeViewPeople.ItemHeight = 18;
            this.treeViewPeople.Location = new System.Drawing.Point(27, 39);
            this.treeViewPeople.Name = "treeViewPeople";
            this.treeViewPeople.ShowLines = false;
            this.treeViewPeople.Size = new System.Drawing.Size(178, 423);
            this.treeViewPeople.TabIndex = 0;
            this.treeViewPeople.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewPeople_NodeMouseHover);
            this.treeViewPeople.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPeople_NodeMouseDoubleClick);
            this.treeViewPeople.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewPeople_DragDrop);
            this.treeViewPeople.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewPeople_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personnel:";
            // 
            // treeViewRings
            // 
            this.treeViewRings.AllowDrop = true;
            this.treeViewRings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewRings.FullRowSelect = true;
            this.treeViewRings.Indent = 24;
            this.treeViewRings.ItemHeight = 18;
            this.treeViewRings.Location = new System.Drawing.Point(243, 39);
            this.treeViewRings.Name = "treeViewRings";
            this.treeViewRings.ShowLines = false;
            this.treeViewRings.Size = new System.Drawing.Size(178, 185);
            this.treeViewRings.TabIndex = 2;
            this.treeViewRings.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewRings_NodeMouseHover);
            this.treeViewRings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewRings_MouseDown);
            // 
            // treeViewKeys
            // 
            this.treeViewKeys.AllowDrop = true;
            this.treeViewKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewKeys.FullRowSelect = true;
            this.treeViewKeys.Indent = 24;
            this.treeViewKeys.ItemHeight = 18;
            this.treeViewKeys.Location = new System.Drawing.Point(243, 277);
            this.treeViewKeys.Name = "treeViewKeys";
            this.treeViewKeys.ShowLines = false;
            this.treeViewKeys.Size = new System.Drawing.Size(178, 185);
            this.treeViewKeys.TabIndex = 3;
            this.treeViewKeys.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewKeys_NodeMouseHover);
            this.treeViewKeys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewKeys_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key Rings:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loose Keys:";
            // 
            // toolTipCheckout
            // 
            this.toolTipCheckout.AutoPopDelay = 5000;
            this.toolTipCheckout.InitialDelay = 500;
            this.toolTipCheckout.ReshowDelay = 100;
            this.toolTipCheckout.ShowAlways = true;
            this.toolTipCheckout.UseAnimation = false;
            this.toolTipCheckout.UseFading = false;
            // 
            // buttonPersonnelHint
            // 
            this.buttonPersonnelHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPersonnelHint.Location = new System.Drawing.Point(173, 4);
            this.buttonPersonnelHint.Name = "buttonPersonnelHint";
            this.buttonPersonnelHint.Size = new System.Drawing.Size(32, 29);
            this.buttonPersonnelHint.TabIndex = 6;
            this.buttonPersonnelHint.Text = "?";
            this.buttonPersonnelHint.UseVisualStyleBackColor = true;
            this.buttonPersonnelHint.Click += new System.EventHandler(this.buttonPersonnelHint_Click);
            this.buttonPersonnelHint.MouseHover += new System.EventHandler(this.buttonPersonnelHint_MouseHover);
            // 
            // buttonKeyringHint
            // 
            this.buttonKeyringHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeyringHint.Location = new System.Drawing.Point(389, 4);
            this.buttonKeyringHint.Name = "buttonKeyringHint";
            this.buttonKeyringHint.Size = new System.Drawing.Size(32, 29);
            this.buttonKeyringHint.TabIndex = 7;
            this.buttonKeyringHint.Text = "?";
            this.buttonKeyringHint.UseVisualStyleBackColor = true;
            this.buttonKeyringHint.Click += new System.EventHandler(this.buttonKeyringHint_Click);
            this.buttonKeyringHint.MouseHover += new System.EventHandler(this.buttonKeyringHint_MouseHover);
            // 
            // buttonKeyHint
            // 
            this.buttonKeyHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeyHint.Location = new System.Drawing.Point(389, 242);
            this.buttonKeyHint.Name = "buttonKeyHint";
            this.buttonKeyHint.Size = new System.Drawing.Size(32, 29);
            this.buttonKeyHint.TabIndex = 8;
            this.buttonKeyHint.Text = "?";
            this.buttonKeyHint.UseVisualStyleBackColor = true;
            this.buttonKeyHint.Click += new System.EventHandler(this.buttonKeyHint_Click);
            this.buttonKeyHint.MouseHover += new System.EventHandler(this.buttonKeyHint_MouseHover);
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 474);
            this.Controls.Add(this.buttonKeyHint);
            this.Controls.Add(this.buttonKeyringHint);
            this.Controls.Add(this.buttonPersonnelHint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeViewKeys);
            this.Controls.Add(this.treeViewRings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewPeople);
            this.Name = "CheckoutForm";
            this.Text = "Key Checkouts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewRings;
        private System.Windows.Forms.TreeView treeViewKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTipCheckout;
        private System.Windows.Forms.Button buttonPersonnelHint;
        private System.Windows.Forms.Button buttonKeyringHint;
        private System.Windows.Forms.Button buttonKeyHint;
    }
}