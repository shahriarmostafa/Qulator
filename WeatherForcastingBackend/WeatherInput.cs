using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
