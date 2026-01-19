using System;

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
    }
}
