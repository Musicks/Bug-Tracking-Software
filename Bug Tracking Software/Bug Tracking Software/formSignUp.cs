using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Bug_Tracking_Software
{
    public partial class formSignUp : Form
    {
        public formSignUp()
        {
            InitializeComponent();
        }
        private void formSignuUp_Load(object sender, EventArgs e)
        {
            label5.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (textPassword.Text == textPassword1.Text)
            {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
                String str = "insert into Login(Username, Password, Cpassword, Role) values('" + textUsername.Text + "','" + textPassword.Text + "', '" +textPassword1.Text + "', '" + textRole.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("You are now registered");
            }
            else
            {
                label5.Show();
                label5.Text = "Password do not match";
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
