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
using System.IO;
using System.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bug_Tracking_Software
{
    public partial class AdminAppoint : Form
    {
       
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public AdminAppoint()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            //TO-DO Validation of form
            if (txtAssignTO.Text != "")
            {
                //assign a bug to a progrommer
                connection.Open();
                string sqlQuery = "UPDATE BugReport Set AssignTo = '" + txtAssignTO.Text + "' WHERE AppName = '" + textBox1.Text + "';";

                cmd = new SqlCommand(sqlQuery, connection);
                SqlDataReader DataRead = cmd.ExecuteReader();
                MessageBox.Show("ASSIGNED");
                connection.Close();

            }
            else {
                MessageBox.Show("Please write ID Of a User");
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //shows all the bugs when the button is clicked
            connection.Open();
            string sqlQuery = "select AppName, BugName, Description from BugReport where AppName='" + textBox1.Text + "'";

            cmd = new SqlCommand(sqlQuery, connection);
            SqlDataReader DataRead = cmd.ExecuteReader();
            DataRead.Read();

            if (DataRead.HasRows)
            {
                textBox1.Text = DataRead[0].ToString();
                textBox2.Text = DataRead[1].ToString();
                textBox3.Text = DataRead[2].ToString();

            }


            else
            {
                MessageBox.Show("This data is not available");
            }
            connection.Close();
        }
        private void AdminAppoint_Load(object sender, EventArgs e)
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
