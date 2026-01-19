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

        //user information
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
            ShowComponent(
                singleQubitComponent,
                "Bell State",
                "This simulation demonstrates quantum entanglement between two qubits using Bell states."
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

            Panel wrapper = new Panel();
            wrapper.Dock = DockStyle.Top;
            wrapper.AutoSize = true;
            wrapper.Padding = new Padding(20);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;

            Label lblDesc = new Label();
            lblDesc.Text = description;
            lblDesc.Font = new Font("Segoe UI", 9);
            lblDesc.MaximumSize = new Size(mainContentPanel.Width - 80, 0);
            lblDesc.AutoSize = true;
            lblDesc.Dock = DockStyle.Top;
            lblDesc.Padding = new Padding(0, 5, 0, 15);

            component.Dock = DockStyle.Top;
            component.Height = component.PreferredSize.Height;


            wrapper.Controls.Add(lblDesc);
            wrapper.Controls.Add(lblTitle);
            wrapper.Controls.Add(component);
            

            mainContentPanel.Controls.Add(wrapper);
        }








        private void singleQubitButton_Click(object sender, EventArgs e)
        {
            ShowComponent(
                singleQubitComponent,
                "Bell State",
                "This simulation demonstrates quantum entanglement between two qubits using Bell states."
            );
        }

        private void bellStateButton_Click(object sender, EventArgs e)
        {

            ShowComponent(
                bellStateComponent,
                "Bell State",
                "This simulation demonstrates quantum entanglement between two qubits using Bell states."
            );
        }

        private void superdenseButton_Click(object sender, EventArgs e)
        {
            ShowComponent(
                superdenseCodingComponent,
                "Bell State",
                "This simulation demonstrates quantum entanglement between two qubits using Bell states."
            );
        }

        private void teleportationButton_Click(object sender, EventArgs e)
        {
            ShowComponent(
                teleportationComponent,
                "Bell State",
                "This simulation demonstrates quantum entanglement between two qubits using Bell states."
            );
        }

        private void groverSearchButton_Click(object sender, EventArgs e)
        {
            ShowComponent(
                groverSearchComponent,
                "Bell State",
                "This simulation demonstrates quantum entanglement between two qubits using Bell states."
            );
        }

        private void forecastButton_Click(object sender, EventArgs e)
        {
            WeatherForm weatherform = new WeatherForm();
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


    }
}
