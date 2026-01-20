namespace Sim1Test
{
    partial class WeatherForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.lblInputsTitle = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.txtHumidity = new System.Windows.Forms.TextBox();
            this.lblPressure = new System.Windows.Forms.Label();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.lblWind = new System.Windows.Forms.Label();
            this.txtWind = new System.Windows.Forms.TextBox();
            this.pnlProbabilities = new System.Windows.Forms.Panel();
            this.lblProbTitle = new System.Windows.Forms.Label();
            this.lblRainProbLabel = new System.Windows.Forms.Label();
            this.lblRainProbValue = new System.Windows.Forms.Label();
            this.lblCloudyProbLabel = new System.Windows.Forms.Label();
            this.lblCloudyProbValue = new System.Windows.Forms.Label();
            this.lblClearProbLabel = new System.Windows.Forms.Label();
            this.lblClearProbValue = new System.Windows.Forms.Label();
            this.lblFogProbLabel = new System.Windows.Forms.Label();
            this.lblFogProbValue = new System.Windows.Forms.Label();
            this.pnlVariations = new System.Windows.Forms.Panel();
            this.lblVarTitle = new System.Windows.Forms.Label();
            this.lblVar1Label = new System.Windows.Forms.Label();
            this.lblVar1Value = new System.Windows.Forms.Label();
            this.lblVar2Label = new System.Windows.Forms.Label();
            this.lblVar2Value = new System.Windows.Forms.Label();
            this.lblVar3Label = new System.Windows.Forms.Label();
            this.lblVar3Value = new System.Windows.Forms.Label();
            this.pnlCurrent = new System.Windows.Forms.Panel();
            this.lblCurrentTitle = new System.Windows.Forms.Label();
            this.lblCurrentTempLabel = new System.Windows.Forms.Label();
            this.lblCurrentTempValue = new System.Windows.Forms.Label();
            this.lblCurrentHumidityLabel = new System.Windows.Forms.Label();
            this.lblCurrentHumidityValue = new System.Windows.Forms.Label();
            this.lblCurrentPressureLabel = new System.Windows.Forms.Label();
            this.lblCurrentPressureValue = new System.Windows.Forms.Label();
            this.lblCurrentWindLabel = new System.Windows.Forms.Label();
            this.lblCurrentWindValue = new System.Windows.Forms.Label();
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.lblSimTitle = new System.Windows.Forms.Label();
            this.btnSimHumidity = new System.Windows.Forms.Button();
            this.btnSimPressure = new System.Windows.Forms.Button();
            this.lblSimHint = new System.Windows.Forms.Label();
            this.btnRunForecast = new System.Windows.Forms.Button();
            this.btnFinalPrediction = new System.Windows.Forms.Button();
            this.lblFinalPredictionLabel = new System.Windows.Forms.Label();
            this.lblFinalPredictionValue = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlInputs.SuspendLayout();
            this.pnlProbabilities.SuspendLayout();
            this.pnlVariations.SuspendLayout();
            this.pnlCurrent.SuspendLayout();
            this.pnlSimulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(220)))));
            this.pnlHeader.Controls.Add(this.button1);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(915, 72);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(772, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(433, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Weather Forecast – Simulation Mode";
            // 
            // pnlInputs
            // 
            this.pnlInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.pnlInputs.Controls.Add(this.lblInputsTitle);
            this.pnlInputs.Controls.Add(this.lblTemp);
            this.pnlInputs.Controls.Add(this.txtTemp);
            this.pnlInputs.Controls.Add(this.lblHumidity);
            this.pnlInputs.Controls.Add(this.txtHumidity);
            this.pnlInputs.Controls.Add(this.lblPressure);
            this.pnlInputs.Controls.Add(this.txtPressure);
            this.pnlInputs.Controls.Add(this.lblWind);
            this.pnlInputs.Controls.Add(this.txtWind);
            this.pnlInputs.Location = new System.Drawing.Point(20, 90);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(280, 230);
            this.pnlInputs.TabIndex = 1;
            // 
            // lblInputsTitle
            // 
            this.lblInputsTitle.AutoSize = true;
            this.lblInputsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInputsTitle.ForeColor = System.Drawing.Color.White;
            this.lblInputsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblInputsTitle.Name = "lblInputsTitle";
            this.lblInputsTitle.Size = new System.Drawing.Size(54, 20);
            this.lblInputsTitle.TabIndex = 0;
            this.lblInputsTitle.Text = "Inputs";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTemp.Location = new System.Drawing.Point(16, 45);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(115, 19);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "Temperature (°C):";
            // 
            // txtTemp
            // 
            this.txtTemp.Location = new System.Drawing.Point(160, 42);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(90, 25);
            this.txtTemp.TabIndex = 2;
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHumidity.Location = new System.Drawing.Point(16, 80);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(91, 19);
            this.lblHumidity.TabIndex = 3;
            this.lblHumidity.Text = "Humidity (%):";
            // 
            // txtHumidity
            // 
            this.txtHumidity.Location = new System.Drawing.Point(160, 77);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.Size = new System.Drawing.Size(90, 25);
            this.txtHumidity.TabIndex = 4;
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPressure.Location = new System.Drawing.Point(16, 115);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(99, 19);
            this.lblPressure.TabIndex = 5;
            this.lblPressure.Text = "Pressure (hPa):";
            // 
            // txtPressure
            // 
            this.txtPressure.Location = new System.Drawing.Point(160, 112);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.Size = new System.Drawing.Size(90, 25);
            this.txtPressure.TabIndex = 6;
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblWind.Location = new System.Drawing.Point(16, 150);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(119, 19);
            this.lblWind.TabIndex = 7;
            this.lblWind.Text = "Wind speed (m/s):";
            // 
            // txtWind
            // 
            this.txtWind.Location = new System.Drawing.Point(160, 147);
            this.txtWind.Name = "txtWind";
            this.txtWind.Size = new System.Drawing.Size(90, 25);
            this.txtWind.TabIndex = 8;
            // 
            // pnlProbabilities
            // 
            this.pnlProbabilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(95)))), ((int)(((byte)(75)))));
            this.pnlProbabilities.Controls.Add(this.lblProbTitle);
            this.pnlProbabilities.Controls.Add(this.lblRainProbLabel);
            this.pnlProbabilities.Controls.Add(this.lblRainProbValue);
            this.pnlProbabilities.Controls.Add(this.lblCloudyProbLabel);
            this.pnlProbabilities.Controls.Add(this.lblCloudyProbValue);
            this.pnlProbabilities.Controls.Add(this.lblClearProbLabel);
            this.pnlProbabilities.Controls.Add(this.lblClearProbValue);
            this.pnlProbabilities.Controls.Add(this.lblFogProbLabel);
            this.pnlProbabilities.Controls.Add(this.lblFogProbValue);
            this.pnlProbabilities.Location = new System.Drawing.Point(320, 90);
            this.pnlProbabilities.Name = "pnlProbabilities";
            this.pnlProbabilities.Size = new System.Drawing.Size(251, 230);
            this.pnlProbabilities.TabIndex = 2;
            // 
            // lblProbTitle
            // 
            this.lblProbTitle.AutoSize = true;
            this.lblProbTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProbTitle.ForeColor = System.Drawing.Color.White;
            this.lblProbTitle.Location = new System.Drawing.Point(10, 10);
            this.lblProbTitle.Name = "lblProbTitle";
            this.lblProbTitle.Size = new System.Drawing.Size(168, 20);
            this.lblProbTitle.TabIndex = 0;
            this.lblProbTitle.Text = "Condition Probabilities";
            // 
            // lblRainProbLabel
            // 
            this.lblRainProbLabel.AutoSize = true;
            this.lblRainProbLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRainProbLabel.Location = new System.Drawing.Point(16, 50);
            this.lblRainProbLabel.Name = "lblRainProbLabel";
            this.lblRainProbLabel.Size = new System.Drawing.Size(38, 19);
            this.lblRainProbLabel.TabIndex = 1;
            this.lblRainProbLabel.Text = "Rain:";
            // 
            // lblRainProbValue
            // 
            this.lblRainProbValue.AutoSize = true;
            this.lblRainProbValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRainProbValue.ForeColor = System.Drawing.Color.White;
            this.lblRainProbValue.Location = new System.Drawing.Point(120, 48);
            this.lblRainProbValue.Name = "lblRainProbValue";
            this.lblRainProbValue.Size = new System.Drawing.Size(34, 20);
            this.lblRainProbValue.TabIndex = 2;
            this.lblRainProbValue.Text = "--%";
            // 
            // lblCloudyProbLabel
            // 
            this.lblCloudyProbLabel.AutoSize = true;
            this.lblCloudyProbLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCloudyProbLabel.Location = new System.Drawing.Point(16, 90);
            this.lblCloudyProbLabel.Name = "lblCloudyProbLabel";
            this.lblCloudyProbLabel.Size = new System.Drawing.Size(55, 19);
            this.lblCloudyProbLabel.TabIndex = 3;
            this.lblCloudyProbLabel.Text = "Cloudy:";
            // 
            // lblCloudyProbValue
            // 
            this.lblCloudyProbValue.AutoSize = true;
            this.lblCloudyProbValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCloudyProbValue.ForeColor = System.Drawing.Color.White;
            this.lblCloudyProbValue.Location = new System.Drawing.Point(120, 88);
            this.lblCloudyProbValue.Name = "lblCloudyProbValue";
            this.lblCloudyProbValue.Size = new System.Drawing.Size(34, 20);
            this.lblCloudyProbValue.TabIndex = 4;
            this.lblCloudyProbValue.Text = "--%";
            // 
            // lblClearProbLabel
            // 
            this.lblClearProbLabel.AutoSize = true;
            this.lblClearProbLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblClearProbLabel.Location = new System.Drawing.Point(16, 130);
            this.lblClearProbLabel.Name = "lblClearProbLabel";
            this.lblClearProbLabel.Size = new System.Drawing.Size(43, 19);
            this.lblClearProbLabel.TabIndex = 5;
            this.lblClearProbLabel.Text = "Clear:";
            // 
            // lblClearProbValue
            // 
            this.lblClearProbValue.AutoSize = true;
            this.lblClearProbValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblClearProbValue.ForeColor = System.Drawing.Color.White;
            this.lblClearProbValue.Location = new System.Drawing.Point(120, 128);
            this.lblClearProbValue.Name = "lblClearProbValue";
            this.lblClearProbValue.Size = new System.Drawing.Size(34, 20);
            this.lblClearProbValue.TabIndex = 6;
            this.lblClearProbValue.Text = "--%";
            // 
            // lblFogProbLabel
            // 
            this.lblFogProbLabel.AutoSize = true;
            this.lblFogProbLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFogProbLabel.Location = new System.Drawing.Point(16, 170);
            this.lblFogProbLabel.Name = "lblFogProbLabel";
            this.lblFogProbLabel.Size = new System.Drawing.Size(35, 19);
            this.lblFogProbLabel.TabIndex = 7;
            this.lblFogProbLabel.Text = "Fog:";
            // 
            // lblFogProbValue
            // 
            this.lblFogProbValue.AutoSize = true;
            this.lblFogProbValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFogProbValue.ForeColor = System.Drawing.Color.White;
            this.lblFogProbValue.Location = new System.Drawing.Point(120, 168);
            this.lblFogProbValue.Name = "lblFogProbValue";
            this.lblFogProbValue.Size = new System.Drawing.Size(34, 20);
            this.lblFogProbValue.TabIndex = 8;
            this.lblFogProbValue.Text = "--%";
            // 
            // pnlVariations
            // 
            this.pnlVariations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(55)))), ((int)(((byte)(110)))));
            this.pnlVariations.Controls.Add(this.lblVarTitle);
            this.pnlVariations.Controls.Add(this.lblVar1Label);
            this.pnlVariations.Controls.Add(this.lblVar1Value);
            this.pnlVariations.Controls.Add(this.lblVar2Label);
            this.pnlVariations.Controls.Add(this.lblVar2Value);
            this.pnlVariations.Controls.Add(this.lblVar3Label);
            this.pnlVariations.Controls.Add(this.lblVar3Value);
            this.pnlVariations.Location = new System.Drawing.Point(597, 90);
            this.pnlVariations.Name = "pnlVariations";
            this.pnlVariations.Size = new System.Drawing.Size(294, 230);
            this.pnlVariations.TabIndex = 3;
            // 
            // lblVarTitle
            // 
            this.lblVarTitle.AutoSize = true;
            this.lblVarTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVarTitle.ForeColor = System.Drawing.Color.White;
            this.lblVarTitle.Location = new System.Drawing.Point(10, 10);
            this.lblVarTitle.Name = "lblVarTitle";
            this.lblVarTitle.Size = new System.Drawing.Size(87, 20);
            this.lblVarTitle.TabIndex = 0;
            this.lblVarTitle.Text = "Predictions";
            // 
            // lblVar1Label
            // 
            this.lblVar1Label.AutoSize = true;
            this.lblVar1Label.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblVar1Label.Location = new System.Drawing.Point(16, 50);
            this.lblVar1Label.Name = "lblVar1Label";
            this.lblVar1Label.Size = new System.Drawing.Size(78, 19);
            this.lblVar1Label.TabIndex = 1;
            this.lblVar1Label.Text = "Variation 1:";
            // 
            // lblVar1Value
            // 
            this.lblVar1Value.AutoSize = true;
            this.lblVar1Value.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVar1Value.ForeColor = System.Drawing.Color.White;
            this.lblVar1Value.Location = new System.Drawing.Point(120, 50);
            this.lblVar1Value.Name = "lblVar1Value";
            this.lblVar1Value.Size = new System.Drawing.Size(21, 19);
            this.lblVar1Value.TabIndex = 2;
            this.lblVar1Value.Text = "--";
            // 
            // lblVar2Label
            // 
            this.lblVar2Label.AutoSize = true;
            this.lblVar2Label.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblVar2Label.Location = new System.Drawing.Point(16, 90);
            this.lblVar2Label.Name = "lblVar2Label";
            this.lblVar2Label.Size = new System.Drawing.Size(78, 19);
            this.lblVar2Label.TabIndex = 3;
            this.lblVar2Label.Text = "Variation 2:";
            // 
            // lblVar2Value
            // 
            this.lblVar2Value.AutoSize = true;
            this.lblVar2Value.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVar2Value.ForeColor = System.Drawing.Color.White;
            this.lblVar2Value.Location = new System.Drawing.Point(120, 90);
            this.lblVar2Value.Name = "lblVar2Value";
            this.lblVar2Value.Size = new System.Drawing.Size(21, 19);
            this.lblVar2Value.TabIndex = 4;
            this.lblVar2Value.Text = "--";
            // 
            // lblVar3Label
            // 
            this.lblVar3Label.AutoSize = true;
            this.lblVar3Label.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblVar3Label.Location = new System.Drawing.Point(16, 130);
            this.lblVar3Label.Name = "lblVar3Label";
            this.lblVar3Label.Size = new System.Drawing.Size(78, 19);
            this.lblVar3Label.TabIndex = 5;
            this.lblVar3Label.Text = "Variation 3:";
            // 
            // lblVar3Value
            // 
            this.lblVar3Value.AutoSize = true;
            this.lblVar3Value.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVar3Value.ForeColor = System.Drawing.Color.White;
            this.lblVar3Value.Location = new System.Drawing.Point(120, 130);
            this.lblVar3Value.Name = "lblVar3Value";
            this.lblVar3Value.Size = new System.Drawing.Size(21, 19);
            this.lblVar3Value.TabIndex = 6;
            this.lblVar3Value.Text = "--";
            // 
            // pnlCurrent
            // 
            this.pnlCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(105)))));
            this.pnlCurrent.Controls.Add(this.lblCurrentTitle);
            this.pnlCurrent.Controls.Add(this.lblCurrentTempLabel);
            this.pnlCurrent.Controls.Add(this.lblCurrentTempValue);
            this.pnlCurrent.Controls.Add(this.lblCurrentHumidityLabel);
            this.pnlCurrent.Controls.Add(this.lblCurrentHumidityValue);
            this.pnlCurrent.Controls.Add(this.lblCurrentPressureLabel);
            this.pnlCurrent.Controls.Add(this.lblCurrentPressureValue);
            this.pnlCurrent.Controls.Add(this.lblCurrentWindLabel);
            this.pnlCurrent.Controls.Add(this.lblCurrentWindValue);
            this.pnlCurrent.Location = new System.Drawing.Point(20, 340);
            this.pnlCurrent.Name = "pnlCurrent";
            this.pnlCurrent.Size = new System.Drawing.Size(359, 180);
            this.pnlCurrent.TabIndex = 4;
            // 
            // lblCurrentTitle
            // 
            this.lblCurrentTitle.AutoSize = true;
            this.lblCurrentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTitle.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentTitle.Name = "lblCurrentTitle";
            this.lblCurrentTitle.Size = new System.Drawing.Size(206, 20);
            this.lblCurrentTitle.TabIndex = 0;
            this.lblCurrentTitle.Text = "Current Condition Summary";
            // 
            // lblCurrentTempLabel
            // 
            this.lblCurrentTempLabel.AutoSize = true;
            this.lblCurrentTempLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentTempLabel.Location = new System.Drawing.Point(16, 50);
            this.lblCurrentTempLabel.Name = "lblCurrentTempLabel";
            this.lblCurrentTempLabel.Size = new System.Drawing.Size(89, 19);
            this.lblCurrentTempLabel.TabIndex = 1;
            this.lblCurrentTempLabel.Text = "Temperature:";
            // 
            // lblCurrentTempValue
            // 
            this.lblCurrentTempValue.AutoSize = true;
            this.lblCurrentTempValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTempValue.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTempValue.Location = new System.Drawing.Point(130, 50);
            this.lblCurrentTempValue.Name = "lblCurrentTempValue";
            this.lblCurrentTempValue.Size = new System.Drawing.Size(21, 19);
            this.lblCurrentTempValue.TabIndex = 2;
            this.lblCurrentTempValue.Text = "--";
            // 
            // lblCurrentHumidityLabel
            // 
            this.lblCurrentHumidityLabel.AutoSize = true;
            this.lblCurrentHumidityLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentHumidityLabel.Location = new System.Drawing.Point(16, 80);
            this.lblCurrentHumidityLabel.Name = "lblCurrentHumidityLabel";
            this.lblCurrentHumidityLabel.Size = new System.Drawing.Size(68, 19);
            this.lblCurrentHumidityLabel.TabIndex = 3;
            this.lblCurrentHumidityLabel.Text = "Humidity:";
            // 
            // lblCurrentHumidityValue
            // 
            this.lblCurrentHumidityValue.AutoSize = true;
            this.lblCurrentHumidityValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentHumidityValue.ForeColor = System.Drawing.Color.White;
            this.lblCurrentHumidityValue.Location = new System.Drawing.Point(130, 80);
            this.lblCurrentHumidityValue.Name = "lblCurrentHumidityValue";
            this.lblCurrentHumidityValue.Size = new System.Drawing.Size(21, 19);
            this.lblCurrentHumidityValue.TabIndex = 4;
            this.lblCurrentHumidityValue.Text = "--";
            // 
            // lblCurrentPressureLabel
            // 
            this.lblCurrentPressureLabel.AutoSize = true;
            this.lblCurrentPressureLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentPressureLabel.Location = new System.Drawing.Point(16, 110);
            this.lblCurrentPressureLabel.Name = "lblCurrentPressureLabel";
            this.lblCurrentPressureLabel.Size = new System.Drawing.Size(64, 19);
            this.lblCurrentPressureLabel.TabIndex = 5;
            this.lblCurrentPressureLabel.Text = "Pressure:";
            // 
            // lblCurrentPressureValue
            // 
            this.lblCurrentPressureValue.AutoSize = true;
            this.lblCurrentPressureValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPressureValue.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPressureValue.Location = new System.Drawing.Point(130, 110);
            this.lblCurrentPressureValue.Name = "lblCurrentPressureValue";
            this.lblCurrentPressureValue.Size = new System.Drawing.Size(21, 19);
            this.lblCurrentPressureValue.TabIndex = 6;
            this.lblCurrentPressureValue.Text = "--";
            // 
            // lblCurrentWindLabel
            // 
            this.lblCurrentWindLabel.AutoSize = true;
            this.lblCurrentWindLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentWindLabel.Location = new System.Drawing.Point(16, 140);
            this.lblCurrentWindLabel.Name = "lblCurrentWindLabel";
            this.lblCurrentWindLabel.Size = new System.Drawing.Size(44, 19);
            this.lblCurrentWindLabel.TabIndex = 7;
            this.lblCurrentWindLabel.Text = "Wind:";
            // 
            // lblCurrentWindValue
            // 
            this.lblCurrentWindValue.AutoSize = true;
            this.lblCurrentWindValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentWindValue.ForeColor = System.Drawing.Color.White;
            this.lblCurrentWindValue.Location = new System.Drawing.Point(130, 140);
            this.lblCurrentWindValue.Name = "lblCurrentWindValue";
            this.lblCurrentWindValue.Size = new System.Drawing.Size(21, 19);
            this.lblCurrentWindValue.TabIndex = 8;
            this.lblCurrentWindValue.Text = "--";
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.pnlSimulation.Controls.Add(this.lblSimTitle);
            this.pnlSimulation.Controls.Add(this.btnSimHumidity);
            this.pnlSimulation.Controls.Add(this.btnSimPressure);
            this.pnlSimulation.Controls.Add(this.lblSimHint);
            this.pnlSimulation.Location = new System.Drawing.Point(408, 340);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(483, 180);
            this.pnlSimulation.TabIndex = 5;
            // 
            // lblSimTitle
            // 
            this.lblSimTitle.AutoSize = true;
            this.lblSimTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSimTitle.ForeColor = System.Drawing.Color.White;
            this.lblSimTitle.Location = new System.Drawing.Point(10, 10);
            this.lblSimTitle.Name = "lblSimTitle";
            this.lblSimTitle.Size = new System.Drawing.Size(127, 20);
            this.lblSimTitle.TabIndex = 0;
            this.lblSimTitle.Text = "Change variables";
            // 
            // btnSimHumidity
            // 
            this.btnSimHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.btnSimHumidity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimHumidity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimHumidity.ForeColor = System.Drawing.Color.White;
            this.btnSimHumidity.Location = new System.Drawing.Point(20, 50);
            this.btnSimHumidity.Name = "btnSimHumidity";
            this.btnSimHumidity.Size = new System.Drawing.Size(180, 36);
            this.btnSimHumidity.TabIndex = 1;
            this.btnSimHumidity.Text = "+10% Humidity";
            this.btnSimHumidity.UseVisualStyleBackColor = false;
            this.btnSimHumidity.Click += new System.EventHandler(this.btnSimHumidity_Click_1);
            // 
            // btnSimPressure
            // 
            this.btnSimPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(140)))), ((int)(((byte)(70)))));
            this.btnSimPressure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimPressure.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimPressure.ForeColor = System.Drawing.Color.White;
            this.btnSimPressure.Location = new System.Drawing.Point(220, 50);
            this.btnSimPressure.Name = "btnSimPressure";
            this.btnSimPressure.Size = new System.Drawing.Size(180, 36);
            this.btnSimPressure.TabIndex = 2;
            this.btnSimPressure.Text = "-3 hPa Pressure";
            this.btnSimPressure.UseVisualStyleBackColor = false;
            this.btnSimPressure.Click += new System.EventHandler(this.btnSimPressure_Click_1);
            // 
            // lblSimHint
            // 
            this.lblSimHint.AutoSize = true;
            this.lblSimHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSimHint.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSimHint.Location = new System.Drawing.Point(20, 100);
            this.lblSimHint.Name = "lblSimHint";
            this.lblSimHint.Size = new System.Drawing.Size(330, 15);
            this.lblSimHint.TabIndex = 3;
            this.lblSimHint.Text = "Change humidity or pressure to see how probabilities change";
            // 
            // btnRunForecast
            // 
            this.btnRunForecast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnRunForecast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunForecast.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRunForecast.ForeColor = System.Drawing.Color.White;
            this.btnRunForecast.Location = new System.Drawing.Point(20, 538);
            this.btnRunForecast.Name = "btnRunForecast";
            this.btnRunForecast.Size = new System.Drawing.Size(200, 42);
            this.btnRunForecast.TabIndex = 6;
            this.btnRunForecast.Text = "Run Forecast";
            this.btnRunForecast.UseVisualStyleBackColor = false;
            this.btnRunForecast.Click += new System.EventHandler(this.btnRunForecast_Click_1);
            // 
            // btnFinalPrediction
            // 
            this.btnFinalPrediction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnFinalPrediction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalPrediction.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFinalPrediction.ForeColor = System.Drawing.Color.White;
            this.btnFinalPrediction.Location = new System.Drawing.Point(238, 538);
            this.btnFinalPrediction.Name = "btnFinalPrediction";
            this.btnFinalPrediction.Size = new System.Drawing.Size(200, 42);
            this.btnFinalPrediction.TabIndex = 7;
            this.btnFinalPrediction.Text = "Predict";
            this.btnFinalPrediction.UseVisualStyleBackColor = false;
            this.btnFinalPrediction.Click += new System.EventHandler(this.btnFinalPrediction_Click_1);
            // 
            // lblFinalPredictionLabel
            // 
            this.lblFinalPredictionLabel.AutoSize = true;
            this.lblFinalPredictionLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFinalPredictionLabel.ForeColor = System.Drawing.Color.White;
            this.lblFinalPredictionLabel.Location = new System.Drawing.Point(454, 549);
            this.lblFinalPredictionLabel.Name = "lblFinalPredictionLabel";
            this.lblFinalPredictionLabel.Size = new System.Drawing.Size(154, 20);
            this.lblFinalPredictionLabel.TabIndex = 8;
            this.lblFinalPredictionLabel.Text = "Quantum Prediction:";
            // 
            // lblFinalPredictionValue
            // 
            this.lblFinalPredictionValue.AutoSize = true;
            this.lblFinalPredictionValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFinalPredictionValue.ForeColor = System.Drawing.Color.LightGreen;
            this.lblFinalPredictionValue.Location = new System.Drawing.Point(614, 549);
            this.lblFinalPredictionValue.Name = "lblFinalPredictionValue";
            this.lblFinalPredictionValue.Size = new System.Drawing.Size(21, 20);
            this.lblFinalPredictionValue.TabIndex = 9;
            this.lblFinalPredictionValue.Text = "--";
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(915, 607);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.pnlProbabilities);
            this.Controls.Add(this.pnlVariations);
            this.Controls.Add(this.pnlCurrent);
            this.Controls.Add(this.pnlSimulation);
            this.Controls.Add(this.btnRunForecast);
            this.Controls.Add(this.btnFinalPrediction);
            this.Controls.Add(this.lblFinalPredictionLabel);
            this.Controls.Add(this.lblFinalPredictionValue);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MaximizeBox = false;
            this.Name = "WeatherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weather Forecast Simulator";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            this.pnlProbabilities.ResumeLayout(false);
            this.pnlProbabilities.PerformLayout();
            this.pnlVariations.ResumeLayout(false);
            this.pnlVariations.PerformLayout();
            this.pnlCurrent.ResumeLayout(false);
            this.pnlCurrent.PerformLayout();
            this.pnlSimulation.ResumeLayout(false);
            this.pnlSimulation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.TextBox txtWind;

        private System.Windows.Forms.Panel pnlProbabilities;
        private System.Windows.Forms.Label lblRainProbLabel;
        private System.Windows.Forms.Label lblRainProbValue;
        private System.Windows.Forms.Label lblCloudyProbLabel;
        private System.Windows.Forms.Label lblCloudyProbValue;
        private System.Windows.Forms.Label lblClearProbLabel;
        private System.Windows.Forms.Label lblClearProbValue;
        private System.Windows.Forms.Label lblFogProbLabel;
        private System.Windows.Forms.Label lblFogProbValue;


        private System.Windows.Forms.Panel pnlVariations;
        private System.Windows.Forms.Label lblVar1Label;
        private System.Windows.Forms.Label lblVar1Value;
        private System.Windows.Forms.Label lblVar2Label;
        private System.Windows.Forms.Label lblVar2Value;
        private System.Windows.Forms.Label lblVar3Label;
        private System.Windows.Forms.Label lblVar3Value;

        private System.Windows.Forms.Panel pnlCurrent;
        private System.Windows.Forms.Label lblCurrentTempLabel;
        private System.Windows.Forms.Label lblCurrentTempValue;
        private System.Windows.Forms.Label lblCurrentHumidityLabel;
        private System.Windows.Forms.Label lblCurrentHumidityValue;
        private System.Windows.Forms.Label lblCurrentPressureLabel;
        private System.Windows.Forms.Label lblCurrentPressureValue;
        private System.Windows.Forms.Label lblCurrentWindLabel;
        private System.Windows.Forms.Label lblCurrentWindValue;

        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.Button btnSimHumidity;
        private System.Windows.Forms.Button btnSimPressure;
        private System.Windows.Forms.Label lblSimHint;

        private System.Windows.Forms.Button btnRunForecast;
        private System.Windows.Forms.Button btnFinalPrediction;
        private System.Windows.Forms.Label lblFinalPredictionLabel;
        private System.Windows.Forms.Label lblFinalPredictionValue;
        private System.Windows.Forms.Label lblInputsTitle;
        private System.Windows.Forms.Label lblProbTitle;
        private System.Windows.Forms.Label lblVarTitle;
        private System.Windows.Forms.Label lblCurrentTitle;
        private System.Windows.Forms.Label lblSimTitle;
        private System.Windows.Forms.Button button1;
    }
}
