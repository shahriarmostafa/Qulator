using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
