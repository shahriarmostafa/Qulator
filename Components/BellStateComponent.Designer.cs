namespace Sim1Test.Components
{
    partial class BellStateComponent
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPhiPlus;
        private System.Windows.Forms.Button btnPsiPlus;
        private System.Windows.Forms.Panel pnlCircuit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPhiPlus = new System.Windows.Forms.Button();
            this.btnPsiPlus = new System.Windows.Forms.Button();
            this.pnlCircuit = new System.Windows.Forms.Panel();
            this.runSimulation = new System.Windows.Forms.Button();
            this.probabilityBarsControl1 = new Sim1Test.Components.ProbabilityBarsControl();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(27, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(242, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bell State Circuit (Φ⁺ / Ψ⁺)";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnPhiPlus
            // 
            this.btnPhiPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnPhiPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhiPlus.FlatAppearance.BorderSize = 0;
            this.btnPhiPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhiPlus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPhiPlus.ForeColor = System.Drawing.Color.White;
            this.btnPhiPlus.Location = new System.Drawing.Point(32, 58);
            this.btnPhiPlus.Name = "btnPhiPlus";
            this.btnPhiPlus.Size = new System.Drawing.Size(137, 28);
            this.btnPhiPlus.TabIndex = 1;
            this.btnPhiPlus.Text = "Create Φ⁺";
            this.btnPhiPlus.UseVisualStyleBackColor = false;
            this.btnPhiPlus.Click += new System.EventHandler(this.btnPhiPlus_Click);
            // 
            // btnPsiPlus
            // 
            this.btnPsiPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnPsiPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPsiPlus.FlatAppearance.BorderSize = 0;
            this.btnPsiPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPsiPlus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPsiPlus.ForeColor = System.Drawing.Color.White;
            this.btnPsiPlus.Location = new System.Drawing.Point(175, 58);
            this.btnPsiPlus.Name = "btnPsiPlus";
            this.btnPsiPlus.Size = new System.Drawing.Size(137, 28);
            this.btnPsiPlus.TabIndex = 2;
            this.btnPsiPlus.Text = "Create Ψ⁺";
            this.btnPsiPlus.UseVisualStyleBackColor = false;
            this.btnPsiPlus.Click += new System.EventHandler(this.btnPsiPlus_Click);
            // 
            // pnlCircuit
            // 
            this.pnlCircuit.BackColor = System.Drawing.Color.White;
            this.pnlCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCircuit.Location = new System.Drawing.Point(32, 126);
            this.pnlCircuit.Name = "pnlCircuit";
            this.pnlCircuit.Size = new System.Drawing.Size(480, 174);
            this.pnlCircuit.TabIndex = 3;
            this.pnlCircuit.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCircuit_Paint);
            // 
            // runSimulation
            // 
            this.runSimulation.BackColor = System.Drawing.Color.Tomato;
            this.runSimulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runSimulation.FlatAppearance.BorderSize = 0;
            this.runSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runSimulation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.runSimulation.ForeColor = System.Drawing.Color.White;
            this.runSimulation.Location = new System.Drawing.Point(32, 92);
            this.runSimulation.Name = "runSimulation";
            this.runSimulation.Size = new System.Drawing.Size(137, 28);
            this.runSimulation.TabIndex = 5;
            this.runSimulation.Text = "▶  Run Simulation";
            this.runSimulation.UseVisualStyleBackColor = false;
            this.runSimulation.Click += new System.EventHandler(this.button1_Click);
            // 
            // probabilityBarsControl1
            // 
            this.probabilityBarsControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.probabilityBarsControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.probabilityBarsControl1.Location = new System.Drawing.Point(32, 306);
            this.probabilityBarsControl1.Name = "probabilityBarsControl1";
            this.probabilityBarsControl1.Size = new System.Drawing.Size(480, 118);
            this.probabilityBarsControl1.TabIndex = 6;
            // 
            // BellStateComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.probabilityBarsControl1);
            this.Controls.Add(this.runSimulation);
            this.Controls.Add(this.pnlCircuit);
            this.Controls.Add(this.btnPsiPlus);
            this.Controls.Add(this.btnPhiPlus);
            this.Controls.Add(this.lblTitle);
            this.Name = "BellStateComponent";
            this.Size = new System.Drawing.Size(551, 454);
            this.Load += new System.EventHandler(this.BellStateComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runSimulation;
        private ProbabilityBarsControl probabilityBarsControl1;
    }
}
