using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyManagerData;
using KeyManagerClassLib;

namespace KeyManagerForm
{
    public partial class FloorPlanForm : Form
    {
        ObjectHolder objects;
        List<MapPoint> dataPoints = new List<MapPoint>();

        Boolean addingMapPoint = false;
        private int x = 0;
        private int y = 0;

        public FloorPlanForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (addingMapPoint)
            {
                dataPoints.Add(new MapPoint(x, y));
                this.Cursor = Cursors.Default;
                pictureBox1.Invalidate();
                addingMapPoint = false;
            } 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //UserControl1 popup = new UserControl1();
            x = e.X;
            y = e.Y;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (MapPoint point in dataPoints)
            {
                // draw on doors
                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    Rectangle eee = new Rectangle(point.x, point.y, 10, 10);                    
                    e.Graphics.FillRectangle(brush, eee);
                }

                // look for mouse position
                if (x >= point.x && x <= point.x + 10)
                    if (y >= point.y && y <= point.y + 10)
                    {
                        using (Brush brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                        {
                            Rectangle eee = new Rectangle(x, y, 200, 300);
                            e.Graphics.FillRectangle(brush, eee);
                        }
                    }
            }                        
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            addingMapPoint = true;
        }
    }
}
