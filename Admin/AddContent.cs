using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sim1Test.Admin
{
    public partial class AddContent : Form
    {
        public AddContent()
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

        private void button3_Click(object sender, EventArgs e)
        {
            var primarykey = (keyBox.Text ?? string.Empty).Trim();
            var title = (titleBox.Text ?? string.Empty).Trim();
            var description = (contentBox.Text ?? string.Empty).Trim();



            if (string.IsNullOrWhiteSpace(primarykey) ||
                string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(description) )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO Contents (content_key, title, description)
VALUES (@content_key, @title, @description);";

                    cmd.Parameters.AddWithValue("@content_key", primarykey);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);


                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Content add successful.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Content add failed.\r\n" + ex.Message);
            }
        }


    }
}
