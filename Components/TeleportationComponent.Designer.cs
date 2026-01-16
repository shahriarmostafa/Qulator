namespace Sim1Test.Components
{
    partial class TeleportationComponent
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUnknown0;
        private System.Windows.Forms.Button btnUnknown1;
        private System.Windows.Forms.Button btnUnknownPlus;
        private System.Windows.Forms.Button btnUnknownMinus;
        private System.Windows.Forms.Button btnRunTeleport;
        private System.Windows.Forms.Label lblUnknownDisplay;

        private System.Windows.Forms.Panel pnlCircuit;
        private ProbabilityBarsControl probBars;

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
            this.btnUnknown0 = new System.Windows.Forms.Button();
            this.btnUnknown1 = new System.Windows.Forms.Button();
            this.btnUnknownPlus = new System.Windows.Forms.Button();
            this.btnUnknownMinus = new System.Windows.Forms.Button();
            this.btnRunTeleport = new System.Windows.Forms.Button();
            this.lblUnknownDisplay = new System.Windows.Forms.Label();
            this.pnlCircuit = new System.Windows.Forms.Panel();
            this.probBars = new Sim1Test.Components.ProbabilityBarsControl();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(13, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quantum Teleportation";
            // 
            // btnUnknown0
            // 
            this.btnUnknown0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnUnknown0.FlatAppearance.BorderSize = 0;
            this.btnUnknown0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnknown0.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnknown0.ForeColor = System.Drawing.Color.White;
            this.btnUnknown0.Location = new System.Drawing.Point(17, 39);
            this.btnUnknown0.Name = "btnUnknown0";
            this.btnUnknown0.Size = new System.Drawing.Size(47, 24);
            this.btnUnknown0.TabIndex = 1;
            this.btnUnknown0.Text = "|0⟩";
            this.btnUnknown0.UseVisualStyleBackColor = false;
            this.btnUnknown0.Click += new System.EventHandler(this.btnUnknown0_Click);
            // 
            // btnUnknown1
            // 
            this.btnUnknown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnUnknown1.FlatAppearance.BorderSize = 0;
            this.btnUnknown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnknown1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnknown1.ForeColor = System.Drawing.Color.White;
            this.btnUnknown1.Location = new System.Drawing.Point(69, 39);
            this.btnUnknown1.Name = "btnUnknown1";
            this.btnUnknown1.Size = new System.Drawing.Size(47, 24);
            this.btnUnknown1.TabIndex = 2;
            this.btnUnknown1.Text = "|1⟩";
            this.btnUnknown1.UseVisualStyleBackColor = false;
            this.btnUnknown1.Click += new System.EventHandler(this.btnUnknown1_Click);
            // 
            // btnUnknownPlus
            // 
            this.btnUnknownPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnUnknownPlus.FlatAppearance.BorderSize = 0;
            this.btnUnknownPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnknownPlus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnknownPlus.ForeColor = System.Drawing.Color.White;
            this.btnUnknownPlus.Location = new System.Drawing.Point(120, 39);
            this.btnUnknownPlus.Name = "btnUnknownPlus";
            this.btnUnknownPlus.Size = new System.Drawing.Size(47, 24);
            this.btnUnknownPlus.TabIndex = 3;
            this.btnUnknownPlus.Text = "|+⟩";
            this.btnUnknownPlus.UseVisualStyleBackColor = false;
            this.btnUnknownPlus.Click += new System.EventHandler(this.btnUnknownPlus_Click);
            // 
            // btnUnknownMinus
            // 
            this.btnUnknownMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnUnknownMinus.FlatAppearance.BorderSize = 0;
            this.btnUnknownMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnknownMinus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnknownMinus.ForeColor = System.Drawing.Color.White;
            this.btnUnknownMinus.Location = new System.Drawing.Point(171, 39);
            this.btnUnknownMinus.Name = "btnUnknownMinus";
            this.btnUnknownMinus.Size = new System.Drawing.Size(47, 24);
            this.btnUnknownMinus.TabIndex = 4;
            this.btnUnknownMinus.Text = "|−⟩";
            this.btnUnknownMinus.UseVisualStyleBackColor = false;
            this.btnUnknownMinus.Click += new System.EventHandler(this.btnUnknownMinus_Click);
            // 
            // btnRunTeleport
            // 
            this.btnRunTeleport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.btnRunTeleport.FlatAppearance.BorderSize = 0;
            this.btnRunTeleport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunTeleport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRunTeleport.ForeColor = System.Drawing.Color.White;
            this.btnRunTeleport.Location = new System.Drawing.Point(231, 39);
            this.btnRunTeleport.Name = "btnRunTeleport";
            this.btnRunTeleport.Size = new System.Drawing.Size(111, 24);
            this.btnRunTeleport.TabIndex = 5;
            this.btnRunTeleport.Text = "Run Teleportation";
            this.btnRunTeleport.UseVisualStyleBackColor = false;
            this.btnRunTeleport.Click += new System.EventHandler(this.btnRunTeleport_Click);
            // 
            // lblUnknownDisplay
            // 
            this.lblUnknownDisplay.AutoSize = true;
            this.lblUnknownDisplay.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Italic);
            this.lblUnknownDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.lblUnknownDisplay.Location = new System.Drawing.Point(360, 45);
            this.lblUnknownDisplay.Name = "lblUnknownDisplay";
            this.lblUnknownDisplay.Size = new System.Drawing.Size(87, 14);
            this.lblUnknownDisplay.TabIndex = 6;
            this.lblUnknownDisplay.Text = "Unknown: |0⟩";
            // 
            // pnlCircuit
            // 
            this.pnlCircuit.BackColor = System.Drawing.Color.White;
            this.pnlCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCircuit.Location = new System.Drawing.Point(17, 74);
            this.pnlCircuit.Name = "pnlCircuit";
            this.pnlCircuit.Size = new System.Drawing.Size(669, 240);
            this.pnlCircuit.TabIndex = 7;
            this.pnlCircuit.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCircuit_Paint);
            // 
            // probBars
            // 
            this.probBars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.probBars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.probBars.Location = new System.Drawing.Point(17, 330);
            this.probBars.Name = "probBars";
            this.probBars.Size = new System.Drawing.Size(669, 211);
            this.probBars.TabIndex = 8;
            // 
            // TeleportationComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.probBars);
            this.Controls.Add(this.pnlCircuit);
            this.Controls.Add(this.lblUnknownDisplay);
            this.Controls.Add(this.btnRunTeleport);
            this.Controls.Add(this.btnUnknownMinus);
            this.Controls.Add(this.btnUnknownPlus);
            this.Controls.Add(this.btnUnknown1);
            this.Controls.Add(this.btnUnknown0);
            this.Controls.Add(this.lblTitle);
            this.Name = "TeleportationComponent";
            this.Size = new System.Drawing.Size(708, 587);
            this.Load += new System.EventHandler(this.TeleportationComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
