using System;
using System.Drawing;
using System.Windows.Forms;
using Sim1Test.Algorithms;
using Sim1Test.Circuit;
using Sim1Test.Maths;
using Sim1Test.Rendering;
using Sim1Test.Components;

namespace Sim1Test.Components
{
    public partial class TeleportationComponent : UserControl
    {
        public bool ShowOutputs { get; set; } = false;
        public string OutputQ0 { get; set; } = "?";
        public string OutputQ1 { get; set; } = "?";
        public string OutputQ2 { get; set; } = "?";

        private readonly Color hadamardColor = Color.FromArgb(100, 180, 255);
        private readonly Color cnotControlColor = Color.FromArgb(80, 80, 80);
        private readonly Color cnotTargetColor = Color.FromArgb(255, 120, 80);
        private readonly Color wireColor = Color.FromArgb(60, 60, 60);
        private readonly Color outputBoxColor0 = Color.FromArgb(0, 180, 120);
        private readonly Color outputBoxColor1 = Color.FromArgb(220, 80, 80);

        private StateVector unknownState;
        private StateVector bellState;
        private StateVector teleportedState;


        private string currentUnknownLabel = "|0⟩";

        public TeleportationComponent()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            if (!DesignMode)
            {
                probBars.SetStates(new[]
                {
                    "|000⟩","|001⟩","|010⟩","|011⟩",
                    "|100⟩","|101⟩","|110⟩","|111⟩"
                });
                probBars.SetProbabilities(new double[8]);
            }
        }


        private void btnUnknown0_Click(object sender, EventArgs e)
        {
            currentUnknownLabel = "|0⟩";
            unknownState = new StateVector(1);
            lblUnknownDisplay.Text = "Unknown: |0⟩";
        }

        private void btnUnknown1_Click(object sender, EventArgs e)
        {
            currentUnknownLabel = "|1⟩";
            unknownState = new StateVector(1);
            unknownState.ApplySingleQubitGate(GateLibrary.X(), 0);
            lblUnknownDisplay.Text = "Unknown: |1⟩";
        }

        private void btnUnknownPlus_Click(object sender, EventArgs e)
        {
            currentUnknownLabel = "|+⟩";
            unknownState = new StateVector(1);
            unknownState.ApplySingleQubitGate(GateLibrary.H(), 0);
            lblUnknownDisplay.Text = "Unknown: |+⟩";
        }

        private void btnUnknownMinus_Click(object sender, EventArgs e)
        {
            currentUnknownLabel = "|-⟩";
            unknownState = new StateVector(1);
            unknownState.ApplySingleQubitGate(GateLibrary.X(), 0);
            unknownState.ApplySingleQubitGate(GateLibrary.H(), 0);
            lblUnknownDisplay.Text = "Unknown: |−⟩";

        }


        private void btnRunTeleport_Click(object sender, EventArgs e)
        {
            if (unknownState == null)
            {
                MessageBox.Show("Select an unknown state first.", "Teleportation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bellState = BellState.CreatePhiPlus();
            teleportedState = Teleportation.Teleport(unknownState, bellState);


            ComplexNumber[] amps = teleportedState.Amplitudes;

            double[] probs = new double[amps.Length];

            for (int i = 0; i < amps.Length; i++)
                probs[i] = amps[i].SquireValue();
            probBars.SetProbabilities(probs);

            int[] all = teleportedState.MeasureAllQubit();




            OutputQ0 = all[0].ToString();
            OutputQ1 = all[1].ToString();
            OutputQ2 = all[2].ToString();
            ShowOutputs = true;

            pnlCircuit.Invalidate();
        }


        private void pnlCircuit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int panelWidth = pnlCircuit.Width;
            int panelHeight = pnlCircuit.Height;

            int wireY0 = 50;
            int wireY1 = 110;
            int wireY2 = 170;

            int wireStartX = 40;
            int wireEndX = panelWidth - 40;

            int h1X = wireStartX + 60;
            int cnot1X = h1X + 70;
            int cnot2X = cnot1X + 80;
            int h2X = cnot2X + 70;  
            int measX = h2X + 60;
            int corrX = measX + 80; 
            int outputX = wireEndX - 30;

            using (Font labelFont = new Font("Consolas", 10, FontStyle.Bold))
            using (Brush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {
                g.DrawString("q₀ unknown", labelFont, labelBrush, 2, wireY0 - 12);
                g.DrawString("q₁ (Alice)", labelFont, labelBrush, 2, wireY1 - 12);
                g.DrawString("q₂ (Bob)", labelFont, labelBrush, 2, wireY2 - 12);
            }

            using (Pen wirePen = new Pen(wireColor, 2))
            {
                g.DrawLine(wirePen, wireStartX, wireY0, wireEndX, wireY0);
                g.DrawLine(wirePen, wireStartX, wireY1, wireEndX, wireY1);
                g.DrawLine(wirePen, wireStartX, wireY2, wireEndX, wireY2);
            }

            QuantumGateRenderer.DrawHadamardGate(g, h1X, wireY1, hadamardColor);
            QuantumGateRenderer.DrawCNOTGate(g, cnot1X, wireY1, wireY2,
                cnotControlColor, cnotTargetColor);

            QuantumGateRenderer.DrawCNOTGate(g, cnot2X, wireY0, wireY1,
                cnotControlColor, cnotTargetColor);
            QuantumGateRenderer.DrawHadamardGate(g, h2X, wireY0, hadamardColor);

            if (ShowOutputs)
            {
                Color m0Color = OutputQ0 == "0" ? outputBoxColor0 : outputBoxColor1;
                Color m1Color = OutputQ1 == "0" ? outputBoxColor0 : outputBoxColor1;

                QuantumGateRenderer.DrawOutputBox(g, measX, wireY0, OutputQ0, m0Color, 32);
                QuantumGateRenderer.DrawOutputBox(g, measX, wireY1, OutputQ1, m1Color, 32);
            }
            else
            {
                QuantumGateRenderer.DrawGateBox(g, measX, wireY0, "M", Color.FromArgb(120, 120, 120), 32);
                QuantumGateRenderer.DrawGateBox(g, measX, wireY1, "M", Color.FromArgb(120, 120, 120), 32);
            }

            using (Pen classicalPen = new Pen(Color.FromArgb(150, 120, 120, 120), 1))
            {
                classicalPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(classicalPen, measX + 20, wireY0, corrX - 20, wireY2 - 20);
                g.DrawLine(classicalPen, measX + 20, wireY1, corrX - 20, wireY2 + 20);
            }

            Color xColor = Color.FromArgb(230, 90, 90);
            Color zColor = Color.FromArgb(160, 90, 230);

            if (ShowOutputs)
            {
                if (OutputQ0 == "1")
                    QuantumGateRenderer.DrawXGate(g, corrX, wireY2 - 15, xColor);
                if (OutputQ1 == "1")
                    QuantumGateRenderer.DrawZGate(g, corrX, wireY2 + 15, zColor);
            }
            else
            {
                QuantumGateRenderer.DrawGateBox(g, corrX, wireY2, "corr", Color.FromArgb(150, 150, 150));
            }

            if (ShowOutputs)
            {
                Color colorQ2 = OutputQ2 == "0" ? outputBoxColor0 : outputBoxColor1;
                QuantumGateRenderer.DrawOutputBox(g, outputX, wireY2, OutputQ2, colorQ2);

                using (Font font = new Font("Segoe UI", 8, FontStyle.Italic))
                using (Brush brush = new SolidBrush(Color.FromArgb(90, 90, 150)))
                {
                    g.DrawString($"Teleported ≈ {currentUnknownLabel}",
                        font, brush, outputX - 40, wireY2 + 30);
                }
            }
        }

        private void TeleportationComponent_Load(object sender, EventArgs e)
        {

        }

        private void probBars_Load(object sender, EventArgs e)
        {

        }
    }
}
