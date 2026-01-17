// SimulationPage.cs - Complete code
using Sim1Test.Components;
using System;
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

        public SimulationPage()
        {
            InitializeComponent();
            InitializeUserControls();

        }

        private void InitializeUserControls()
        {
            bellStateComponent = new BellStateComponent() { Dock = DockStyle.Fill };
            probabilityBarsControl = new ProbabilityBarsControl() { Dock = DockStyle.Fill };
            singleQubitComponent = new SingleQubitComponent() { Dock = DockStyle.Fill };
            superdenseCodingComponent = new SuperdenseCodingComponent() { Dock = DockStyle.Fill };
            teleportationComponent = new TeleportationComponent() { Dock = DockStyle.Fill };

            mainContentPanel.Controls.AddRange(new Control[] {
                bellStateComponent, probabilityBarsControl, singleQubitComponent,
                superdenseCodingComponent, teleportationComponent });

            HideAllUserControls();
            singleQubitComponent.Visible = true;
        }

        private void HideAllUserControls()
        {
            bellStateComponent.Visible = false;
            probabilityBarsControl.Visible = false;
            singleQubitComponent.Visible = false;
            superdenseCodingComponent.Visible = false;
            teleportationComponent.Visible = false;
        }

        private void SimulationPage_Load(object sender, EventArgs e)
        {
        }

        private void btnBellState_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            bellStateComponent.Visible = true;
            lblTitle.Text = "Bell State";
        }

        private void btnProbabilityBars_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            probabilityBarsControl.Visible = true;
            lblTitle.Text = "Probability Bars";
        }

        private void btnSingleQubit_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            singleQubitComponent.Visible = true;
            lblTitle.Text = "Single Qubit";
        }

        private void btnSuperdenseCoding_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            superdenseCodingComponent.Visible = true;
            lblTitle.Text = "Superdense Coding";
        }
        private void btnTeleportation_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            teleportationComponent.Visible = true;
            lblTitle.Text = "Teleportation";
        }

        private void sidebarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void singleQubitButton_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            singleQubitComponent.Visible = true;
            lblTitle.Text = "Single Qubit Circuit";
        }

        private void bellStateButton_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            bellStateComponent.Visible = true;
            lblTitle.Text = "Bell State";
        }

        private void superdenseButton_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            superdenseCodingComponent.Visible = true;
            lblTitle.Text = "Superdense Coding";
        }

        private void teleportationButton_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            teleportationComponent.Visible = true;
            lblTitle.Text = "Teleportation Algorithm";
        }

        private void forecastButton_Click(object sender, EventArgs e)
        {
            WeatherForm weatherform = new WeatherForm();
            this.Hide();
            weatherform.ShowDialog();
            this.Close();
        }
    }
}
