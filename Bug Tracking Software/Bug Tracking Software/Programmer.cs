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
    public partial class Programmer : Form
    {
        String userName;
        public Programmer(String userName, String role)
        {
            InitializeComponent();
            this.userName = userName;
        }

        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hides the form and opens the Bug form
            this.Hide();
            Open Op = new Open(userName);
            Op.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hides the form and opens Login form
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void Programmer_Load(object sender, EventArgs e)
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
