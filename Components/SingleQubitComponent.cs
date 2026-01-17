using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sim1Test.Circuit;
using Sim1Test.Maths;
using Sim1Test.Rendering;

namespace Sim1Test.Components
{
    public partial class SingleQubitComponent : UserControl
    {
        private StateVector qubit;
        private List<string> gateHistory = new List<string>();
        private Random rand = new Random();

        private readonly Color xGateColor = Color.FromArgb(230, 90, 90);
        private readonly Color yGateColor = Color.FromArgb(90, 200, 230);
        private readonly Color zGateColor = Color.FromArgb(160, 90, 230);
        private readonly Color hGateColor = Color.FromArgb(100, 180, 255);


        private string lastMeasurementResult = "?";
        private bool showMeasurementBox = false;

        public SingleQubitComponent()
        {
            InitializeComponent();

            qubit = new StateVector(1);

            this.DoubleBuffered = true;

            foreach (Control c in Controls)
            {
                if (c is ProbabilityBarsControl bars)
                {
                    probabilityBarsControl1 = bars;
                    break;
                }
            }

            if (probabilityBarsControl1 != null && !DesignMode)
            {
                probabilityBarsControl1.SetStates(new[] { "|0⟩", "|1⟩" });
                UpdateProbabilities();
            }
        }

        private void btnX_Click(object sender, EventArgs e) => ApplyGate("X", GateLibrary.X());
        private void btnY_Click(object sender, EventArgs e) => ApplyGate("Y", GateLibrary.Y());
        private void btnZ_Click(object sender, EventArgs e) => ApplyGate("Z", GateLibrary.Z());
        private void btnH_Click(object sender, EventArgs e) => ApplyGate("H", GateLibrary.H());
        private void btnMeasure_Click(object sender, EventArgs e) => MeasureQubit();
        private void btnReset_Click(object sender, EventArgs e) => ResetCircuit();


        private void ApplyGate(string gateSymbol, Matrix gateMatrix)
        {
            if (gateHistory.Count >= 4)
            {
                MessageBox.Show("Maximum 4 gates allowed!", "Circuit Limit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gateHistory.Add(gateSymbol);

            try
            {
                qubit.ApplySingleQubitGate(gateMatrix, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying gate: {ex.Message}", "Error");
                gateHistory.RemoveAt(gateHistory.Count - 1);
                return;
            }

            UpdateProbabilities();
            pnlCircuit.Invalidate();
        }


        private void UpdateProbabilities()
        {
            if (probabilityBarsControl1 == null || qubit == null || qubit.Amplitudes == null)
                return;

            double[] probs = new double[2];


            probs[0] = qubit.Amplitudes[0].SquireValue();
            probs[1] = qubit.Amplitudes[1].SquireValue();

            probs[0] = Math.Max(0, Math.Min(1, probs[0]));
            probs[1] = Math.Max(0, Math.Min(1, probs[1]));

            probabilityBarsControl1.SetProbabilities(probs);
        }


        private void MeasureQubit()
        {
            if (qubit == null || qubit.Amplitudes == null || qubit.Amplitudes.Length < 2)
                return;

            double p0 = qubit.Amplitudes[0].SquireValue();
            p0 = Math.Max(0, Math.Min(1, p0));

            bool measuredZero = rand.NextDouble() < p0;
            string measureResult;

            if (measuredZero)
            {
                qubit = new StateVector(1);
                measureResult = "0";
            }
            else
            {
                qubit = new StateVector(1);
                qubit.Amplitudes[0] = new ComplexNumber(0, 0);
                qubit.Amplitudes[1] = new ComplexNumber(1, 0);
                measureResult = "1";
            }


            lastMeasurementResult = measureResult;
            showMeasurementBox = true;

            UpdateProbabilities();
            pnlCircuit.Invalidate();
        }



        private void ResetCircuit()
        {
            qubit = new StateVector(1);
            gateHistory.Clear();
            lastMeasurementResult = "?";
            showMeasurementBox = false;
            UpdateProbabilities();
            pnlCircuit.Invalidate();
        }




        private void pnlCircuit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int wireY = pnlCircuit.Height / 2;

            int gateSpacing = 55;
            int gateCount = gateHistory.Count;

            int circuitWidth = (gateCount + 2) * gateSpacing;
            int wireStartX = (pnlCircuit.Width - circuitWidth) / 2;
            int wireEndX = wireStartX + circuitWidth;

            int measureX = wireEndX - gateSpacing / 2;

            using (Pen wirePen = new Pen(Color.FromArgb(60, 60, 60), 2))
                g.DrawLine(wirePen, wireStartX, wireY, wireEndX, wireY);

            using (Font labelFont = new Font("Consolas", 11, FontStyle.Bold))
            using (Brush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
                g.DrawString("|0⟩", labelFont, labelBrush, wireStartX - 45, wireY - 15);

            if (gateCount > 0)
            {
                int currentX = wireStartX + gateSpacing;

                foreach (string gate in gateHistory)
                {
                    Color gateColor;
                    if (gate == "X") gateColor = xGateColor;
                    else if (gate == "Y") gateColor = yGateColor;
                    else if (gate == "Z") gateColor = zGateColor;
                    else if (gate == "H") gateColor = hGateColor;
                    else gateColor = Color.Gray;

                    if (gate == "X") QuantumGateRenderer.DrawXGate(g, currentX, wireY, gateColor);
                    else if (gate == "Y") QuantumGateRenderer.DrawYGate(g, currentX, wireY, gateColor);
                    else if (gate == "Z") QuantumGateRenderer.DrawZGate(g, currentX, wireY, gateColor);
                    else if (gate == "H") QuantumGateRenderer.DrawHadamardGate(g, currentX, wireY, gateColor);

                    currentX += gateSpacing;
                }
            }

            Color measureColor = Color.FromArgb(90, 90, 140);
            QuantumGateRenderer.DrawGateBox(g, measureX, wireY, "M", measureColor);

            if (showMeasurementBox && lastMeasurementResult != "?")
            {
                Color outputBoxColor = lastMeasurementResult == "0"
                    ? Color.FromArgb(0, 180, 120)
                    : Color.FromArgb(220, 80, 80);

                int outputX = wireEndX + gateSpacing / 2;
                QuantumGateRenderer.DrawOutputBox(g, outputX, wireY, lastMeasurementResult, outputBoxColor);
            }
        }



        public void SetProbabilityBarsControl(ProbabilityBarsControl bars)
        {
            probabilityBarsControl1 = bars;
            if (probabilityBarsControl1 != null && !DesignMode)
            {
                probabilityBarsControl1.SetStates(new[] { "|0⟩", "|1⟩" });
                UpdateProbabilities();
            }
        }
    }
}
