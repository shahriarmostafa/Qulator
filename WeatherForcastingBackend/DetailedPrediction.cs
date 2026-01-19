using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public static class DetailedPrediction
    {
        public static string Build(WeatherInput input, WeatherResult baseResult)
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

            if (highTemp && highHum && modWind && lowP)
                return "Thunderstorm";
            if (highTemp && highHum && highWind && lowP)
                return "Cyclonic storm";
            if (highTemp && highHum && highWind)
                return "Severe storm";

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
