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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Role from Login where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                //Form2 f2 = new Form2(dt.Rows[0][0].ToString());
                //f2.Show();

                if (dt.Rows[0][0].ToString() == "Admin")
                {
                    Admin A = new Admin(dt.Rows[0][0].ToString());
                    A.Show();
                }
                /*
                else if (dt.Rows[0][0].ToString() == "User")
                {
                    User U = new User(dt.Rows[0][0].ToString());
                    U.Show();
                }
                else if (dt.Rows[0][0].ToString() == "Programmer")
                {
                    Programmer P = new Programmer(dt.Rows[0][0].ToString());
                    P.Show();
                }
                */
                else
                {
                    MessageBox.Show("Error!!! Login Again");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            formSignUp sUp = new formSignUp();
            sUp.Show();
        }
    }
}
