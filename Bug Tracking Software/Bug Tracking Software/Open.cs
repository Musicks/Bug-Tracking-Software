using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bug_Tracking_Software
{
    public partial class Open : Form
    {
        String userName;
        SqlCommand cmd;
        public Open(String userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");


        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }


        private void Open_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sqlQuery = "select * from BugReport where AppName='" + comboBox1.Text + "' AND AssignTo = '" + userName + "'";

            cmd = new SqlCommand(sqlQuery, connection);
            SqlDataReader DataRead = cmd.ExecuteReader();
            DataRead.Read();

            if (DataRead.HasRows)
            {
                comboBox1.Text = DataRead[0].ToString();
                textBox2.Text = DataRead[1].ToString();
                textBox3.Text = DataRead[2].ToString();
                byte[] images = (byte[])DataRead[3];

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
        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlConnection connection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            connection1.Open();
            cmd = new SqlCommand("insert into Soln (AppName,Solution)values('" + comboBox1.Text + "','" + textBox4.Text + "')", connection1);

            cmd.ExecuteNonQuery();
            connection1.Close();
            MessageBox.Show("Updated");

        }

        private void liveRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens a live repo website in chrome
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://github.com/login";


            driver.FindElement(By.Id("login_field")).SendKeys("breakdowns.blasts@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("Khadka15");
            driver.FindElement(By.Name("commit")).Click();

        }
    }
}