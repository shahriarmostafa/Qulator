using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sim1Test
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Login loginForm = new Login();  // Create a new instance of Form1 (Login)
            this.Hide();                    // Hide Form2
            loginForm.ShowDialog();         // Show Form1 as a modal dialog
            this.Close();
        }
    }
}
