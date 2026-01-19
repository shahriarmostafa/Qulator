using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class WeatherForecaster
    {
        public WeatherResult Forecast(WeatherInput input)
        {
            double humidity = Clamp(input.HumidityPercent, 0, 100);
            double pressure = input.PressureHpa;
            double wind = Math.Max(input.WindSpeedMs, 0);

            if (humidity > 70 && pressure < 1005)
            {
                int baseProb = 70;
                baseProb += (int)((humidity - 70) * 0.8);
                if (wind > 5) baseProb += 5;
                if (wind > 10) baseProb += 5;
                int probability = Clamp(baseProb, 60, 100);
                return new WeatherResult("Rain", probability);
            }

            if (humidity >= 40 && humidity <= 70 &&
                pressure >= 1005 && pressure <= 1015)
            {
                int baseProb = 60;
                baseProb += (int)Math.Min(wind, 10);
                int probability = Clamp(baseProb, 40, 90);
                return new WeatherResult("Cloudy", probability);
            }

            if (humidity < 40 && pressure > 1015)
            {
                int baseProb = 70;
                baseProb += (int)((40 - humidity) * 0.5);
                if (wind > 3 && wind <= 8)
                {
                    baseProb += 5;
                }
                int probability = Clamp(baseProb, 50, 100);
                return new WeatherResult("Clear", probability);
            }

            int fallbackProb = 40;
            string condition;
            if (humidity > 60)
            {
                condition = "Likely Rain / Showers";
                fallbackProb += 10;
                if (wind > 8) fallbackProb += 5;
            }
            else if (humidity < 30)
            {
                condition = "Likely Clear / Partly Cloudy";
                fallbackProb += 10;
            }
            else
            {
                condition = "Variable / Uncertain";
            }

            int finalProb = Clamp(fallbackProb, 20, 80);
            return new WeatherResult(condition, finalProb);
        }

        private static int Clamp(double value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return (int)value;
        }
    }
}
