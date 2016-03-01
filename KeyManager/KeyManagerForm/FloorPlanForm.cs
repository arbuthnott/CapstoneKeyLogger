﻿using System;
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

        List<String> floors = new List<String>();
        Bitmap floor0 = new Bitmap(KeyManagerForm.Properties.Resources.map1);
        Bitmap floor1 = new Bitmap(KeyManagerForm.Properties.Resources.map2);
        int currentFloor = 0;

        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);

        Boolean addingMapPoint = false;
        private int x = 0;
        private int y = 0;

        public FloorPlanForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            SetupListofFloors();
            SetupListofDoors();

            foreach (Door door in objects.doors)
            {
                cbDoors.Items.Add(door.RoomNumber);
            }
        }

        public void SetupListofFloors()
        {
            // temp stub
            floors.Add("First Floor");
            floors.Add("Second Floor");

            listFloors.View = View.Details;
            listFloors.GridLines = true;
            listFloors.FullRowSelect = true;

            listFloors.Columns.Add("Floors", 120);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            listFloors.SmallImageList = imgList;
            
            int count = 0;

            foreach (String floor in floors)
            {
                String[] args = { floor };
                ListViewItem row = new ListViewItem(args);
                if (count % 2 == 0)
                    row.BackColor = lightBlue;
                else
                    row.BackColor = evenLighterBlue;
                count++;
                listFloors.Items.Add(row);
            }
        }

        public void SetupListofDoors()
        {
            listDoors.View = View.Details;
            listDoors.GridLines = true;
            listDoors.FullRowSelect = true;

            listDoors.Columns.Add("Doors", 120);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            listDoors.SmallImageList = imgList;
        }

        public void RefreshDoorLst()
        {
            listDoors.Items.Clear();
            int count = 0;
            foreach (MapPoint point in dataPoints)
            {
                if (point.floor == currentFloor)
                {
                    String[] args = { point.door.RoomNumber };
                    ListViewItem row = new ListViewItem(args);
                    if (count % 2 == 0)
                        row.BackColor = lightBlue;
                    else
                        row.BackColor = evenLighterBlue;
                    count++;
                    listDoors.Items.Add(row);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (addingMapPoint)
            {
                // use a dialog to create a new keyset
                //AddMapPointDialog ksd = new AddMapPointDialog(objects);
                //if (ksd.ShowDialog() == DialogResult.OK)
                //{
                //    dataPoints.Add(new MapPoint(x, y, ksd.door, currentFloor));
                //}
                //ksd.Close();

                foreach (Door door in objects.doors)
                    if (door.RoomNumber.Equals(cbDoors.SelectedItem))
                        dataPoints.Add(new MapPoint(x, y, door, currentFloor));
                
                this.Cursor = Cursors.Default;
                pictureBox1.Invalidate();
                RefreshDoorLst();
                addingMapPoint = false;
                cbDoors.SelectionLength = 0;
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
                if (point.floor == currentFloor)
                {
                    // draw on doors
                    Color doorColor;
                    if (point.selected)
                        doorColor = Color.Red;
                    else
                        doorColor = Color.Blue;

                    using (Brush brush = new SolidBrush(doorColor))
                    {
                        Rectangle eee = new Rectangle(point.x, point.y, 10, 10);
                        e.Graphics.FillRectangle(brush, eee);
                    }

                    // look for mouse position
                    if (x >= point.x && x <= point.x + 10)
                        if (y >= point.y && y <= point.y + 10)
                        {
                            int POPUP_WIDTH = 200;
                            int POPUP_HEIGHT = 200;
                            int horizontalOffset = 0;
                            int verticalOffset = 0;
                            int width = pictureBox1.Width;
                            int height = pictureBox1.Height;

                            if (width - x < POPUP_WIDTH)
                                horizontalOffset = POPUP_WIDTH * -1;
                            if (height - y < POPUP_HEIGHT)
                                verticalOffset = POPUP_HEIGHT * -1;

                            // draw door popup
                            using (Brush brush = new SolidBrush(Color.FromArgb(0, 0, 255)))
                            {
                                Rectangle eee = new Rectangle(x + horizontalOffset, y + verticalOffset, POPUP_WIDTH, 40);
                                e.Graphics.FillRectangle(brush, eee);
                            }
                            using (Brush brush = new SolidBrush(Color.FromArgb(200, 0, 0, 0)))
                            {
                                Rectangle eee = new Rectangle(x + horizontalOffset, y + verticalOffset, POPUP_WIDTH, POPUP_HEIGHT);
                                e.Graphics.FillRectangle(brush, eee);
                            }
                            using (Brush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
                            {
                                Font font = new Font("Arial", 16);
                                e.Graphics.DrawString(point.door.RoomNumber, font, brush, x + 10 + horizontalOffset, y + 10 + verticalOffset);

                                Font font2 = new Font("Arial", 12);
                                e.Graphics.DrawString("Key Types:", font2, brush, x + 10 + horizontalOffset, y + 45 + verticalOffset);

                                Font font3 = new Font("Arial", 10);
                                int yOffset = y + 70;
                                foreach (KeyType type in point.door.keytypes)
                                {
                                    e.Graphics.DrawString(type.Name, font3, brush, x + 15 + horizontalOffset, yOffset + verticalOffset);
                                    yOffset += 25;
                                }

                            }
                        }
                }               
            }                        
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;

            Label lb = new Label();
            lb.Location = new Point(MousePosition.X - this.Left, MousePosition.Y - this.Top);
            lb.Text = "Select location on map.";
            this.Controls.Add(lb);

            addingMapPoint = true;
        }

        /// <summary>
        /// The selected floor has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (String floor in floors)
            {
                if (listFloors.SelectedItems.Count > 0)
                    if (listFloors.SelectedItems[0].Text.Equals(floor))
                    {
                        if (listFloors.SelectedIndices[0] == 0)
                        {
                            currentFloor = 0;
                            pictureBox1.Image = floor0;
                            RefreshDoorLst();
                        }
                        if (listFloors.SelectedIndices[0] == 1)
                        {
                            currentFloor = 1;
                            pictureBox1.Image = floor1;
                            RefreshDoorLst();
                        }
                    }
            }
        }

        private void listDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (MapPoint point in dataPoints)
            {
                if (listDoors.SelectedItems.Count > 0)
                {
                    if (point.door.RoomNumber.Equals(listDoors.SelectedItems[0].Text))
                    {
                        point.selected = true;
                    }
                    else
                        point.selected = false;
                }
                else
                {
                    point.selected = false;
                }
            }
            pictureBox1.Invalidate();
        }

        private void cbDoors_Click(object sender, EventArgs e)
        {
            
        }

        private void cbDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbDoors.SelectedText.ToString().Equals("Add Door"))
            {
                this.Cursor = Cursors.Cross;
                addingMapPoint = true;
            }
        }
    }
}
