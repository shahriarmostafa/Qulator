using System;
using System.Data.SqlClient;
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPssword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var firstName = (txtFirstName.Text ?? string.Empty).Trim();
            var lastName = (txtLastName.Text ?? string.Empty).Trim();
            var email = (txtEmail.Text ?? string.Empty).Trim();
            var phone = (txtPhone.Text ?? string.Empty).Trim();
            var password = txtPassword.Text ?? string.Empty;
            var confirm = txtConfirmPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Password and Confirm Password do not match.");
                return;
            }

            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO Users (FirstName, LastName, Email, PhoneNumber, Password)
VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Password);";

                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        MessageBox.Show("Registration successful.");

                        Login loginForm = new Login();
                        this.Hide();
                        loginForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while registering.\r\n" + ex.Message);
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
