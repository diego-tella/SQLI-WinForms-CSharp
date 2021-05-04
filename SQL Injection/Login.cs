using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SQL_Injection
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(@"server=127.0.0.1;user id=root;database=sqli");
                con.Open();

                MySqlCommand comand = new MySqlCommand("SELECT * FROM names WHERE name ='" + TxtUser.Text + "' AND pass ='" + TxtPass.Text + "';", con);
                comand.Parameters.Clear();
                comand.CommandType = CommandType.Text;

                MySqlDataReader ql = comand.ExecuteReader();
                ql.Read();
                try
                {
                    if (ql.GetString(0).Length > 0)
                    {
                        MessageBox.Show("Logged!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in database: " + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Ssdsd' or 2=2;#
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can use the following payload to gain access: \n\npass' or 1=1;#");
        }
    }
}
