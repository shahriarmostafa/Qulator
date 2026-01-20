using Sim1Test.Components;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sim1Test
{
    public partial class SimulationPage : Form
    {
        private BellStateComponent bellStateComponent;
        private ProbabilityBarsControl probabilityBarsControl;
        private SingleQubitComponent singleQubitComponent;
        private SuperdenseCodingComponent superdenseCodingComponent;
        private TeleportationComponent teleportationComponent;
        private GroverSearchComponent groverSearchComponent;

        private string FirstName;
        private string LastName;
        private string email;
        private string UserType;
        private string PhoneNumber;
        public SimulationPage(string email)
        {
            InitializeComponent();
            InitializeUserControls();
            this.email = email;
            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = @"SELECT FirstName, LastName, UserType, PhoneNumber FROM Users WHERE Email = @Email";
                    cmd.Parameters.AddWithValue("@Email", email);

                    var table = new DataTable();
                    da.Fill(table);
                    var row = table.Rows[0];

                    FirstName = row["FirstName"].ToString();
                    LastName = row["LastName"].ToString();
                    UserType = row["UserType"].ToString();
                    PhoneNumber = row["PhoneNumber"].ToString();
                }
                userNameLabel.Text = FirstName + " " + LastName;
                userEmail.Text = "(" + email + ")";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Application failed.\r\n" + ex.Message);
            }
            string[] content = GetContent("qubit");

            ShowComponent(
                singleQubitComponent,
                content[0],
                content[1]
            );
            lblTitle.Text = "Hi, " + FirstName + " " + LastName;
        }



        private void InitializeUserControls()
        {
            bellStateComponent = new BellStateComponent();
            probabilityBarsControl = new ProbabilityBarsControl();
            singleQubitComponent = new SingleQubitComponent();
            superdenseCodingComponent = new SuperdenseCodingComponent();
            teleportationComponent = new TeleportationComponent();
            groverSearchComponent = new GroverSearchComponent();
        }


        private void ShowComponent(Control component, string title, string description)
        {
            mainContentPanel.Controls.Clear();
            mainContentPanel.AutoScroll = true;

            if (component.Parent != null)
                component.Parent.Controls.Remove(component);

            // Wrapper
            Panel wrapper = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(20),
                Margin = new Padding(0)
            };

            // Title
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 4)
            };

            // Description
            Label lblDesc = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 9),
                MaximumSize = new Size(mainContentPanel.Width - 80, 0),
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 12)
            };

            // Component
            component.Dock = DockStyle.Top;
            component.Margin = new Padding(0);

            // IMPORTANT: Add in REVERSE order
            wrapper.Controls.Add(component);
            wrapper.Controls.Add(lblDesc);
            wrapper.Controls.Add(lblTitle);

            mainContentPanel.Controls.Add(wrapper);
        }


        private string[]  GetContent(string contentKey)
        {
            using (var con = Database.CreateConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"SELECT title, description FROM Contents WHERE content_key = @key";

                cmd.Parameters.AddWithValue("@key", contentKey);

                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (new string[] {
                            reader["title"].ToString(),
                            reader["description"].ToString()
                        });
                    }
                }
                return null;
            }
        }







        private void singleQubitButton_Click(object sender, EventArgs e)
        {
            string[] content = GetContent("qubit");

            ShowComponent(
                singleQubitComponent,
                content[0],
                content[1]
            );
        }

        private void bellStateButton_Click(object sender, EventArgs e)
        {
            string[] content = GetContent("bellstate");

            ShowComponent(
                bellStateComponent,
                content[0],
                content[1]
            );
        }

        private void superdenseButton_Click(object sender, EventArgs e)
        {
            string[] content = GetContent("superdensecoding");

            ShowComponent(
                superdenseCodingComponent,
                content[0],
                content[1]
            );
        }

        private void teleportationButton_Click(object sender, EventArgs e)
        {
            string[] content = GetContent("teleportation");

            ShowComponent(
                teleportationComponent,
                content[0],
                content[1]
            );
        }

        private void groverSearchButton_Click(object sender, EventArgs e)
        {
            if(UserType!= "pro-user")
            {
                MessageBox.Show("You are not a pro user to access. Apply for pro");
                return;
            }
            string[] content = GetContent("groversearch");

            ShowComponent(
                groverSearchComponent,
                content[0],
                content[1]
            );
        }

        private void forecastButton_Click(object sender, EventArgs e)
        {
            if (UserType != "pro-user")
            {
                MessageBox.Show("You are not a pro user to access. Apply for pro");
                return;
            }
            WeatherForm weatherform = new WeatherForm(email);
            this.Hide();
            weatherform.ShowDialog();
            this.Close();
        }

        private void applyProButton_Click(object sender, EventArgs e)
        {
            if (UserType != "User")
            {
                MessageBox.Show("You are already a pro user");
                return;
            }

            try
            {
                using (var con = Database.CreateConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserApplications (FirstName, LastName,PhoneNumber, Email) VALUES (@FirstName, @LastName,@PhoneNumber, @Email);";

                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        MessageBox.Show("Application successful.");
                    }
                    else
                    {
                        MessageBox.Show("Application failed. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while application.\r\n" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
            this.Close();
        }

        private void mainContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SimulationPage_Load(object sender, EventArgs e)
        {

        }
    }
}
