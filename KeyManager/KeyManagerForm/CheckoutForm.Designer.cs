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
            this.listPeople = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listPeople
            // 
            this.listPeople.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listPeople.GridLines = true;
            this.listPeople.HotTracking = true;
            this.listPeople.HoverSelection = true;
            this.listPeople.Location = new System.Drawing.Point(12, 130);
            this.listPeople.Name = "listPeople";
            this.listPeople.ShowItemToolTips = true;
            this.listPeople.Size = new System.Drawing.Size(397, 374);
            this.listPeople.TabIndex = 8;
            this.listPeople.UseCompatibleStateImageBehavior = false;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 516);
            this.Controls.Add(this.listPeople);
            this.Name = "CheckoutForm";
            this.Text = "Key Checkouts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listPeople;
    }
}