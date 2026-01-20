using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sim1Test.Admin
{
    public partial class AdminHome : Form
    {

        public AdminHome()
        {

            InitializeComponent();


            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Applications ap = new Applications();
            this.Hide();
            ap.ShowDialog();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }

        private void UpdateContent_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserInfo ur = new UserInfo();
            this.Hide();
            ur.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserInfo ur = new UserInfo();
            this.Hide();
            ur.ShowDialog();
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Contents ct = new Contents();
            this.Hide();
            ct.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddContent ac = new AddContent();
            this.Hide();
            ac.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            UpdateContent uc = new UpdateContent("yourContentKey");
            this.Hide();
            uc.ShowDialog();
            this.Close();
        }
    }
}
