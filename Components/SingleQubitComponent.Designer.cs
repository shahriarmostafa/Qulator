namespace Sim1Test.Components
{
    partial class SingleQubitComponent
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCircuit;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnY;
        private System.Windows.Forms.Button btnZ;
        private System.Windows.Forms.Button btnH;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlCircuit = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.btnY = new System.Windows.Forms.Button();
            this.btnZ = new System.Windows.Forms.Button();
            this.btnH = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.probabilityBarsControl2 = new Sim1Test.Components.ProbabilityBarsControl();
            this.probabilityBarsControl1 = new Sim1Test.Components.ProbabilityBarsControl();
            this.SuspendLayout();
            // 
            // pnlCircuit
            // 
            this.pnlCircuit.BackColor = System.Drawing.Color.White;
            this.pnlCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCircuit.Location = new System.Drawing.Point(44, 48);
            this.pnlCircuit.Name = "pnlCircuit";
            this.pnlCircuit.Size = new System.Drawing.Size(483, 96);
            this.pnlCircuit.TabIndex = 6;
            this.pnlCircuit.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCircuit_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(39, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(214, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Single Qubit Simulator";
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(114, 240);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(64, 26);
            this.btnX.TabIndex = 1;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // btnY
            // 
            this.btnY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnY.FlatAppearance.BorderSize = 0;
            this.btnY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnY.ForeColor = System.Drawing.Color.White;
            this.btnY.Location = new System.Drawing.Point(184, 240);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(64, 26);
            this.btnY.TabIndex = 2;
            this.btnY.Text = "Y";
            this.btnY.UseVisualStyleBackColor = false;
            this.btnY.Click += new System.EventHandler(this.btnY_Click);
            // 
            // btnZ
            // 
            this.btnZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(90)))), ((int)(((byte)(230)))));
            this.btnZ.FlatAppearance.BorderSize = 0;
            this.btnZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnZ.ForeColor = System.Drawing.Color.White;
            this.btnZ.Location = new System.Drawing.Point(254, 240);
            this.btnZ.Name = "btnZ";
            this.btnZ.Size = new System.Drawing.Size(64, 26);
            this.btnZ.TabIndex = 3;
            this.btnZ.Text = "Z";
            this.btnZ.UseVisualStyleBackColor = false;
            this.btnZ.Click += new System.EventHandler(this.btnZ_Click);
            // 
            // btnH
            // 
            this.btnH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.btnH.FlatAppearance.BorderSize = 0;
            this.btnH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnH.ForeColor = System.Drawing.Color.White;
            this.btnH.Location = new System.Drawing.Point(44, 240);
            this.btnH.Name = "btnH";
            this.btnH.Size = new System.Drawing.Size(64, 26);
            this.btnH.TabIndex = 4;
            this.btnH.Text = "H";
            this.btnH.UseVisualStyleBackColor = false;
            this.btnH.Click += new System.EventHandler(this.btnH_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.btnMeasure.FlatAppearance.BorderSize = 0;
            this.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMeasure.ForeColor = System.Drawing.Color.White;
            this.btnMeasure.Location = new System.Drawing.Point(324, 240);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(104, 26);
            this.btnMeasure.TabIndex = 5;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = false;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(434, 240);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 26);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // probabilityBarsControl2
            // 
            this.probabilityBarsControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.probabilityBarsControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.probabilityBarsControl2.Location = new System.Drawing.Point(44, 150);
            this.probabilityBarsControl2.Name = "probabilityBarsControl2";
            this.probabilityBarsControl2.Size = new System.Drawing.Size(483, 74);
            this.probabilityBarsControl2.TabIndex = 9;
            // 
            // probabilityBarsControl1
            // 
            this.probabilityBarsControl1.BackColor = System.Drawing.Color.White;
            this.probabilityBarsControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.probabilityBarsControl1.Location = new System.Drawing.Point(0, 453);
            this.probabilityBarsControl1.Name = "probabilityBarsControl1";
            this.probabilityBarsControl1.Size = new System.Drawing.Size(10, 14);
            this.probabilityBarsControl1.TabIndex = 8;
            // 
            // SingleQubitComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.probabilityBarsControl2);
            this.Controls.Add(this.probabilityBarsControl1);
            this.Controls.Add(this.pnlCircuit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.btnH);
            this.Controls.Add(this.btnZ);
            this.Controls.Add(this.btnY);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.lblTitle);
            this.Name = "SingleQubitComponent";
            this.Size = new System.Drawing.Size(574, 285);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProbabilityBarsControl probabilityBarsControl2;
        private ProbabilityBarsControl probabilityBarsControl1;
    }
}
