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
    public partial class UpdateContent : Form
    {

        private string content_key;
        public UpdateContent(string content_key)
        {
            
            this.content_key = content_key;
            InitializeComponent();


            using (var con = Database.CreateConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"SELECT title, description FROM Contents WHERE content_key = @key";

                cmd.Parameters.AddWithValue("@key", content_key);

                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        titleBox.Text = reader["title"].ToString();
                        descriptionBox.Text = reader["description"].ToString();
                    }
                }
            }
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
            AdminHome adminHome = new AdminHome();
            this.Hide();
            adminHome.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var title = (titleBox.Text ?? string.Empty).Trim();
            var description = descriptionBox.Text ?? string.Empty;


            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    con.Open();

                    cmd.CommandText = @"UPDATE Contents SET title = @title, description = @description WHERE content_key = @content_key;";

                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@content_key", content_key);

                    var affected = cmd.ExecuteNonQuery();

                    if (affected == 0)
                    {
                        MessageBox.Show("Filed to update");
                        return;
                    }
                }

                MessageBox.Show("Updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\r\n" + ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
