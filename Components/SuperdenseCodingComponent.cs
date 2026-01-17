using System;
using System.Drawing;
using System.Windows.Forms;
using Sim1Test.Algorithms;
using Sim1Test.Circuit;
using Sim1Test.Maths;
using Sim1Test.Rendering;

namespace Sim1Test.Components
{
    public partial class SuperdenseCodingComponent : UserControl
    {
        public bool ShowOutputs { get; set; } = false;
        public string OutputQ0 { get; set; } = "?";
        public string OutputQ1 { get; set; } = "?";

        private readonly Color hadamardColor = Color.FromArgb(100, 180, 255);
        private readonly Color cnotControlColor = Color.FromArgb(80, 80, 80);
        private readonly Color cnotTargetColor = Color.FromArgb(255, 120, 80);
        private readonly Color wireColor = Color.FromArgb(60, 60, 60);
        private readonly Color outputBoxColor0 = Color.FromArgb(0, 180, 120);
        private readonly Color outputBoxColor1 = Color.FromArgb(220, 80, 80);

        // Your algorithm object
        private SuperdenseCoding algo = new SuperdenseCoding();

        // Cache of the current state (for probabilities)
        private StateVector currentState;

        private int bit0 = 0;
        private int bit1 = 0;

        public SuperdenseCodingComponent()
        {
            InitializeComponent();

            probabilityBarsControl1.SetStates(new[] { "|00⟩", "|01⟩", "|10⟩", "|11⟩" });

            this.DoubleBuffered = true;

            if (!DesignMode)
            {
                probabilityBarsControl1.SetProbabilities(new[] { 0.0, 0.0, 0.0, 0.0 });
            }
        }


        private void btnMsg00_Click(object sender, EventArgs e)
        {
            SetMessageAndEncode(0, 0);
        }

        private void btnMsg01_Click(object sender, EventArgs e)
        {
            SetMessageAndEncode(0, 1);
        }

        private void btnMsg10_Click(object sender, EventArgs e)
        {
            SetMessageAndEncode(1, 0);
        }

        private void btnMsg11_Click(object sender, EventArgs e)
        {
            SetMessageAndEncode(1, 1);
        }

        private void SetMessageAndEncode(int b0, int b1)
        {
            bit0 = b0;
            bit1 = b1;

            algo.SetMessage(bit0, bit1);
            algo.PrepareBell();         
            algo.Encode(bit0, b1);      

            currentState = algo.GetState();
            if (currentState != null)
            {
                ComplexNumber[] amps = currentState.Amplitudes;
                double p00 = amps[0].SquireValue();
                double p01 = amps[1].SquireValue();
                double p10 = amps[2].SquireValue();
                double p11 = amps[3].SquireValue();
                probabilityBarsControl1.SetProbabilities(new[] { p00, p01, p10, p11 });
            }

            ShowOutputs = false;
            pnlCircuit.Invalidate();
        }


        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (currentState == null)
                return;

            algo.DecodeAndMeasure();
            int[] decoded = algo.GetDecodedBits();
            if (decoded == null || decoded.Length < 2)
                return;

            OutputQ0 = decoded[0].ToString();
            OutputQ1 = decoded[1].ToString();
            ShowOutputs = true;

            currentState = algo.GetState();
            if (currentState != null)
            {
                ComplexNumber[] amps = currentState.Amplitudes;
                double p00 = amps[0].SquireValue();
                double p01 = amps[1].SquireValue();
                double p10 = amps[2].SquireValue();
                double p11 = amps[3].SquireValue();
                probabilityBarsControl1.SetProbabilities(new[] { p00, p01, p10, p11 });
            }

            pnlCircuit.Invalidate();
        }




        private static double Clamp01(double v)
        {
            if (v < 0) return 0;
            if (v > 1) return 1;
            return v;
        }


        private void pnlCircuit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int panelWidth = pnlCircuit.Width;
            int panelHeight = pnlCircuit.Height;

            int wireY0 = 60;   // Alice
            int wireY1 = 130;  // Bob
            int wireStartX = 40;
            int wireEndX = panelWidth - 40;

            int h1X = wireStartX + 60;
            int cnot1X = h1X + 90;
            int encodeX = cnot1X + 90;
            int cnot2X = encodeX + 90;
            int h2X = cnot2X + 90;
            int outputX = wireEndX - 30;

            using (Font labelFont = new Font("Consolas", 11, FontStyle.Bold))
            using (Brush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {
                g.DrawString("|0⟩  Alice (q₀)", labelFont, labelBrush, 2, wireY0 - 10);
                g.DrawString("|0⟩  Bob   (q₁)", labelFont, labelBrush, 2, wireY1 - 10);
            }

            using (Pen wirePen = new Pen(wireColor, 2))
            {
                g.DrawLine(wirePen, wireStartX, wireY0, wireEndX, wireY0);
                g.DrawLine(wirePen, wireStartX, wireY1, wireEndX, wireY1);
            }

            // Bell pair preparation
            QuantumGateRenderer.DrawHadamardGate(g, h1X, wireY0, hadamardColor);
            QuantumGateRenderer.DrawCNOTGate(g, cnot1X, wireY0, wireY1, cnotControlColor, cnotTargetColor);

            // Encoding hint on circuit (optional visual only)
            // Use the same rules as your Encode: Z if bit0=1, X if bit1=1.
            Color xColor = Color.FromArgb(230, 90, 90);
            Color zColor = Color.FromArgb(160, 90, 230);

            if (bit0 == 0 && bit1 == 0)
            {
                QuantumGateRenderer.DrawGateBox(g, encodeX, wireY0, "I",
                    Color.FromArgb(120, 120, 120));
            }
            else if (bit0 == 0 && bit1 == 1)
            {
                QuantumGateRenderer.DrawXGate(g, encodeX, wireY0, xColor);
            }
            else if (bit0 == 1 && bit1 == 0)
            {
                QuantumGateRenderer.DrawZGate(g, encodeX, wireY0, zColor);
            }
            else // 11 -> Z then X
            {
                QuantumGateRenderer.DrawZGate(g, encodeX, wireY0 - 18, zColor);
                QuantumGateRenderer.DrawXGate(g, encodeX, wireY0 + 18, xColor);
            }

            // Bob's decode: CNOT then H on Alice’s qubit
            QuantumGateRenderer.DrawCNOTGate(g, cnot2X, wireY0, wireY1, cnotControlColor, cnotTargetColor);
            QuantumGateRenderer.DrawHadamardGate(g, h2X, wireY0, hadamardColor);

            if (!DesignMode && ShowOutputs)
            {
                Color colorQ0 = OutputQ0 == "0" ? outputBoxColor0 : outputBoxColor1;
                Color colorQ1 = OutputQ1 == "0" ? outputBoxColor0 : outputBoxColor1;

                QuantumGateRenderer.DrawOutputBox(g, outputX, wireY0, OutputQ0, colorQ0);
                QuantumGateRenderer.DrawOutputBox(g, outputX, wireY1, OutputQ1, colorQ1);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void progProb00_Click(object sender, EventArgs e)
        {

        }

        private void SuperdenseCodingComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
