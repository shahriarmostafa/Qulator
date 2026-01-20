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
    }
}
