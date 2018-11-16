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
            this.Close();
        }
    }
}
