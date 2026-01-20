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
    public partial class Applications : Form
    {
        public Applications()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////Login log = new Login();
            //UserInfo userInfo = new UserInfo();
            //this.Hide();
            ////log.ShowDialog();
            //userInfo.ShowDialog();
            //this.Close();
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
            this.Close();
            


        }

        private void LoadData()
        {
            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = @" SELECT Email, FirstName, LastName, PhoneNumber FROM UserApplications";
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
                        DataPropertyName = "lastName",
                        Name = "FirstName",
                        HeaderText = "Last Name",
                        ReadOnly = true
                    });



                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "PhoneNumber",
                        Name = "PhoneNumber",
                        HeaderText = "Phone",
                        ReadOnly = true
                    });


                    DataGridViewButtonColumn acceptColumn = new DataGridViewButtonColumn
                    {
                        Name = "AcceptColumn",
                        HeaderText = "Accept",
                        Text = "Accept",
                        UseColumnTextForButtonValue = true
                    };

                    DataGridViewButtonColumn rejectColumn = new DataGridViewButtonColumn
                    {
                        Name = "RejectColumn",
                        HeaderText = "Reject",
                        Text = "Reject",
                        UseColumnTextForButtonValue = true
                    };

                    dataGridView1.Columns.Add(acceptColumn);
                    dataGridView1.Columns.Add(rejectColumn);



                    dataGridView1.CellContentClick += actionDone;


                    dataGridView1.DataSource = dt;
                    dataGridView1.RowTemplate.Height = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed.\r\n" + ex.Message);
            }
        }

        private void actionDone(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "AcceptColumn":
                        AcceptUser(email);
                        break;

                    case "RejectColumn":
                        RejectUser(email);
                        break;


                }
            }
        }

        private void AcceptUser(string email)
        {
            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    con.Open();

                    cmd.CommandText = @"UPDATE Users SET UserType = @UserType WHERE Email = @Email;";

                    cmd.Parameters.AddWithValue("@UserType", "pro-user");
                    cmd.Parameters.AddWithValue("@Email", email);

                    var affected = cmd.ExecuteNonQuery();

                    if (affected == 0)
                    {
                        MessageBox.Show("Accept failed: user not found.");
                        return;
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = @"
DELETE FROM UserApplications
WHERE Email = @Email;";

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                MessageBox.Show("User accepted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Accept failed.\r\n" + ex.Message);
            }
        }


        private void RejectUser(string email)
        {
            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
DELETE FROM UserApplications
WHERE Email = @Email;";

                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    var affected = cmd.ExecuteNonQuery();

                    if (affected == 0)
                    {
                        MessageBox.Show("Reject failed: application not found.");
                        return;
                    }
                }

                LoadData();
                MessageBox.Show("User rejected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reject failed.\r\n" + ex.Message);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //UserInfo userInfo = new UserInfo();
            //this.Hide();
            //userInfo.ShowDialog();
            //this.Close ();

            AdminHome adminHome = new AdminHome();
            this.Hide();
            adminHome.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Go to content page and select a content to update");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Applications_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
