using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class WeatherResult
    {
        public string Condition { get; set; }
        public int ProbabilityPercent { get; set; }
        public string ConfidenceLabel { get; set; }

        public WeatherResult(string condition, int probabilityPercent)
        {
            Condition = condition;
            ProbabilityPercent = probabilityPercent;
        }
    }
}
