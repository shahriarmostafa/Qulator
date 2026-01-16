using System;
using System.Windows.Forms;
using Sim1Test.WeatherForcastingBackend;

namespace Sim1Test
{
    public partial class WeatherForm : Form
    {
        private readonly WeatherForecaster _forecaster = new WeatherForecaster();

        private WeatherInput _currentInput;
        private WeatherResult _currentForecast;

        public WeatherForm()
        {
            InitializeComponent();

            btnRunForecast.Click += btnRunForecast_Click;
            btnSimHumidity.Click += btnSimHumidity_Click;
            btnSimPressure.Click += btnSimPressure_Click;
            btnFinalPrediction.Click += btnFinalPrediction_Click;
        }

        // ------------ Input handling ------------

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

        // ------------ Stage 1: Run forecast & update all boxes ------------

        private void btnRunForecast_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out var input)) return;

            var result = _forecaster.Forecast(input);
            result.ConfidenceLabel = WeatherAnalysisHelpers
                .GetConfidenceLabel(result.ProbabilityPercent);

            _currentForecast = result;

            UpdateHighLevelProbabilities(result);
            UpdateVariationProbabilities(input, result);
            UpdateCurrentConditionBox(input, result);


            lblFinalPredictionValue.Text = "Click 'Final Prediction' to see details";
        }


        private void UpdateCurrentConditionBox(WeatherInput input, WeatherResult baseResult)
        {
            double T = input.TemperatureC;
            double H = input.HumidityPercent;
            double P = input.PressureHpa;
            double W = input.WindSpeedMs;

            // Binary-ish buckets: Low / High for each dimension
            string tempBinary = T < 25 ? "Low" : "High";
            string humBinary = H < 60 ? "Low" : "High";
            string presBinary = P < 1010 ? "Low" : "High";
            string windBinary = W < 5 ? "Low" : "High";

            // Human-friendly text mapping similar to your table
            string interpretation;

            if (tempBinary == "Low" && humBinary == "Low" && presBinary == "Low" && windBinary == "Low")
                interpretation = "Cool, dry, calm";
            else if (tempBinary == "Low" && humBinary == "Low" && presBinary == "Low" && windBinary == "High")
                interpretation = "Cool, dry, windy";
            else if (tempBinary == "Low" && humBinary == "Low" && presBinary == "High" && windBinary == "Low")
                interpretation = "Cool, dry, stable";
            else if (tempBinary == "Low" && humBinary == "Low" && presBinary == "High" && windBinary == "High")
                interpretation = "Cool, dry, windy";
            else if (tempBinary == "Low" && humBinary == "High" && presBinary == "Low" && windBinary == "Low")
                interpretation = "Cool, humid";
            else if (tempBinary == "Low" && humBinary == "High" && presBinary == "Low" && windBinary == "High")
                interpretation = "Cool, humid, windy";
            else if (tempBinary == "Low" && humBinary == "High" && presBinary == "High" && windBinary == "Low")
                interpretation = "Cool, humid, stable";
            else if (tempBinary == "Low" && humBinary == "High" && presBinary == "High" && windBinary == "High")
                interpretation = "Cool, humid, storm-prone";
            else if (tempBinary == "High" && humBinary == "Low" && presBinary == "Low" && windBinary == "Low")
                interpretation = "Hot, dry";
            else if (tempBinary == "High" && humBinary == "Low" && presBinary == "Low" && windBinary == "High")
                interpretation = "Hot, dry, windy";
            else if (tempBinary == "High" && humBinary == "Low" && presBinary == "High" && windBinary == "Low")
                interpretation = "Hot, dry, stable";
            else if (tempBinary == "High" && humBinary == "Low" && presBinary == "High" && windBinary == "High")
                interpretation = "Hot, dry, windy";
            else if (tempBinary == "High" && humBinary == "High" && presBinary == "Low" && windBinary == "Low")
                interpretation = "Hot, humid";
            else if (tempBinary == "High" && humBinary == "High" && presBinary == "Low" && windBinary == "High")
                interpretation = "Hot, humid, stormy";
            else if (tempBinary == "High" && humBinary == "High" && presBinary == "High" && windBinary == "Low")
                interpretation = "Hot, humid, stable";
            else if (tempBinary == "High" && humBinary == "High" && presBinary == "High" && windBinary == "High")
                interpretation = "Extreme / severe setup";
            else
                interpretation = "Mixed conditions";


            string tempDesc =
                T < 15 ? "Cold" :
                T < 25 ? "Cool" :
                T < 32 ? "Warm" : "Hot";

            string humidityDesc =
                H < 30 ? "Very dry" :
                H < 50 ? "Dry" :
                H < 70 ? "Comfortable" : "Humid";

            string pressureDesc =
                P < 1000 ? "Very low / unstable" :
                P < 1010 ? "Low / rain-prone" :
                P <= 1020 ? "Normal" : "High / stable";

            string windDesc =
                W < 2 ? "Calm" :
                W < 5 ? "Light breeze" :
                W < 10 ? "Moderate wind" :
                W < 18 ? "Strong wind" : "Very strong wind";

            // Optional fog hint: high humidity + low wind → foggy tendency
            bool foggySetup = H > 90 && W < 3;
            if (foggySetup)
                windDesc += ", possible fog";

            lblCurrentTempValue.Text = tempDesc;
            lblCurrentHumidityValue.Text = humidityDesc;
            lblCurrentPressureValue.Text = pressureDesc;
            lblCurrentWindValue.Text = windDesc;
        }


    
        private void UpdateVariationProbabilities(WeatherInput input, WeatherResult baseResult)
        {
            double T = input.TemperatureC;
            double H = input.HumidityPercent;
            double P = input.PressureHpa;
            double W = input.WindSpeedMs;

            bool highHum = H > 70;
            bool medHum = H >= 40 && H <= 70;
            bool lowHum = H < 40;

            bool veryLowP = P < 1000;
            bool lowP = P < 1005;
            bool medP = P >= 1005 && P <= 1015;
            bool highP = P > 1015;
            bool veryHighP = P > 1020;

            bool lowWind = W < 3;
            bool modWind = W >= 3 && W < 8;
            bool highWind = W >= 8;

            bool lowTemp = T < 20;
            bool highTemp = T > 30;

            lblVar1Label.Text = "Variation 1:";
            lblVar2Label.Text = "Variation 2:";
            lblVar3Label.Text = "Variation 3:";

            lblVar1Value.Text = "--";
            lblVar2Value.Text = "--";
            lblVar3Value.Text = "--";

            // 1) Primary family based on humidity + pressure
            if (highHum && lowP)
            {
                lblVar1Value.Text =
                    veryLowP && highWind ? "Heavy rain with strong wind" :
                    lowP && highWind ? "Rain with wind" :
                    lowP && lowTemp ? "Cold rain" :
                                             "Light rain";

                // Storm-like extras
                lblVar2Value.Text =
                    highTemp && highHum && modWind ? "Thunderstorm" : "Rainy but warm";

                lblVar3Value.Text =
                    highTemp && highHum && highWind && lowP ? "Cyclonic storm risk" :
                    highWind ? "Windy, unstable conditions" :
                               "Showery periods likely";
            }
            else if (lowHum && highP)
            {
                lblVar1Value.Text =
                    lowWind ? "Sunny and calm" :
                    highWind ? "Clear but windy" :
                    veryHighP ? "Stable clear weather" :
                                         "Mostly clear";

                lblVar2Value.Text =
                    veryHighP ? "High-pressure dominance" : "Dry and comfortable";

                lblVar3Value.Text =
                    highWind ? "Blowing dust possible" : "Good visibility";
            }
            else if (medHum && medP)
            {
                lblVar1Value.Text = "Cloudy transition";

                lblVar2Value.Text =
                    H > 60 && P < 1010 ? "Possible rain developing" : "Stable cloud cover";

                lblVar3Value.Text =
                    lowWind ? "Calm, overcast conditions" : "Cloudy with some breeze";
            }
            else if (highHum && highP)
            {
                lblVar1Value.Text = "Humid but clear";

                lblVar2Value.Text =
                    lowWind ? "Sticky, still air" : "Humid with breeze";

                lblVar3Value.Text = "Heat discomfort likely";
            }
            else if (lowHum && lowP)
            {
                lblVar1Value.Text = "Dry but unstable";
                lblVar2Value.Text = highWind ? "Dusty, windy" : "Sharp, dry air";
                lblVar3Value.Text = "Changes possible soon";
            }
            else
            {
                // Generic fallback always filling lines
                lblVar1Value.Text = baseResult.Condition;
                lblVar2Value.Text = "Conditions may evolve";
                lblVar3Value.Text = "Monitor humidity and pressure changes";
            }
        }

        private void UpdateHighLevelProbabilities(WeatherResult result)
        {
            int rainProb = 0;
            int cloudyProb = 0;
            int clearProb = 0;
            int fogProb = 0;   // NEW

            if (result.Condition.Contains("Rain"))
            {
                rainProb = result.ProbabilityPercent;
                cloudyProb = result.ProbabilityPercent / 2;
                fogProb = result.ProbabilityPercent / 4; // rainy setups can have some fog
                clearProb = Math.Max(0, 100 - rainProb - cloudyProb - fogProb);
            }
            else if (result.Condition.Contains("Cloudy"))
            {
                cloudyProb = result.ProbabilityPercent;
                rainProb = result.ProbabilityPercent / 3;
                fogProb = result.ProbabilityPercent / 5;
                clearProb = Math.Max(0, 100 - cloudyProb - rainProb - fogProb);
            }
            else if (result.Condition.Contains("Clear"))
            {
                clearProb = result.ProbabilityPercent;
                cloudyProb = result.ProbabilityPercent / 3;
                fogProb = 5;  // small static fog chance
                rainProb = Math.Max(0, 100 - clearProb - cloudyProb - fogProb);
            }
            else
            {
                // Mixed / fallback
                rainProb = result.ProbabilityPercent / 3;
                cloudyProb = result.ProbabilityPercent / 3;
                fogProb = result.ProbabilityPercent / 5;
                clearProb = Math.Max(0, 100 - rainProb - cloudyProb - fogProb);
            }

            lblRainProbValue.Text = $"{rainProb}%";
            lblCloudyProbValue.Text = $"{cloudyProb}%";
            lblClearProbValue.Text = $"{clearProb}%";

            // NEW Fog label (must exist in designer as lblFogProbValue)
            lblFogProbValue.Text = $"{fogProb}%";
        }


        private void btnSimHumidity_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out var input)) return;

            input.HumidityPercent += 10;
            _currentInput = input;
            ApplyInputToTextBoxes(input);

            btnRunForecast_Click(sender, e);
        }

        private void btnSimPressure_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out var input)) return;

            input.PressureHpa -= 3;
            _currentInput = input;
            ApplyInputToTextBoxes(input);

            btnRunForecast_Click(sender, e);
        }


        private void btnFinalPrediction_Click(object sender, EventArgs e)
        {
            if (_currentInput == null || _currentForecast == null)
            {
                MessageBox.Show("First click 'Run Forecast' to calculate probabilities.");
                return;
            }

            string detailed = BuildDetailedPrediction(_currentInput, _currentForecast);
            lblFinalPredictionValue.Text = detailed;
        }

        private string BuildDetailedPrediction(WeatherInput input, WeatherResult baseResult)
        {
            double T = input.TemperatureC;
            double H = input.HumidityPercent;
            double P = input.PressureHpa;
            double W = input.WindSpeedMs;

            bool highHum = H > 70;
            bool medHum = H >= 40 && H <= 70;
            bool lowHum = H < 40;

            bool veryLowP = P < 1000;
            bool lowP = P < 1005;
            bool medP = P >= 1005 && P <= 1015;
            bool highP = P > 1015;
            bool veryHighP = P > 1020;

            bool lowWind = W < 3;
            bool modWind = W >= 3 && W < 8;
            bool highWind = W >= 8;

            bool lowTemp = T < 20;
            bool highTemp = T > 30;

            // Rain variations
            if (highHum && lowP)
            {
                if (veryLowP && highWind)
                    return "Heavy rain with strong wind";
                if (lowP && highWind)
                    return "Rain with wind";
                if (lowP && lowTemp)
                    return "Cold rain";
                return "Light rain";
            }

            // Storm variations
            if (highTemp && highHum && modWind && lowP)
                return "Thunderstorm";
            if (highTemp && highHum && highWind && lowP)
                return "Cyclonic storm";
            if (highTemp && highHum && highWind)
                return "Severe storm";

            // Clear variations
            if (lowHum && highP)
            {
                if (lowWind)
                    return "Sunny and calm";
                if (highWind)
                    return "Clear but windy";
                if (veryHighP)
                    return "Stable clear weather";
                return "Mostly clear";
            }

            // Mixed / transitional
            if (medHum && medP)
                return "Cloudy transition";
            if (medHum && lowP)
                return "Possible rain developing";
            if (highHum && highP)
                return "Humid but mostly clear";
            if (lowHum && lowP)
                return "Dry but unstable";

            return baseResult.Condition;
        }
    }
}
