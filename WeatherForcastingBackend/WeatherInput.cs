using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class WeatherInput
    {
        public double TemperatureC { get; set; }
        public double HumidityPercent { get; set; }
        public double PressureHpa { get; set; }
        public double WindSpeedMs { get; set; }

        public WeatherInput(double temperatureC, double humidityPercent, double pressureHpa, double windSpeedMs)
        {
            TemperatureC = temperatureC;
            HumidityPercent = humidityPercent;
            PressureHpa = pressureHpa;
            WindSpeedMs = windSpeedMs;
        }

        public WeatherInput Clone()
        {
            return new WeatherInput(TemperatureC, HumidityPercent, PressureHpa, WindSpeedMs);
        }
    }
}
