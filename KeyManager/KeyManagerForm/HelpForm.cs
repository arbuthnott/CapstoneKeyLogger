using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KeyManagerForm
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            //Process.Start("C:\\Users\\s0739107\\Documents\\resume.pdf");

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //// set file filter of dialog 
            //dlg.Filter = "pdf files (*.pdf) |*.pdf;";
            //dlg.ShowDialog();
            //if (dlg.FileName != null)
            //{
            //    // use the LoadFile(ByVal fileName As String) function for open the pdf in control
            //    axAcroPDF1.LoadFile(dlg.FileName);
            //}
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            //axAcroPDF1.LoadFile("C:\\Users\\s0739107\\Documents\\resume.pdf");
        }
    }
}
