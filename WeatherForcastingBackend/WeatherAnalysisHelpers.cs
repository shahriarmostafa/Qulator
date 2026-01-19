using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public static class WeatherAnalysisHelpers
    {
        public static string GetConfidenceLabel(int probabilityPercent)
        {
            if (probabilityPercent >= 80) return "High";
            if (probabilityPercent >= 50) return "Medium";
            return "Low";
        }

        public static string GetTemperatureDescription(double temp)
        {
            if (temp < 15) return "Cold";
            if (temp < 25) return "Cool";
            if (temp < 32) return "Warm";
            return "Hot";
        }

        public static string GetHumidityDescription(double humidity)
        {
            if (humidity < 30) return "Very dry";
            if (humidity < 50) return "Dry";
            if (humidity < 70) return "Comfortable";
            return "Humid";
        }

        public static string GetPressureDescription(double pressure)
        {
            if (pressure < 1000) return "Very low / unstable";
            if (pressure < 1010) return "Low / rain-prone";
            if (pressure <= 1020) return "Normal";
            return "High / stable";
        }

        public static string GetWindDescription(double wind, double humidity)
        {
            string desc;
            if (wind < 2) desc = "Calm";
            else if (wind < 5) desc = "Light breeze";
            else if (wind < 10) desc = "Moderate wind";
            else if (wind < 18) desc = "Strong wind";
            else desc = "Very strong wind";

            bool foggySetup = humidity > 90 && wind < 3;
            if (foggySetup)
                desc += ", possible fog";

            return desc;
        }

        public static string GetBinaryClassification(double value, double threshold, string lowLabel = "Low", string highLabel = "High")
        {
            return value < threshold ? lowLabel : highLabel;
        }
    }
}
