using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SQL_Injection
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void BtnConsult_Click(object sender, EventArgs e)
        {
            try
            {
                //1; drop table deleteme
                MySqlConnection con = new MySqlConnection(@"server=127.0.0.1;user id=root;database=sqli");
                con.Open();

                MySqlCommand comand = new MySqlCommand("SELECT name,pass FROM users WHERE id = " + TxtID.Text + ";", con);
                comand.Parameters.Clear();
                comand.CommandType = CommandType.Text;

                MySqlDataReader ql = comand.ExecuteReader();
                ql.Read();

                TxtName.Text = ql.GetString(0);
                TxtPass.Text = ql.GetString(1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Use ID from 0 to 3.\n\nDatabase error: " + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can use the following payload to delete a table:\n\n1;drop table deleteme");
        }
    }
}
