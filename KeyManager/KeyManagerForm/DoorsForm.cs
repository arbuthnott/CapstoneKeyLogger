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
    public partial class DoorsForm : Form
    {
        ObjectHolder objects;
        BindingList<Door> Doors { get; set; }
        BindingList<KeyType> AssignedKeyTypes { get; set; }
        BindingList<KeyType> UnassignedKeyTypes { get; set; }
        BindingList<Location> DoorGroups { get; set; }
        Door SelectedDoor { get; set; }

        public DoorsForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            this.Doors = new BindingList<Door>(this.objects.doors);
            this.UnassignedKeyTypes = new BindingList<KeyType>();
            this.DoorGroups = new BindingList<Location>();
        }

        private void DoorsForm_Load(object sender, EventArgs e)
        {
            lbxDoorList.DataSource = Doors;
            lbxDoorList.DisplayMember = "RoomNumber";
            lbxDoorList.ValueMember = "Id";

            lbxUnassignedKeyTypes.DataSource = UnassignedKeyTypes;
            lbxUnassignedKeyTypes.DisplayMember = "Name";
            lbxUnassignedKeyTypes.ValueMember = "Id";

            lbxDoorGroups.DataSource = DoorGroups;
            lbxDoorGroups.DisplayMember = "Name";
            lbxDoorGroups.ValueMember = "Id";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            String roomNumber = "";
            if (ShowInputDialog(ref roomNumber, "Create Door"))
            {
                Door newDoor = new Door();
                newDoor.RoomNumber = roomNumber;
                newDoor.Id = -1;
                newDoor.LockId = -1;
                newDoor.DoorImage = "Why is a string an image?";
                Doors.Add(newDoor);
                newDoor.Save();
            }
        }

        private void lbxDoorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnassignedKeyTypes.Clear();
            SelectedDoor = (Door)lbxDoorList.SelectedItem;
            AssignedKeyTypes = new BindingList<KeyType>(SelectedDoor.keytypes);
            lbxAssignedKeyTypes.DataSource = AssignedKeyTypes;
            lbxAssignedKeyTypes.DisplayMember = "Name";
            lbxAssignedKeyTypes.ValueMember = "Id";
            bool addthis;
            foreach (KeyType keytype in objects.keytypes)
            {
                addthis = true;
                //check for a match 
                foreach (KeyType selectedkeytype in SelectedDoor.keytypes)
                {
                    if (keytype.Id == selectedkeytype.Id)
                    {
                        addthis = false;
                    }
                }
                if (addthis)
                {
                    UnassignedKeyTypes.Add(keytype);
                }
            }
            DoorGroups.Clear();
            foreach (Location lc in objects.locations)
            {
                foreach (Door door in lc.doors)
                {
                    if (door.Id == SelectedDoor.Id)
                    {
                        DoorGroups.Add(lc);
                        break;
                    }
                }
            }

        }
        //http://stackoverflow.com/questions/97097/what-is-the-c-sharp-version-of-vb-nets-inputdialog
        private static bool ShowInputDialog(ref String input, String boxtitle)
        {
            System.Drawing.Size size = new System.Drawing.Size(485, 100);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = boxtitle;

            System.Windows.Forms.Label label = new Label();
            label.Size = new System.Drawing.Size(size.Width - 10, 23);
            label.Location = new System.Drawing.Point(5, 10);
            label.Text = "Room Number: ";
            inputBox.Controls.Add(label);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 40);
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 70);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 70);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            if (result.ToString() == "OK")
            {
                return true;
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int indexToRemove = lbxDoorList.SelectedIndex;
            Door doorToRemove = (Door)lbxDoorList.SelectedItem;
            //doorToRemove.Delete();
            Doors.RemoveAt(indexToRemove);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int indexToRemove = lbxAssignedKeyTypes.SelectedIndex;
            UnassignedKeyTypes.Add((KeyType)lbxAssignedKeyTypes.SelectedItem);
            //AssignedKeyTypes.RemoveAt(indexToRemove);
            SelectedDoor.keytypes.RemoveAt(indexToRemove);
            AssignedKeyTypes = new BindingList<KeyType>(SelectedDoor.keytypes);
            lbxAssignedKeyTypes.DataSource = AssignedKeyTypes;
            lbxAssignedKeyTypes.DisplayMember = "Name";
            lbxAssignedKeyTypes.ValueMember = "Id";
            //SelectedDoor.Update();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SelectedDoor.keytypes.Add((KeyType)lbxUnassignedKeyTypes.SelectedItem);
            //AssignedKeyTypes.Add((KeyType)lbxUnassignedKeyTypes.SelectedItem);
            UnassignedKeyTypes.RemoveAt(lbxUnassignedKeyTypes.SelectedIndex);
            AssignedKeyTypes = new BindingList<KeyType>(SelectedDoor.keytypes);
            lbxAssignedKeyTypes.DataSource = AssignedKeyTypes;
            lbxAssignedKeyTypes.DisplayMember = "Name";
            lbxAssignedKeyTypes.ValueMember = "Id";
        }
    }
}
