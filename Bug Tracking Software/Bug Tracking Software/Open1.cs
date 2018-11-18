using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bug_Tracking_Software
{
    public partial class Open1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;

        public Open1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");


        private void Open1_Load(object sender, EventArgs e)
        {
            


        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sqlQuery = "select * from BugReport where AppName='" + textBox1.Text + "'";

            cmd = new SqlCommand(sqlQuery, connection);
            SqlDataReader DataRead = cmd.ExecuteReader();
            DataRead.Read();

            if (DataRead.HasRows)
            {
                textBox1.Text = DataRead[0].ToString();
                textBox2.Text = DataRead[1].ToString();
                textBox3.Text = DataRead[2].ToString();
               
                byte[] images = (byte[])DataRead[3];
                 textBox4.Text = DataRead[4].ToString();
                
                if (images == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mstreem = new MemoryStream(images);
                    pictureBox1.Image = Image.FromStream(mstreem);
                }

            }
            else
            {
                MessageBox.Show("This data is not available");
            }
            connection.Close();

        }
    }
}
