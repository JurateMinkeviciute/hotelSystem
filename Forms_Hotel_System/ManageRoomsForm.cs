using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms_Hotel_System
{
    public partial class ManageRoomsForm : Form
    {
        Room room = new Room();
        ManageMessage ms = new ManageMessage();

        // A Function To Clean Form's Fields
        public void clearRoomFields()
        {
            textBoxNumber.Clear();
            comboBoxType.ResetText();
            textBoxPhone.Clear();
            radioButtonYes.Checked = true;
        }
        public ManageRoomsForm()
        {
            InitializeComponent();
        }
        private void ManageRoomsForm_Load(object sender, EventArgs e)
        {
            comboBoxType.DataSource = room.roomTypeList();
            comboBoxType.SelectedIndex = 0;
            comboBoxType.DisplayMember = "label";
            comboBoxType.ValueMember = "categoryId";
            dataGridView1.DataSource = room.getRooms();
        }
        //Clean Form's Fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearRoomFields();
        }
        // Insert New Room
        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            String num = textBoxNumber.Text;
            int type = Convert.ToInt32(comboBoxType.SelectedValue.ToString());
            String phone = textBoxPhone.Text;
            String free = "";

            if (radioButtonYes.Checked)
                free = "YES";
            else if (radioButtonNo.Checked)
                free = "NO";

            bool strToIntNumber = int.TryParse(num, out int number);

            if (!strToIntNumber)
            {
                MessageBox.Show(ms.errorRoomNumber, "Error - Room Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (number<0 || phone.Trim().Equals("") || comboBoxType.SelectedIndex == -1 || free == "")
            {
                MessageBox.Show(ms.errorRoomRequiredFields, "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                Boolean insertRoom = room.insertRoom(number, type, phone, free);
                if(insertRoom)
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show(ms.addedRoom, "Added Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ms.errorNotAddedRoom, "Can't Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            String num = textBoxNumber.Text;
            int type = Convert.ToInt32(comboBoxType.SelectedValue.ToString());
            String phone = textBoxPhone.Text;
            String free = "";

            if (radioButtonYes.Checked)
                free = "YES";
            else if (radioButtonNo.Checked)
                free = "NO";

            bool strToIntNumber = int.TryParse(num, out int number);

            if (!strToIntNumber)
            {
                MessageBox.Show(ms.errorRoomNumber, "Error - Room Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean editRoom = room.editRoom(number, type, phone, free);
                if(editRoom)
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show(ms.editedRoom, "Edited Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ms.errorNotEditRoom, "Can't Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            String num = textBoxNumber.Text;
            Boolean strToIntNumber = int.TryParse(num, out int number);

            if (!strToIntNumber)
            {
                MessageBox.Show(ms.errorRoomNumber, "Can't Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean removeRoom = room.removeRoom(number);
                if (removeRoom)
                {
                    dataGridView1.DataSource = room.getRooms();
                    clearRoomFields();
                    MessageBox.Show(ms.deletedRoom, "Deleted Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ms.errorNotDeleteRoom, "Can't Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // display selected row data from datagridview to textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxType.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String free = dataGridView1.CurrentRow.Cells[3].Value.ToString().ToUpper();

            if (free.Equals("YES"))
            {
                radioButtonYes.Checked = true;
            } else if (free.Equals("NO"))
            {
                radioButtonNo.Checked = true;
            }
        }
        // ComboBox non-editable
        private void comboBoxType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
