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
    public partial class User : Form
    {
        

        public User(String role)
        {
            InitializeComponent();
            toolStripStatusLabel.Text = role;
        }
        

        private void User_Load(object sender, EventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insertBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //closes the form and opens InsertBug form
            this.Close();
            InsertBug bug = new InsertBug();
            bug.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hides the form and opens Login form
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void solutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hides the form and opens solution form
            this.Hide();
            Open1 op1 = new Open1();
            op1.Show();

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
