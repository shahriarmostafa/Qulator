namespace Sim1Test.Components
{
    partial class GroverSearchComponent
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSuperposition;
        private System.Windows.Forms.Button btnSetTarget;
        private System.Windows.Forms.Button btnOracle;
        private System.Windows.Forms.Button btnDiffuser;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Panel pnlCircuit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTarget;

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
            this.btnSuperposition = new System.Windows.Forms.Button();
            this.btnSetTarget = new System.Windows.Forms.Button();
            this.btnOracle = new System.Windows.Forms.Button();
            this.btnDiffuser = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.pnlCircuit = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Size = new System.Drawing.Size(229, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Grover Search (4 qubits)";
            // 
            // btnSuperposition
            // 
            this.btnSuperposition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.btnSuperposition.FlatAppearance.BorderSize = 0;
            this.btnSuperposition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuperposition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuperposition.ForeColor = System.Drawing.Color.White;
            this.btnSuperposition.Location = new System.Drawing.Point(49, 38);
            this.btnSuperposition.Name = "btnSuperposition";
            this.btnSuperposition.Size = new System.Drawing.Size(118, 26);
            this.btnSuperposition.TabIndex = 1;
            this.btnSuperposition.Text = "Superposition";
            this.btnSuperposition.UseVisualStyleBackColor = false;
            this.btnSuperposition.Click += new System.EventHandler(this.btnSuperposition_Click);
            // 
            // btnSetTarget
            // 
            this.btnSetTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnSetTarget.FlatAppearance.BorderSize = 0;
            this.btnSetTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetTarget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSetTarget.ForeColor = System.Drawing.Color.White;
            this.btnSetTarget.Location = new System.Drawing.Point(271, 38);
            this.btnSetTarget.Name = "btnSetTarget";
            this.btnSetTarget.Size = new System.Drawing.Size(75, 26);
            this.btnSetTarget.TabIndex = 2;
            this.btnSetTarget.Text = "Set Target";
            this.btnSetTarget.UseVisualStyleBackColor = false;
            this.btnSetTarget.Click += new System.EventHandler(this.btnSetTarget_Click);
            // 
            // btnOracle
            // 
            this.btnOracle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnOracle.FlatAppearance.BorderSize = 0;
            this.btnOracle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOracle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOracle.ForeColor = System.Drawing.Color.White;
            this.btnOracle.Location = new System.Drawing.Point(352, 38);
            this.btnOracle.Name = "btnOracle";
            this.btnOracle.Size = new System.Drawing.Size(75, 26);
            this.btnOracle.TabIndex = 5;
            this.btnOracle.Text = "Mark Target";
            this.btnOracle.UseVisualStyleBackColor = false;
            this.btnOracle.Click += new System.EventHandler(this.btnOracle_Click);
            // 
            // btnDiffuser
            // 
            this.btnDiffuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.btnDiffuser.FlatAppearance.BorderSize = 0;
            this.btnDiffuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiffuser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDiffuser.ForeColor = System.Drawing.Color.White;
            this.btnDiffuser.Location = new System.Drawing.Point(433, 39);
            this.btnDiffuser.Name = "btnDiffuser";
            this.btnDiffuser.Size = new System.Drawing.Size(75, 26);
            this.btnDiffuser.TabIndex = 6;
            this.btnDiffuser.Text = "Diffuse";
            this.btnDiffuser.UseVisualStyleBackColor = false;
            this.btnDiffuser.Click += new System.EventHandler(this.btnDiffuser_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.btnMeasure.FlatAppearance.BorderSize = 0;
            this.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMeasure.ForeColor = System.Drawing.Color.White;
            this.btnMeasure.Location = new System.Drawing.Point(528, 39);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(75, 26);
            this.btnMeasure.TabIndex = 7;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = false;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // pnlCircuit
            // 
            this.pnlCircuit.BackColor = System.Drawing.Color.White;
            this.pnlCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCircuit.Location = new System.Drawing.Point(44, 78);
            this.pnlCircuit.Name = "pnlCircuit";
            this.pnlCircuit.Size = new System.Drawing.Size(633, 273);
            this.pnlCircuit.TabIndex = 8;
            this.pnlCircuit.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCircuit_Paint);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblStatus.Location = new System.Drawing.Point(40, 587);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(99, 19);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status: Ready";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(173, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Target:";
            // 
            // txtTarget
            // 
            this.txtTarget.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.txtTarget.Location = new System.Drawing.Point(225, 39);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(40, 22);
            this.txtTarget.TabIndex = 4;
            this.txtTarget.Text = "5";
            // 
            // probabilityBarsControl1
            // 
            this.probabilityBarsControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.probabilityBarsControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.probabilityBarsControl1.Location = new System.Drawing.Point(44, 366);
            this.probabilityBarsControl1.Name = "probabilityBarsControl1";
            this.probabilityBarsControl1.Size = new System.Drawing.Size(633, 218);
            this.probabilityBarsControl1.TabIndex = 11;
            // 
            // GroverSearchComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSetTarget);
            this.Controls.Add(this.probabilityBarsControl1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlCircuit);
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.btnDiffuser);
            this.Controls.Add(this.btnOracle);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSuperposition);
            this.Controls.Add(this.lblTitle);
            this.Name = "GroverSearchComponent";
            this.Size = new System.Drawing.Size(715, 619);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProbabilityBarsControl probabilityBarsControl1;
    }
}
