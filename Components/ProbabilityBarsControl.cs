using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sim1Test.Components
{
    public partial class ProbabilityBarsControl : UserControl
    {
        private class BarRow
        {
            public Label LabelState;
            public Label LabelValue;
            public ProgressBar Bar;
        }

        private readonly List<BarRow> rows = new List<BarRow>();

        public ProbabilityBarsControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Configure the control for N basis states with given labels.
        /// Example: SetStates(new[] {\"|00⟩\",\"|01⟩\",\"|10⟩\",\"|11⟩\"});
        /// </summary>
        public void SetStates(string[] stateLabels)
        {
            SuspendLayout();
            // Clear old rows
            foreach (var r in rows)
            {
                Controls.Remove(r.LabelState);
                Controls.Remove(r.LabelValue);
                Controls.Remove(r.Bar);
                r.LabelState.Dispose();
                r.LabelValue.Dispose();
                r.Bar.Dispose();
            }
            rows.Clear();

            int xLabel = 10;
            int xValue = 80;
            int xBar = 150;
            int y = 10;
            int rowHeight = 24;

            foreach (string label in stateLabels)
            {
                var lblState = new Label
                {
                    AutoSize = true,
                    Font = new Font("Consolas", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 50, 80),
                    Location = new Point(xLabel, y),
                    Text = $"P({label}):"
                };

                var lblValue = new Label
                {
                    AutoSize = true,
                    Font = new Font("Consolas", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 50, 80),
                    Location = new Point(xValue, y),
                    Text = "---"
                };

                var bar = new ProgressBar
                {
                    Location = new Point(xBar, y + 1),
                    Size = new Size(Math.Max(10, Width - xBar - 10), 18),
                    Minimum = 0,
                    Maximum = 100
                };

                Controls.Add(lblState);
                Controls.Add(lblValue);
                Controls.Add(bar);

                rows.Add(new BarRow
                {
                    LabelState = lblState,
                    LabelValue = lblValue,
                    Bar = bar
                });

                y += rowHeight;
            }

            ResumeLayout();
        }

        /// <summary>
        /// Update probabilities (0..1). Length must match number of states.
        /// </summary>
        public void SetProbabilities(double[] probabilities)
        {
            if (probabilities == null) return;
            if (probabilities.Length != rows.Count) { 
                MessageBox.Show(probabilities.Length.ToString());
                return;
            }

            for (int i = 0; i < rows.Count; i++)
            {
                double p = probabilities[i];
                if (p < 0) p = 0;
                if (p > 1) p = 1;

                rows[i].LabelValue.Text = $"{p * 100:F1}%";
                rows[i].Bar.Value = (int)(p * 100);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int xBar = 150;
            foreach (var r in rows)
            {
                r.Bar.Size = new Size(Math.Max(10, Width - xBar - 10), r.Bar.Height);
            }
        }
    }
}
