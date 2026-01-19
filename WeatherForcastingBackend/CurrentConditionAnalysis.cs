using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class CurrentConditionAnalysis
    {
        public string TemperatureDesc { get; set; }
        public string HumidityDesc { get; set; }
        public string PressureDesc { get; set; }
        public string WindDesc { get; set; }
        public string Interpretation { get; set; }

        public static CurrentConditionAnalysis Analyze(WeatherInput input)
        {
            double T = input.TemperatureC;
            double H = input.HumidityPercent;
            double P = input.PressureHpa;
            double W = input.WindSpeedMs;

            string tempBinary = WeatherAnalysisHelpers.GetBinaryClassification(T, 25);
            string humBinary = WeatherAnalysisHelpers.GetBinaryClassification(H, 60);
            string presBinary = WeatherAnalysisHelpers.GetBinaryClassification(P, 1010);
            string windBinary = WeatherAnalysisHelpers.GetBinaryClassification(W, 5);

            string interpretation = GetInterpretation(tempBinary, humBinary, presBinary, windBinary);

            return new CurrentConditionAnalysis
            {
                TemperatureDesc = WeatherAnalysisHelpers.GetTemperatureDescription(T),
                HumidityDesc = WeatherAnalysisHelpers.GetHumidityDescription(H),
                PressureDesc = WeatherAnalysisHelpers.GetPressureDescription(P),
                WindDesc = WeatherAnalysisHelpers.GetWindDescription(W, H),
                Interpretation = interpretation
            };
        }

        private static string GetInterpretation(string temp, string hum, string pres, string wind)
        {
            if (temp == "Low" && hum == "Low" && pres == "Low" && wind == "Low")
                return "Cool, dry, calm";
            if (temp == "Low" && hum == "Low" && pres == "Low" && wind == "High")
                return "Cool, dry, windy";
            if (temp == "Low" && hum == "Low" && pres == "High" && wind == "Low")
                return "Cool, dry, stable";
            if (temp == "Low" && hum == "Low" && pres == "High" && wind == "High")
                return "Cool, dry, windy";
            if (temp == "Low" && hum == "High" && pres == "Low" && wind == "Low")
                return "Cool, humid";
            if (temp == "Low" && hum == "High" && pres == "Low" && wind == "High")
                return "Cool, humid, windy";
            if (temp == "Low" && hum == "High" && pres == "High" && wind == "Low")
                return "Cool, humid, stable";
            if (temp == "Low" && hum == "High" && pres == "High" && wind == "High")
                return "Cool, humid, storm-prone";
            if (temp == "High" && hum == "Low" && pres == "Low" && wind == "Low")
                return "Hot, dry";
            if (temp == "High" && hum == "Low" && pres == "Low" && wind == "High")
                return "Hot, dry, windy";
            if (temp == "High" && hum == "Low" && pres == "High" && wind == "Low")
                return "Hot, dry, stable";
            if (temp == "High" && hum == "Low" && pres == "High" && wind == "High")
                return "Hot, dry, windy";
            if (temp == "High" && hum == "High" && pres == "Low" && wind == "Low")
                return "Hot, humid";
            if (temp == "High" && hum == "High" && pres == "Low" && wind == "High")
                return "Hot, humid, stormy";
            if (temp == "High" && hum == "High" && pres == "High" && wind == "Low")
                return "Hot, humid, stable";
            if (temp == "High" && hum == "High" && pres == "High" && wind == "High")
                return "Extreme / severe setup";
            
            return "Mixed conditions";
        }
    }
}
