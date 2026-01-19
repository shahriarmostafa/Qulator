using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sim1Test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var email = (txtEmail.Text ?? string.Empty).Trim();
            var password = txtPassword.Text ?? string.Empty;

            if(email == "admin")
            {
                if(password == "1234")
                {
                    Registration reg = new Registration();
                    this.Hide();
                    reg.ShowDialog();
                    this.Close();
                    return;
                }
            }
            {

            }

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT COUNT(1)
FROM Users
WHERE Email = @Email AND Password = @Password;";

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    var count =(int) cmd.ExecuteScalar();

                    if (count == 1)
                    {
                        MessageBox.Show("Login successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SimulationPage sim = new SimulationPage(email);
                        this.Hide();
                        sim.ShowDialog();
                        this.Close();
                        return;
                    }
                }

                MessageBox.Show("Invalid email or password.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed.\r\n" + ex.Message);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
