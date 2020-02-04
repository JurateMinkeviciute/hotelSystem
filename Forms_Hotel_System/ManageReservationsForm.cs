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
    public partial class ManageReservationsForm : Form
    {
        Connection conn = new Connection();
        Reservation reserv = new Reservation();
        Room room = new Room();
        ManageMessage ms = new ManageMessage();

        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "categoryId";
            comboBoxClientId.DataSource = reserv.roomClientList();
            comboBoxClientId.DisplayMember = "Id";
            comboBoxClientId.ValueMember = "Id";
            dateTimeDateIn.Value = DateTime.Now;
            dateTimeDateOut.Value = DateTime.Now.AddDays(1);
            dataGridView1.DataSource = reserv.gettAllReserv();
            comboBoxClientId.ResetText();
            comboBoxRoomType.ResetText();
        }
        // To Clear All Form Fields
        public void clearAllFields()
        {
            textBoxReservId.Clear();
            comboBoxClientId.ResetText();
            comboBoxRoomType.ResetText();
            comboBoxRoomNr.ResetText();
            dateTimeDateIn.Value = DateTime.Now;
            dateTimeDateOut.Value = DateTime.Now.AddDays(1);
        }
        // To Change Room's Number By Room's Type
        private void changeRoomByType()
        {
            try
            {
                int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
                comboBoxRoomNr.DataSource = room.roomByType(type);
                comboBoxRoomNr.DisplayMember = "number";
                comboBoxRoomNr.ValueMember = "number";
            }
            catch (Exception)
            {
                // do nothing
            }
        }
        // To Change To Specific Type By Room's Number
        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeRoomByType();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }
        // To Display From DataGrid to Form's Fields
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int roomId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            comboBoxRoomType.SelectedValue = room.getRoomEditType(roomId);
            textBoxReservId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxRoomNr.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxClientId.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value;
            dateTimeDateIn.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimeDateOut.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        // To add New Reservation
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                String cntId = comboBoxClientId.Text;
                bool stringToIntClientId = int.TryParse(cntId, out int clientId);
                String rvId = textBoxReservId.Text;
                bool stringToIntReservId = int.TryParse(rvId, out int reservId);
                int roomNr = Convert.ToInt32(comboBoxRoomNr.SelectedValue);
                DateTime dateIn = dateTimeDateIn.Value;
                DateTime dateOut = dateTimeDateOut.Value;

                if (DateTime.Compare(dateIn, DateTime.Now.Date) < 0)//(dateIn < DateTime.Now.AddDays(-1))
                {
                    MessageBox.Show(ms.invalidDateIn, "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (DateTime.Compare(dateOut.Date, dateIn.Date) < 0)//(dateOut < dateIn)
                {
                    MessageBox.Show(ms.invalidDateOut, "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if (!stringToIntClientId)
                {
                    MessageBox.Show(ms.errorClientId, "Error - Client Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (clientId<0 || roomNr<0)
                    {
                        MessageBox.Show(ms.errorReservRequired, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Boolean insertReserv = reserv.insertReserv(roomNr, clientId, dateIn, dateOut);

                        if (insertReserv)
                        {
                            room.setRoomFree(roomNr, "NO");
                            dataGridView1.DataSource = reserv.gettAllReserv();
                            MessageBox.Show(ms.addedReserv, "Added Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(ms.errorNotAddReservation, "Not Added Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error - Not Added Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // To Edit Reservation
        private void btnEdit_Click(object sender, EventArgs e)
        {
            String cntId = comboBoxClientId.Text;
            bool stringToIntClientId = int.TryParse(cntId, out int clientId);
            String rvId = textBoxReservId.Text;
            bool stringToIntReservId = int.TryParse(rvId, out int reservId); ;
            int roomNr = Convert.ToInt32(comboBoxRoomNr.SelectedValue);
            DateTime dateIn = dateTimeDateIn.Value;
            DateTime dateOut = dateTimeDateOut.Value;
            int cellRoomNr = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            int formRoomNr = Convert.ToInt32(comboBoxRoomNr.Text);
            // Set Old Room To Free if Changed Room's Number
            if (cellRoomNr != formRoomNr)
            {
                room.setRoomFree(cellRoomNr, "YES");
            }
            if (clientId<0 || roomNr<0 || reservId<0)
            {
                MessageBox.Show(ms.errorReservRequiredFields, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!stringToIntClientId || !stringToIntReservId)
            {
                MessageBox.Show(ms.errorReservIds, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean updateReserv = reserv.editReserv(reservId, roomNr, clientId, dateIn, dateOut);

                if (updateReserv)
                {
                    //room.setRoomFreeNo(roomNr);
                    dataGridView1.DataSource = reserv.gettAllReserv();
                    MessageBox.Show(ms.updatedReserv, "Edited Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(ms.errorReservUpdate, "Can't edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // To Remove Reservation
        private void btnRemove_Click(object sender, EventArgs e)
        {
            String rvId = textBoxReservId.Text;
            bool stringToIntrvId = int.TryParse(rvId, out int reservId);
            int roomNr = Convert.ToInt32(comboBoxRoomNr.SelectedValue);
            if (!stringToIntrvId)
            {
                MessageBox.Show(ms.errorReservId, "Reservation Id Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean deleteReserv = reserv.removeRoom(reservId);
                if (deleteReserv)
                {
                    dataGridView1.DataSource = reserv.gettAllReserv();
                    room.setRoomFree(roomNr, "YES");
                    clearAllFields();
                    MessageBox.Show(ms.errorDeletedReserv, "Removed Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(ms.errorNotDeleteReserv, "Can't Remove Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ComboBoxes non-editable
        private void comboBoxClientId_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = true;
        }
        private void comboBoxRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBoxRoomNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
