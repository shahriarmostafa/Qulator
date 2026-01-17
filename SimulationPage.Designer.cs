// SimulationPage.Designer.cs - Add this to your designer file (replace existing content)
using System;
using System.Windows.Forms;

namespace Sim1Test
{
    partial class SimulationPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.forecastButton = new System.Windows.Forms.Button();
            this.teleportationButton = new System.Windows.Forms.Button();
            this.superdenseButton = new System.Windows.Forms.Button();
            this.bellStateButton = new System.Windows.Forms.Button();
            this.singleQubitButton = new System.Windows.Forms.Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.applyProButton = new System.Windows.Forms.Button();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1080, 43);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Single Qubit Simulator";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.sidebarPanel.Controls.Add(this.applyProButton);
            this.sidebarPanel.Controls.Add(this.forecastButton);
            this.sidebarPanel.Controls.Add(this.teleportationButton);
            this.sidebarPanel.Controls.Add(this.superdenseButton);
            this.sidebarPanel.Controls.Add(this.bellStateButton);
            this.sidebarPanel.Controls.Add(this.singleQubitButton);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.ForeColor = System.Drawing.Color.White;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 43);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(214, 512);
            this.sidebarPanel.TabIndex = 0;
            this.sidebarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sidebarPanel_Paint);
            // 
            // forecastButton
            // 
            this.forecastButton.BackColor = System.Drawing.Color.Tomato;
            this.forecastButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forecastButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.forecastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forecastButton.Location = new System.Drawing.Point(0, 209);
            this.forecastButton.Name = "forecastButton";
            this.forecastButton.Size = new System.Drawing.Size(214, 56);
            this.forecastButton.TabIndex = 4;
            this.forecastButton.Text = "Weather Forecast (pro)";
            this.forecastButton.UseVisualStyleBackColor = false;
            this.forecastButton.Click += new System.EventHandler(this.forecastButton_Click);
            // 
            // teleportationButton
            // 
            this.teleportationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.teleportationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.teleportationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.teleportationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teleportationButton.Location = new System.Drawing.Point(0, 157);
            this.teleportationButton.Name = "teleportationButton";
            this.teleportationButton.Size = new System.Drawing.Size(214, 56);
            this.teleportationButton.TabIndex = 3;
            this.teleportationButton.Text = "Teleportation";
            this.teleportationButton.UseVisualStyleBackColor = false;
            this.teleportationButton.Click += new System.EventHandler(this.teleportationButton_Click);
            // 
            // superdenseButton
            // 
            this.superdenseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.superdenseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.superdenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.superdenseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superdenseButton.Location = new System.Drawing.Point(0, 105);
            this.superdenseButton.Name = "superdenseButton";
            this.superdenseButton.Size = new System.Drawing.Size(214, 56);
            this.superdenseButton.TabIndex = 2;
            this.superdenseButton.Text = "Superdense Coding";
            this.superdenseButton.UseVisualStyleBackColor = false;
            this.superdenseButton.Click += new System.EventHandler(this.superdenseButton_Click);
            // 
            // bellStateButton
            // 
            this.bellStateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.bellStateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bellStateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bellStateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bellStateButton.Location = new System.Drawing.Point(0, 53);
            this.bellStateButton.Name = "bellStateButton";
            this.bellStateButton.Size = new System.Drawing.Size(214, 56);
            this.bellStateButton.TabIndex = 1;
            this.bellStateButton.Text = "Bell State";
            this.bellStateButton.UseVisualStyleBackColor = false;
            this.bellStateButton.Click += new System.EventHandler(this.bellStateButton_Click);
            // 
            // singleQubitButton
            // 
            this.singleQubitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.singleQubitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.singleQubitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.singleQubitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleQubitButton.Location = new System.Drawing.Point(0, 0);
            this.singleQubitButton.Name = "singleQubitButton";
            this.singleQubitButton.Size = new System.Drawing.Size(214, 56);
            this.singleQubitButton.TabIndex = 0;
            this.singleQubitButton.Text = "Single Qubit Simulator";
            this.singleQubitButton.UseVisualStyleBackColor = false;
            this.singleQubitButton.Click += new System.EventHandler(this.singleQubitButton_Click);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.White;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(214, 43);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(866, 512);
            this.mainContentPanel.TabIndex = 1;
            // 
            // applyProButton
            // 
            this.applyProButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.applyProButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applyProButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.applyProButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyProButton.Location = new System.Drawing.Point(0, 262);
            this.applyProButton.Name = "applyProButton";
            this.applyProButton.Size = new System.Drawing.Size(214, 56);
            this.applyProButton.TabIndex = 5;
            this.applyProButton.Text = "$Apply For Pro Version";
            this.applyProButton.UseVisualStyleBackColor = false;
            // 
            // SimulationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 555);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.lblTitle);
            this.Name = "SimulationPage";
            this.Text = "Quantum Simulator - Main Page";
            this.Load += new System.EventHandler(this.SimulationPage_Load);
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Label lblTitle;
        private Panel sidebarPanel;
        private Panel mainContentPanel;
        private Button singleQubitButton;
        private Button forecastButton;
        private Button teleportationButton;
        private Button superdenseButton;
        private Button bellStateButton;
        private Button applyProButton;
    }
}
