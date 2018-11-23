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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            string sqlQuery = "select * from BugReport where AppName='" + textBox1.Text+"'";//shows all data from  BugReport where AppName=textBox1.Text

            cmd = new SqlCommand(sqlQuery, connection);
            SqlDataReader DataRead = cmd.ExecuteReader();
            DataRead.Read();
            //shows all the datas in their respective fields
            if (DataRead.HasRows)
            {
                textBox1.Text = DataRead[0].ToString();
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
                connection.Close();

                //database connection
                connection.Open();
                string sqlQuery1 = "select * from Soln where AppName='" + textBox1.Text + "'";//shows all the datas from solution table where AppName=textBox1.Text

                SqlCommand cmd2 = new SqlCommand(sqlQuery1, connection);
                SqlDataReader DataRead1 = cmd2.ExecuteReader();
                DataRead1.Read();
                if (DataRead1.HasRows)
                {
                    textBox4.Text = DataRead1[1].ToString();
                }
                connection.Close();
              

            }
            else
            {
                MessageBox.Show("This data is not available");
            }
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
