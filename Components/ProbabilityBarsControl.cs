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


        public void SetStates(string[] stateLabels)
        {
            SuspendLayout();
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

            bool twoColumns = stateLabels.Length > 2;
            int cols = twoColumns ? 2 : 1;
            int rowsCount = (stateLabels.Length + cols - 1) / cols;

            int colWidth = Width / cols;
            int xLabel = 10;
            int xValue = 80;
            int xBar = 150;
            int rowHeight = 24;
            int yStart = 10;

            for (int i = 0; i < stateLabels.Length; i++)
            {
                int col = i % cols;
                int row = i / cols;
                int xOffset = col * colWidth;
                int y = yStart + row * rowHeight;

                var lblState = new Label
                {
                    AutoSize = true,
                    Font = new Font("Consolas", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 50, 80),
                    Location = new Point(xLabel + xOffset, y),
                    Text = $"P({stateLabels[i]}):"
                };

                var lblValue = new Label
                {
                    AutoSize = true,
                    Font = new Font("Consolas", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 50, 80),
                    Location = new Point(xValue + xOffset, y),
                    Text = "---"
                };

                var bar = new ProgressBar
                {
                    Location = new Point(xBar + xOffset, y + 1),
                    Size = new Size(Math.Max(10, colWidth - xBar - 10), 18),
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
            }

            ResumeLayout();
        }


        public void SetProbabilities(double[] probabilities)
        {
            if (probabilities == null) return;
            if (probabilities.Length != rows.Count)
            {
                MessageBox.Show("Length doesn't match" + rows.Count + "the prob length: " + probabilities.Length);
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
            bool twoColumns = rows.Count > 2;
            int cols = twoColumns ? 2 : 1;
            int colWidth = Width / cols;
            int xBar = 150;

            for (int i = 0; i < rows.Count; i++)
            {
                int col = i % cols;
                int xOffset = col * colWidth;
                rows[i].Bar.Size = new Size(Math.Max(10, colWidth - xBar - 10), rows[i].Bar.Height);
            }
        }
    }
}
