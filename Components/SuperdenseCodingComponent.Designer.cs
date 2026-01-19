namespace Sim1Test.Components
{
    partial class SuperdenseCodingComponent
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMsg00;
        private System.Windows.Forms.Button btnMsg01;
        private System.Windows.Forms.Button btnMsg10;
        private System.Windows.Forms.Button btnMsg11;
        private System.Windows.Forms.Button btnMeasure;
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
            this.btnMsg00 = new System.Windows.Forms.Button();
            this.btnMsg01 = new System.Windows.Forms.Button();
            this.btnMsg10 = new System.Windows.Forms.Button();
            this.btnMsg11 = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.pnlCircuit = new System.Windows.Forms.Panel();
            this.probabilityBarsControl1 = new Sim1Test.Components.ProbabilityBarsControl();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(39, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Superdense Coding (2 bits)";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnMsg00
            // 
            this.btnMsg00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnMsg00.FlatAppearance.BorderSize = 0;
            this.btnMsg00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMsg00.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMsg00.ForeColor = System.Drawing.Color.White;
            this.btnMsg00.Location = new System.Drawing.Point(44, 39);
            this.btnMsg00.Name = "btnMsg00";
            this.btnMsg00.Size = new System.Drawing.Size(64, 26);
            this.btnMsg00.TabIndex = 1;
            this.btnMsg00.Text = "00";
            this.btnMsg00.UseVisualStyleBackColor = false;
            this.btnMsg00.Click += new System.EventHandler(this.btnMsg00_Click);
            // 
            // btnMsg01
            // 
            this.btnMsg01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnMsg01.FlatAppearance.BorderSize = 0;
            this.btnMsg01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMsg01.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMsg01.ForeColor = System.Drawing.Color.White;
            this.btnMsg01.Location = new System.Drawing.Point(117, 39);
            this.btnMsg01.Name = "btnMsg01";
            this.btnMsg01.Size = new System.Drawing.Size(64, 26);
            this.btnMsg01.TabIndex = 2;
            this.btnMsg01.Text = "01";
            this.btnMsg01.UseVisualStyleBackColor = false;
            this.btnMsg01.Click += new System.EventHandler(this.btnMsg01_Click);
            // 
            // btnMsg10
            // 
            this.btnMsg10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnMsg10.FlatAppearance.BorderSize = 0;
            this.btnMsg10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMsg10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMsg10.ForeColor = System.Drawing.Color.White;
            this.btnMsg10.Location = new System.Drawing.Point(187, 39);
            this.btnMsg10.Name = "btnMsg10";
            this.btnMsg10.Size = new System.Drawing.Size(64, 26);
            this.btnMsg10.TabIndex = 3;
            this.btnMsg10.Text = "10";
            this.btnMsg10.UseVisualStyleBackColor = false;
            this.btnMsg10.Click += new System.EventHandler(this.btnMsg10_Click);
            // 
            // btnMsg11
            // 
            this.btnMsg11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnMsg11.FlatAppearance.BorderSize = 0;
            this.btnMsg11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMsg11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMsg11.ForeColor = System.Drawing.Color.White;
            this.btnMsg11.Location = new System.Drawing.Point(257, 39);
            this.btnMsg11.Name = "btnMsg11";
            this.btnMsg11.Size = new System.Drawing.Size(64, 26);
            this.btnMsg11.TabIndex = 4;
            this.btnMsg11.Text = "11";
            this.btnMsg11.UseVisualStyleBackColor = false;
            this.btnMsg11.Click += new System.EventHandler(this.btnMsg11_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.btnMeasure.FlatAppearance.BorderSize = 0;
            this.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMeasure.ForeColor = System.Drawing.Color.White;
            this.btnMeasure.Location = new System.Drawing.Point(341, 39);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(103, 26);
            this.btnMeasure.TabIndex = 5;
            this.btnMeasure.Text = "Send";
            this.btnMeasure.UseVisualStyleBackColor = false;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // pnlCircuit
            // 
            this.pnlCircuit.BackColor = System.Drawing.Color.White;
            this.pnlCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCircuit.Location = new System.Drawing.Point(44, 78);
            this.pnlCircuit.Name = "pnlCircuit";
            this.pnlCircuit.Size = new System.Drawing.Size(633, 201);
            this.pnlCircuit.TabIndex = 6;
            this.pnlCircuit.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCircuit_Paint);
            // 
            // probabilityBarsControl1
            // 
            this.probabilityBarsControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.probabilityBarsControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.probabilityBarsControl1.Location = new System.Drawing.Point(44, 294);
            this.probabilityBarsControl1.Name = "probabilityBarsControl1";
            this.probabilityBarsControl1.Size = new System.Drawing.Size(633, 136);
            this.probabilityBarsControl1.TabIndex = 8;
            // 
            // SuperdenseCodingComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.probabilityBarsControl1);
            this.Controls.Add(this.pnlCircuit);
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.btnMsg11);
            this.Controls.Add(this.btnMsg10);
            this.Controls.Add(this.btnMsg01);
            this.Controls.Add(this.btnMsg00);
            this.Controls.Add(this.lblTitle);
            this.Name = "SuperdenseCodingComponent";
            this.Size = new System.Drawing.Size(715, 463);
            this.Load += new System.EventHandler(this.SuperdenseCodingComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ProbabilityBarsControl probabilityBarsControl1;
    }
}
