using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Bug_Tracking_Software
{
    public partial class InsertBug : Form
    {

        public InsertBug()
        {
            InitializeComponent();
        }

        

        private void InsertBug_Load(object sender, EventArgs e)
        {

        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baula\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        String imgLocation = "";
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Choose Image(*.jpg; *.png)|*.jpg; *.png";
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
            else
            {
                MessageBox.Show("Upload Again");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream Streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(Streem);
            images = brs.ReadBytes((int)Streem.Length);

            connection.Open();
            String sqlQuery = "Insert into BugReport(AppName, BugName, Description, Image)Values('"+comboBox1.Text+"','"+textBox2.Text+"','"+txtDes.Text+"',@images)";
            cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.Add(new SqlParameter("@images",images));
            int N = cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(N.ToString() + "Data Saved Sucessfully");

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
