using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.WeatherForcastingBackend
{
    public class WeatherResult
    {
        public string Condition { get; set; }
        public int ProbabilityPercent { get; set; }

        public string ConfidenceLabel { get; set; }
        public string Explanation { get; set; }

        public WeatherResult(string condition, int probabilityPercent)
        {
            Condition = condition;
            ProbabilityPercent = probabilityPercent;
            ConfidenceLabel = string.Empty;
            Explanation = string.Empty;
        }
    }
}
