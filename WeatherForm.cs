using System;
using System.Windows.Forms;
using Sim1Test.WeatherForcastingBackend;

namespace Sim1Test
{
    public partial class WeatherForm : Form
    {
        private readonly WeatherForecaster _forecaster = new WeatherForecaster();
        private readonly WeatherSimulationEngine _simulationEngine = new WeatherSimulationEngine();

        private WeatherInput _currentInput;
        private CompleteForecastAnalysis _currentAnalysis;
        private string email;

        public WeatherForm(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private bool TryReadInput(out WeatherInput input)
        {
            input = null;

            if (!double.TryParse(txtTemp.Text, out double temp))
            {
                MessageBox.Show("Invalid temperature.", "Input Error");
                return false;
            }
            if (!double.TryParse(txtHumidity.Text, out double humidity))
            {
                MessageBox.Show("Invalid humidity.", "Input Error");
                return false;
            }
            if (!double.TryParse(txtPressure.Text, out double pressure))
            {
                MessageBox.Show("Invalid pressure.", "Input Error");
                return false;
            }
            if (!double.TryParse(txtWind.Text, out double wind))
            {
                MessageBox.Show("Invalid wind speed.", "Input Error");
                return false;
            }

            input = new WeatherInput(temp, humidity, pressure, wind);
            _currentInput = input;
            return true;
        }

        private void ApplyInputToTextBoxes(WeatherInput input)
        {
            txtTemp.Text = input.TemperatureC.ToString("0.##");
            txtHumidity.Text = input.HumidityPercent.ToString("0.##");
            txtPressure.Text = input.PressureHpa.ToString("0.##");
            txtWind.Text = input.WindSpeedMs.ToString("0.##");
        }

        private void btnRunForecast_Click_1(object sender, EventArgs e)
        {
            if (!TryReadInput(out var input)) return;

            _currentAnalysis = CompleteForecastAnalysis.Analyze(input, _forecaster);

            UpdateHighLevelProbabilities(_currentAnalysis.HighLevelProbs);
            UpdateVariationProbabilities(_currentAnalysis.Variations);
            UpdateCurrentConditionBox(_currentAnalysis.CurrentConditions);

            lblFinalPredictionValue.Text = "Click 'Final Prediction' to see details";
        }

        private void UpdateCurrentConditionBox(CurrentConditionAnalysis analysis)
        {
            lblCurrentTempValue.Text = analysis.TemperatureDesc;
            lblCurrentHumidityValue.Text = analysis.HumidityDesc;
            lblCurrentPressureValue.Text = analysis.PressureDesc;
            lblCurrentWindValue.Text = analysis.WindDesc;
        }

        private void UpdateVariationProbabilities(VariationProbabilities variations)
        {
            lblVar1Label.Text = "Variation 1:";
            lblVar2Label.Text = "Variation 2:";
            lblVar3Label.Text = "Variation 3:";

            lblVar1Value.Text = variations.Variation1;
            lblVar2Value.Text = variations.Variation2;
            lblVar3Value.Text = variations.Variation3;
        }

        private void UpdateHighLevelProbabilities(HighLevelProbabilities probs)
        {
            lblRainProbValue.Text = $"{probs.RainProbability}%";
            lblCloudyProbValue.Text = $"{probs.CloudyProbability}%";
            lblClearProbValue.Text = $"{probs.ClearProbability}%";
            lblFogProbValue.Text = $"{probs.FogProbability}%";
        }

        private void btnSimHumidity_Click_1(object sender, EventArgs e)
        {
            if (!TryReadInput(out var input)) return;

            WeatherSimulationResult simResult = _simulationEngine.RunHumidityIncreaseSimulation(input, 10);

            input.HumidityPercent += 10;
            _currentInput = input;
            ApplyInputToTextBoxes(input);

            btnRunForecast_Click_1(sender, e);
        }

        private void btnSimPressure_Click_1(object sender, EventArgs e)
        {
            if (!TryReadInput(out var input)) return;

            WeatherSimulationResult simResult = _simulationEngine.RunPressureDecreaseSimulation(input, -3);

            input.PressureHpa -= 3;
            _currentInput = input;
            ApplyInputToTextBoxes(input);

            btnRunForecast_Click_1(sender, e);
        }

        private void btnFinalPrediction_Click_1(object sender, EventArgs e)
        {
            if (_currentInput == null || _currentAnalysis == null)
            {
                MessageBox.Show("First click 'Run Forecast' to calculate probabilities.");
                return;
            }

            lblFinalPredictionValue.Text = _currentAnalysis.detailedPrediction;
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimulationPage sm = new SimulationPage(email);
            this.Hide();
            sm.ShowDialog();
            this.Close();
        }
    }
}
