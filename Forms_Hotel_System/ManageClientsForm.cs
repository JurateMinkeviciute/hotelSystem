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
    public partial class ManageClientsForm : Form
    {
        Client client = new Client();
        ManageMessage ms = new ManageMessage();

        private void ClearAllBoxes()
        {
            textBoxId.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhone.Clear();
            textBoxCountry.Clear();
        }

        public ManageClientsForm()
        {
            InitializeComponent();
        }
        private void ManageClientsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllBoxes();
        }
        // Added new Client
        private void btnNew_Click(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;
            String country = textBoxCountry.Text;
            if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals(""))
            {
                MessageBox.Show( ms.errorRequiredFlieds , "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean insertClient = client.insertClient(fname, lname, phone, country);

                if (insertClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show(ms.addedClient, "Added Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(ms.errorNotAdded, "Can't Add Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Edited Client
        private void btnEdit_Click(object sender, EventArgs e)
        {

            String num = textBoxId.Text;
            bool StringToIntId = int.TryParse(num, out int id);
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;
            String country = textBoxCountry.Text;

            if (!StringToIntId)
            {
                MessageBox.Show(ms.errorId, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals(""))
            {
                MessageBox.Show(ms.errorRequiredFlieds, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean updateClient = client.editClient(id, fname, lname, phone, country);

                if (updateClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show( ms.updatedClient, "Edited Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(ms.errorNotUpdate, "Can't edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Removed Client
        private void btnRemove_Click(object sender, EventArgs e)
        {
            String num = textBoxId.Text;
            bool StringToIntId = int.TryParse(num, out int id);

            if (!StringToIntId)
            {
                MessageBox.Show(ms.errorId, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean deleteClient = client.removeClient(id);
                if (deleteClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    ClearAllBoxes();
                    MessageBox.Show(ms.deletedClient, "Removed Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(ms.errorNotDeleted, "Can't remove Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Display the selected client data from datadridview to textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
