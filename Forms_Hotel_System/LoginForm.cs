using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Forms_Hotel_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ManageMessage ms = new ManageMessage();
            Connection conn = new Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String query = "SELECT * FROM users WHERE username=@usr AND password=@pass";

            command.CommandText = query;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usr", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            //if account exist, it opens main form
            if(table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mform = new MainForm();
                mform.Show();
            }
            else
            {
                if(textBoxUsername.Text.Trim().Equals(""))
                {
                    MessageBox.Show( ms.errorLoginUsername , "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show(ms.errorLoginPassword, "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    MessageBox.Show(ms.errorLoginIncorrect, "Incorrect Login Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                textBoxUsername.Focus();
            }

        }
    }
}
