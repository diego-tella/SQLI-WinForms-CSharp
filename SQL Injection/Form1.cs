using System;
using System.Windows.Forms;
namespace SQL_Injection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login aa = new Login();
            aa.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Credits formCredits = new Credits();
            formCredits.Show();
        }
    }
}
