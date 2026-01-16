using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.WeatherForcastingBackend
{
    public class WeatherSimulationResult
    {
        public WeatherResult BaseForecast { get; set; }
        public WeatherResult SimulatedForecast { get; set; }

        public string VariedParameterName { get; set; }
        public double ChangeDescriptionValue { get; set; }
        public string ChangeDescriptionUnit { get; set; }

        public string SensitivityInsight { get; set; }

        public WeatherSimulationResult()
        {
            SensitivityInsight = string.Empty;
        }
    }
}
