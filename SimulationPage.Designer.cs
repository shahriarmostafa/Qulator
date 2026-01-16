namespace Sim1Test
{
    partial class SimulationPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.superdenseCodingComponent1 = new Sim1Test.Components.SuperdenseCodingComponent();
            this.SuspendLayout();
            // 
            // superdenseCodingComponent1
            // 
            this.superdenseCodingComponent1.BackColor = System.Drawing.Color.White;
            this.superdenseCodingComponent1.Location = new System.Drawing.Point(84, 53);
            this.superdenseCodingComponent1.Name = "superdenseCodingComponent1";
            this.superdenseCodingComponent1.OutputQ0 = "?";
            this.superdenseCodingComponent1.OutputQ1 = "?";
            this.superdenseCodingComponent1.ShowOutputs = false;
            this.superdenseCodingComponent1.Size = new System.Drawing.Size(752, 484);
            this.superdenseCodingComponent1.TabIndex = 0;
            // 
            // SimulationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(974, 586);
            this.Controls.Add(this.superdenseCodingComponent1);
            this.Name = "SimulationPage";
            this.Text = "SimulationPage";
            this.Load += new System.EventHandler(this.SimulationPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.SuperdenseCodingComponent superdenseCodingComponent1;
    }
}