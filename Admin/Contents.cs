using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sim1Test.Admin
{
    public partial class Contents : Form
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
                        SELECT content_key, title, description FROM Contents";

                    var dt = new DataTable();
                    con.Open();
                    da.Fill(dt);



                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "content_key",
                        Name = "content_key",
                        HeaderText = "Content Key",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "title",
                        Name = "title",
                        HeaderText = "title",
                        ReadOnly = true
                    });




                    DataGridViewButtonColumn acceptColumn = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };



                    dataGridView1.Columns.Add(acceptColumn);



                    dataGridView1.CellContentClick += editContent;

                    dataGridView1.DataSource = dt;
                    dataGridView1.RowTemplate.Height = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed.\r\n" + ex.Message);
            }
        }


        private void editContent(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string content_key = dataGridView1.Rows[e.RowIndex].Cells["content_key"].Value.ToString();
                UpdateContent upCon = new UpdateContent(content_key);
                this.Hide();
                upCon.ShowDialog();
                this.Close();
            }
            

        }

        public Contents()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Applications application = new Applications();
            this.Hide();
            application.ShowDialog();
            this.Close();
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
            MessageBox.Show("Go to content page and select a content to edit");
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            // LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
