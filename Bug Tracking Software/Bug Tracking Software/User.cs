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
            this.Close();
            InsertBug bug = new InsertBug();
            bug.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void solutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Open1 op1 = new Open1();
            op1.Show();

        }
    }
}
