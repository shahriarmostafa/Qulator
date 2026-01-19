using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class HighLevelProbabilities
    {
        public int RainProbability { get; set; }
        public int CloudyProbability { get; set; }
        public int ClearProbability { get; set; }
        public int FogProbability { get; set; }

        public static HighLevelProbabilities Calculate(WeatherResult result)
        {
            int rainProb = 0;
            int cloudyProb = 0;
            int clearProb = 0;
            int fogProb = 0;

            if (result.Condition.Contains("Rain"))
            {
                rainProb = result.ProbabilityPercent;
                cloudyProb = result.ProbabilityPercent / 2;
                fogProb = result.ProbabilityPercent / 4;
                clearProb = Math.Max(0, 100 - rainProb - cloudyProb - fogProb);
            }
            else if (result.Condition.Contains("Cloudy"))
            {
                cloudyProb = result.ProbabilityPercent;
                rainProb = result.ProbabilityPercent / 3;
                fogProb = result.ProbabilityPercent / 5;
                clearProb = Math.Max(0, 100 - cloudyProb - rainProb - fogProb);
            }
            else if (result.Condition.Contains("Clear"))
            {
                clearProb = result.ProbabilityPercent;
                cloudyProb = result.ProbabilityPercent / 3;
                fogProb = 5;
                rainProb = Math.Max(0, 100 - clearProb - cloudyProb - fogProb);
            }
            else
            {
                rainProb = result.ProbabilityPercent / 3;
                cloudyProb = result.ProbabilityPercent / 3;
                fogProb = result.ProbabilityPercent / 5;
                clearProb = Math.Max(0, 100 - rainProb - cloudyProb - fogProb);
            }

            return new HighLevelProbabilities
            {
                RainProbability = rainProb,
                CloudyProbability = cloudyProb,
                ClearProbability = clearProb,
                FogProbability = fogProb
            };
        }
    }
}
