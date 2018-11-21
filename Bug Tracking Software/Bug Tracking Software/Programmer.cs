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
            this.Hide();
            Open Op = new Open(userName);
            Op.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void Programmer_Load(object sender, EventArgs e)
        {

        }
    }
}
