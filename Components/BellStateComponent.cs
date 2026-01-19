using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using Sim1Test.Algorithms;
using Sim1Test.Circuit;
using Sim1Test.Maths;
using Sim1Test.Rendering;

namespace Sim1Test.Components
{
    public partial class BellStateComponent : UserControl
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


        private StateVector entangledState;
        public BellStateComponent()
        {
            InitializeComponent();

            probabilityBarsControl1.SetStates(new[] { "|00⟩", "|01⟩", "|10⟩", "|11⟩" });

            this.DoubleBuffered = true;

            if (!DesignMode)
            {
                probabilityBarsControl1.SetProbabilities(new[] { 0.0, 0.0, 0.0, 0.0 });
            }

        }


        private void btnPhiPlus_Click(object sender, EventArgs e)
        {
            entangledState = BellState.CreatePhiPlus();
            ComplexNumber[] amps = entangledState.Amplitudes;
            double p00 = amps[0].SquireValue();
            double p01 = amps[1].SquireValue();
            double p10 = amps[2].SquireValue();
            double p11 = amps[3].SquireValue();
            probabilityBarsControl1.SetProbabilities(new[] { p00, p01, p10, p11 });

        }

        private void btnPsiPlus_Click(object sender, EventArgs e)
        {
            
            entangledState = BellState.CreatePsiPlus();
            ComplexNumber[] amps = entangledState.Amplitudes;

            double p00 = amps[0].SquireValue();
            double p01 = amps[1].SquireValue();
            double p10 = amps[2].SquireValue();
            double p11 = amps[3].SquireValue();
            probabilityBarsControl1.SetProbabilities(new[] { p00, p01, p10, p11 });

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(entangledState == null) {
                return;
            }
            ComplexNumber[] amps = entangledState.Amplitudes;
            int[] result = entangledState.MeasureAllQubit();
            string q0 = result[0].ToString();
            string q1 = result[1].ToString();

            ShowOutputs = true;
            OutputQ0 = q0;
            OutputQ1 = q1;
            pnlCircuit.Invalidate();


            double p00 = amps[0].SquireValue();
            double p01 = amps[1].SquireValue();
            double p10 = amps[2].SquireValue();
            double p11 = amps[3].SquireValue();
            probabilityBarsControl1.SetProbabilities(new[] { p00, p01, p10, p11 });

        }

        private void pnlCircuit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int panelWidth = pnlCircuit.Width;
            int panelHeight = pnlCircuit.Height;
            int wireY0 = 70, wireY1 = 140;
            int wireStartX = 60, wireEndX = panelWidth - 80;
            int hadamardX = 150, cnotX = 280, outputX = wireEndX - 30;

            using (Font labelFont = new Font("Consolas", 12, FontStyle.Bold))
            using (Brush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {
                g.DrawString("|0⟩  q₀", labelFont, labelBrush, 5, wireY0 - 10);
                g.DrawString("|0⟩  q₁", labelFont, labelBrush, 5, wireY1 - 10);
            }

            using (Pen wirePen = new Pen(wireColor, 2))
            {
                g.DrawLine(wirePen, wireStartX, wireY0, wireEndX, wireY0);
                g.DrawLine(wirePen, wireStartX, wireY1, wireEndX, wireY1);
            }

            QuantumGateRenderer.DrawHadamardGate(g, hadamardX, wireY0, hadamardColor);
            QuantumGateRenderer.DrawCNOTGate(g, cnotX, wireY0, wireY1, cnotControlColor, cnotTargetColor);

            if (!DesignMode && ShowOutputs)
            {
                Color colorQ0 = OutputQ0 == "0" ? outputBoxColor0 : outputBoxColor1;
                Color colorQ1 = OutputQ1 == "0" ? outputBoxColor0 : outputBoxColor1;

                QuantumGateRenderer.DrawOutputBox(g, outputX, wireY0, OutputQ0, colorQ0);
                QuantumGateRenderer.DrawOutputBox(g, outputX, wireY1, OutputQ1, colorQ1);

            }
        }




        private void progProb00_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void BellStateComponent_Load(object sender, EventArgs e)
        {

        }

        private void pnlProbabilities_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
