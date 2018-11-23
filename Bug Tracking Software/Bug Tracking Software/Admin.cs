using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Software
{
    public partial class Admin : Form
    {
        public Admin(String role)
        {
            InitializeComponent();
            label3.Text = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();//closes when user clicks the button
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens a SignUp page for Admin
            Admin_User aUser = new Admin_User();
            aUser.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //signs out from the current page
            this.Close();
            Login Lo = new Login();
            Lo.Show();
        }

        private void bugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //appoints the new bugs to programmer
            AdminAppoint AdminBug = new AdminAppoint();
            AdminBug.Show();
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
