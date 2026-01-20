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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationPage));
            this.lblTitle = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.groverSearchButton = new System.Windows.Forms.Button();
            this.userEmail = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.applyProButton = new System.Windows.Forms.Button();
            this.forecastButton = new System.Windows.Forms.Button();
            this.teleportationButton = new System.Windows.Forms.Button();
            this.superdenseButton = new System.Windows.Forms.Button();
            this.bellStateButton = new System.Windows.Forms.Button();
            this.singleQubitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(1091, 60);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Hi, Name of the User";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.sidebarPanel.Controls.Add(this.groverSearchButton);
            this.sidebarPanel.Controls.Add(this.userEmail);
            this.sidebarPanel.Controls.Add(this.userNameLabel);
            this.sidebarPanel.Controls.Add(this.pictureBox1);
            this.sidebarPanel.Controls.Add(this.applyProButton);
            this.sidebarPanel.Controls.Add(this.forecastButton);
            this.sidebarPanel.Controls.Add(this.teleportationButton);
            this.sidebarPanel.Controls.Add(this.superdenseButton);
            this.sidebarPanel.Controls.Add(this.bellStateButton);
            this.sidebarPanel.Controls.Add(this.singleQubitButton);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.ForeColor = System.Drawing.Color.White;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 60);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(251, 585);
            this.sidebarPanel.TabIndex = 0;
            // 
            // groverSearchButton
            // 
            this.groverSearchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.groverSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groverSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groverSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groverSearchButton.Location = new System.Drawing.Point(0, 210);
            this.groverSearchButton.Name = "groverSearchButton";
            this.groverSearchButton.Size = new System.Drawing.Size(251, 56);
            this.groverSearchButton.TabIndex = 10;
            this.groverSearchButton.Text = "Grover Search (Pro)";
            this.groverSearchButton.UseVisualStyleBackColor = false;
            this.groverSearchButton.Click += new System.EventHandler(this.groverSearchButton_Click);
            // 
            // userEmail
            // 
            this.userEmail.AutoSize = true;
            this.userEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userEmail.ForeColor = System.Drawing.Color.SteelBlue;
            this.userEmail.Location = new System.Drawing.Point(72, 467);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(96, 16);
            this.userEmail.TabIndex = 9;
            this.userEmail.Text = "NameOfUser";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.userNameLabel.Location = new System.Drawing.Point(72, 451);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(96, 16);
            this.userNameLabel.TabIndex = 7;
            this.userNameLabel.Text = "NameOfUser";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // applyProButton
            // 
            this.applyProButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.applyProButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applyProButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.applyProButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyProButton.Location = new System.Drawing.Point(0, 316);
            this.applyProButton.Name = "applyProButton";
            this.applyProButton.Size = new System.Drawing.Size(251, 56);
            this.applyProButton.TabIndex = 5;
            this.applyProButton.Text = "$Apply For Pro Version";
            this.applyProButton.UseVisualStyleBackColor = false;
            this.applyProButton.Click += new System.EventHandler(this.applyProButton_Click);
            // 
            // forecastButton
            // 
            this.forecastButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.forecastButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forecastButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.forecastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forecastButton.Location = new System.Drawing.Point(0, 263);
            this.forecastButton.Name = "forecastButton";
            this.forecastButton.Size = new System.Drawing.Size(251, 56);
            this.forecastButton.TabIndex = 4;
            this.forecastButton.Text = "Weather Forecast (Pro)";
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
            this.teleportationButton.Size = new System.Drawing.Size(251, 56);
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
            this.superdenseButton.Size = new System.Drawing.Size(251, 56);
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
            this.bellStateButton.Size = new System.Drawing.Size(251, 56);
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
            this.singleQubitButton.Size = new System.Drawing.Size(251, 56);
            this.singleQubitButton.TabIndex = 0;
            this.singleQubitButton.Text = "Single Qubit Simulator";
            this.singleQubitButton.UseVisualStyleBackColor = false;
            this.singleQubitButton.Click += new System.EventHandler(this.singleQubitButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(979, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.AutoScroll = true;
            this.mainContentPanel.BackColor = System.Drawing.Color.White;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(251, 60);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(840, 585);
            this.mainContentPanel.TabIndex = 1;
            this.mainContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainContentPanel_Paint);
            // 
            // SimulationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 645);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SimulationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantum Simulator - Main Page";
            this.Load += new System.EventHandler(this.SimulationPage_Load);
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private PictureBox pictureBox1;
        private Label userNameLabel;
        private Button button1;
        private Label userEmail;
        private Button groverSearchButton;
    }
}
