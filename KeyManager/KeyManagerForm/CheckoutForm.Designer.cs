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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeViewPeople
            // 
            this.treeViewPeople.AllowDrop = true;
            this.treeViewPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPeople.FullRowSelect = true;
            this.treeViewPeople.Indent = 24;
            this.treeViewPeople.ItemHeight = 18;
            this.treeViewPeople.Location = new System.Drawing.Point(27, 106);
            this.treeViewPeople.Name = "treeViewPeople";
            this.treeViewPeople.ShowLines = false;
            this.treeViewPeople.Size = new System.Drawing.Size(178, 356);
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
            this.treeViewRings.Location = new System.Drawing.Point(243, 64);
            this.treeViewRings.Name = "treeViewRings";
            this.treeViewRings.ShowLines = false;
            this.treeViewRings.Size = new System.Drawing.Size(178, 174);
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
            this.treeViewKeys.Location = new System.Drawing.Point(243, 288);
            this.treeViewKeys.Name = "treeViewKeys";
            this.treeViewKeys.ShowLines = false;
            this.treeViewKeys.Size = new System.Drawing.Size(178, 174);
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
            this.toolTipCheckout.AutoPopDelay = 3000;
            this.toolTipCheckout.InitialDelay = 500;
            this.toolTipCheckout.ReshowDelay = 100;
            this.toolTipCheckout.ShowAlways = true;
            this.toolTipCheckout.UseAnimation = false;
            this.toolTipCheckout.UseFading = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(30, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(175, 70);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Expand to see keys and keyrings checked out by each person.\r\n\r\nDouble-click a key" +
    " or key ring to check-in that item.";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Location = new System.Drawing.Point(243, 30);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(175, 28);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Drag onto a person to check-out.  Expand to see keys on the ring.";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Gray;
            this.textBox3.Location = new System.Drawing.Point(243, 268);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(175, 14);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "Drag onto a person to check-out.";
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 474);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}