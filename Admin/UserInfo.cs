using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sim1Test.Admin
{
    public partial class UserInfo : Form
    {



        private void LoadData()
        {
            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = @"
                        SELECT Email, FirstName, LastName, UserType, PhoneNumber, CreatedAt
                        FROM Users
                        ORDER BY CreatedAt DESC";

                    var dt = new DataTable();
                    con.Open();
                    da.Fill(dt);

                    

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        Name = "Email",
                        HeaderText = "Email",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "FirstName",
                        Name = "FirstName",
                        HeaderText = "First Name",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "LastName",
                        Name = "LastName",
                        HeaderText = "Last Name",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "UserType",
                        Name = "UserType",
                        HeaderText = "User Type",
                        ReadOnly = true
                    });



                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "PhoneNumber",
                        Name = "PhoneNumber",
                        HeaderText = "Phone",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "CreatedAt",
                        Name = "CreatedAt",
                        HeaderText = "Created Date",
                        ReadOnly = true
                    });

                    dataGridView1.DataSource = dt;
                    dataGridView1.RowTemplate.Height = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed.\r\n" + ex.Message);
            }
        }

        public UserInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Go to content page and select a content to update");
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            // LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            this.Hide();
            adminHome.ShowDialog();
            this.Close();
        }
    }
}
