using System;
using System.Drawing;
using System.Windows.Forms;
using Sim1Test.Algorithms.GroverSearch;
using Sim1Test.Circuit;
using Sim1Test.Maths;
using Sim1Test.Rendering;

namespace Sim1Test.Components
{
    public partial class GroverSearchComponent : UserControl
    {
        private readonly Color hadamardColor = Color.FromArgb(100, 180, 255);
        private readonly Color oracleColor = Color.FromArgb(255, 100, 100);
        private readonly Color diffuserColor = Color.FromArgb(100, 200, 100);
        private readonly Color wireColor = Color.FromArgb(60, 60, 60);
        private readonly Color outputBoxColor0 = Color.FromArgb(0, 180, 120);
        private readonly Color outputBoxColor1 = Color.FromArgb(220, 80, 80);

        private StateVector currentState;
        private int markedIndex = 0;
        private int iteration = 0;
        private bool superpositionReady = false;
        private bool oracleApplied = false;
        private bool diffuserApplied = false;
        private int[] measuredBits;
        private bool ShowOutputs;

        public GroverSearchComponent()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            probabilityBarsControl1.SetProbabilities(new double[16]);
            if (!DesignMode && probabilityBarsControl1 != null)
            {
                probabilityBarsControl1.SetStates(new string[] {
                    "|0000⟩",
                    "|0001⟩",
                    "|0010⟩",
                    "|0011⟩",
                    "|0100⟩",
                    "|0101⟩",
                    "|0110⟩",
                    "|0111⟩",
                    "|1000⟩",
                    "|1001⟩",
                    "|1010⟩",
                    "|1011⟩",
                    "|1100⟩",
                    "|1101⟩",
                    "|1110⟩",
                    "|1111⟩"
                });
            }
        }

        private void btnSuperposition_Click(object sender, EventArgs e)
        {
            ResetState();
            currentState = new StateVector(4);

            for (int q = 0; q < 4; q++)
            {
                currentState.ApplySingleQubitGate(GateLibrary.H(), q);
            }

            superpositionReady = true;
            iteration = 0;
            oracleApplied = false;
            diffuserApplied = false;
            UpdateProbabilities();
            pnlCircuit.Invalidate();
            lblStatus.Text = "Status: Superposition ready (all 6.25%)";
        }

        private void btnSetTarget_Click(object sender, EventArgs e)
        {
            if (!superpositionReady)
            {
                MessageBox.Show("Click 'Superposition' first!", "Grover Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtTarget.Text, out markedIndex) && markedIndex >= 0 && markedIndex <= 15)
            {
                oracleApplied = false;
                diffuserApplied = false;
                iteration = 0;
                lblStatus.Text = $"Status: Target |{Convert.ToString(markedIndex, 2).PadLeft(4, '0')}⟩ marked";
                pnlCircuit.Invalidate();
            }
            else
            {
                MessageBox.Show("Enter target 0-15 (binary 0000 to 1111)", "Invalid Target",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOracle_Click(object sender, EventArgs e)
        {
            if (!superpositionReady || oracleApplied)
            {
                MessageBox.Show("Click 'Superposition' → Set target → 'Mark Target'", "Step missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GroverOracle4Q.ApplyOracle(currentState, markedIndex);
            oracleApplied = true;
            diffuserApplied = false;
            UpdateProbabilities();
            lblStatus.Text = $"Status: Oracle marked |{Convert.ToString(markedIndex, 2).PadLeft(4, '0')}⟩ (iteration {++iteration})";
            pnlCircuit.Invalidate();
        }

        private void btnDiffuser_Click(object sender, EventArgs e)
        {
            if (!superpositionReady || !oracleApplied)
            {
                MessageBox.Show("Complete: Superposition → Set target → Mark target → 'Diffuse'", "Step missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            GroverDiffuser4Q.ApplyDiffuser(currentState);
            UpdateProbabilities();
            GroverOracle4Q.ApplyOracle(currentState, markedIndex);
            lblStatus.Text = $"Status: Diffuser applied (iteration {iteration})";
            pnlCircuit.Invalidate();
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (!superpositionReady || iteration == 0)
            {
                MessageBox.Show("Run at least 1 full iteration first!", "Grover Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            measuredBits = currentState.MeasureAllQubit();

            

            int measuredIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                if (measuredBits[i] == 1)
                    measuredIndex |= (1 << i);
            }

            string targetBin = Convert.ToString(markedIndex, 2).PadLeft(4, '0');
            string measuredBin = Convert.ToString(measuredIndex, 2).PadLeft(4, '0');
            string status = measuredIndex == markedIndex ? " ✓ FOUND!" : " ✗ Not found";

            lblStatus.Text = $"Measured: |{measuredBin}⟩ (dec {measuredIndex}) | Target: |{targetBin}⟩ (dec {markedIndex}){status}";
            ShowOutputs = true;
            UpdateProbabilities();
            pnlCircuit.Invalidate();
        }

        private void ResetState()
        {
            superpositionReady = false;
            oracleApplied = false;
            diffuserApplied = false;
            iteration = 0;
            markedIndex = 0;
            measuredBits = null;
            ShowOutputs = false;
            txtTarget.Text = "0";
            lblStatus.Text = "Status: Ready";
        }

        private void UpdateProbabilities()
        {
            if (currentState == null) return;

            double[] probs = new double[16];
            ComplexNumber[] amps = currentState.Amplitudes;
            for (int i = 0; i < 16; i++)
            {
                probs[i] = amps[i].SquireValue();
            }
            probabilityBarsControl1.SetProbabilities(probs);
        }

        private void pnlCircuit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int panelWidth = pnlCircuit.Width;
            int panelHeight = pnlCircuit.Height;


            int[] wireYs = { 50, 100, 150, 200 };
            int wireStartX = 70;
            int wireEndX = panelWidth - 50;

            using (Font labelFont = new Font("Consolas", 10, FontStyle.Bold))
            using (Brush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {

                g.DrawString("q3: |0⟩", labelFont, labelBrush, 5, wireYs[0] - 15);
                g.DrawString("q2: |0⟩", labelFont, labelBrush, 5, wireYs[1] - 15);
                g.DrawString("q1: |0⟩", labelFont, labelBrush, 5, wireYs[2] - 15);
                g.DrawString("q0: |0⟩", labelFont, labelBrush, 5, wireYs[3] - 15);
            }

            using (Pen wirePen = new Pen(wireColor, 2))
            {
                foreach (int y in wireYs)
                {
                    g.DrawLine(wirePen, wireStartX, y, wireEndX, y);
                }
            }

            int currentX = wireStartX + 50;


            if (superpositionReady)
            {
                for (int q = 0; q < 4; q++)
                {
                    QuantumGateRenderer.DrawHadamardGate(g, currentX, wireYs[q], hadamardColor);
                }
                currentX += 50;
            }


            if (superpositionReady && markedIndex >= 0)
            {

                for (int q = 0; q < 4; q++)
                {
                    bool bit = ((markedIndex >> q) & 1) == 1;
                    if (!bit)
                    {

                        int wireIdx = 3 - q;
                        QuantumGateRenderer.DrawXGate(g, currentX, wireYs[wireIdx], oracleColor);
                    }
                }
                currentX += 40;


                QuantumGateRenderer.DrawGateBox(g, currentX, (wireYs[1] + wireYs[2]) / 2, "MCZ", oracleColor);


                using (Pen controlPen = new Pen(oracleColor, 2))
                {
                    g.DrawLine(controlPen, currentX, wireYs[0], currentX, wireYs[3]);

                    for (int i = 0; i < 4; i++)
                    {
                        g.FillEllipse(new SolidBrush(oracleColor), currentX - 4, wireYs[i] - 4, 8, 8);
                    }
                }
                currentX += 50;
            }


            if (diffuserApplied)
            {

                for (int q = 0; q < 4; q++)
                {
                    QuantumGateRenderer.DrawHadamardGate(g, currentX, wireYs[q], diffuserColor);
                }
                currentX += 40;


                for (int q = 0; q < 4; q++)
                {
                    QuantumGateRenderer.DrawXGate(g, currentX, wireYs[q], Color.FromArgb(200, 150, 100));
                }
                currentX += 40;


                QuantumGateRenderer.DrawGateBox(g, currentX, (wireYs[1] + wireYs[2]) / 2, "MCZ", diffuserColor);

                using (Pen controlPen = new Pen(diffuserColor, 2))
                {
                    g.DrawLine(controlPen, currentX, wireYs[0], currentX, wireYs[3]);
                    for (int i = 0; i < 4; i++)
                    {
                        g.FillEllipse(new SolidBrush(diffuserColor), currentX - 4, wireYs[i] - 4, 8, 8);
                    }
                }
                currentX += 40;

                for (int q = 0; q < 4; q++)
                {
                    QuantumGateRenderer.DrawXGate(g, currentX, wireYs[q], Color.FromArgb(200, 150, 100));
                }
                currentX += 40;

                for (int q = 0; q < 4; q++)
                {
                    QuantumGateRenderer.DrawHadamardGate(g, currentX, wireYs[q], diffuserColor);
                }
                currentX += 50;
            }


            if (ShowOutputs && measuredBits != null && measuredBits.Length == 4)
            {
                int outputX = Math.Max(currentX + 20, wireEndX - 30);

                

                for (int q = 0; q < 4; q++)
                {
                    int wireIdx = 3 - q;
                    int bitValue = measuredBits[q];

                    Color boxColor = bitValue == 0 ? outputBoxColor0 : outputBoxColor1;

                    QuantumGateRenderer.DrawOutputBox(
                        g,
                        outputX,
                        wireYs[wireIdx],
                        bitValue.ToString(),
                        boxColor
                    );
                }
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}