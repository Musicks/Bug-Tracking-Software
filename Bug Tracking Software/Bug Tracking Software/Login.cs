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
            label4.Hide(); //hiding the label when form loads
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();//closes when user clicks the button
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login part when the user Logs in
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Role from Login where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
               

                if (dt.Rows[0][0].ToString() == "Admin")
                {
                    Admin A = new Admin("Admin");
                    A.Show();
                }
                
                else if (dt.Rows[0][0].ToString() == "User")
                {
                    User U = new User("User");
                    U.Show();
                }
                
                else
                {
                    Programmer P = new Programmer(textBox1.Text, "Programmer");
                    P.Show();
                }
                
               
            }
            else
            {
                //shows error when there is a mistake in Login 
                label4.Show();
                label4.Text = "Error!!! Login Again";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //opens new form named formSignUp
            this.Hide();
            formSignUp sUp = new formSignUp();
            sUp.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
