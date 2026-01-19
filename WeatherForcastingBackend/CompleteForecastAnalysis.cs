using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class CompleteForecastAnalysis
    {
        public WeatherResult MainForecast { get; set; }
        public HighLevelProbabilities HighLevelProbs { get; set; }
        public VariationProbabilities Variations { get; set; }
        public CurrentConditionAnalysis CurrentConditions { get; set; }
        public string detailedPrediction { get; set; }

        public static CompleteForecastAnalysis Analyze(WeatherInput input, WeatherForecaster forecaster)
        {
            WeatherResult result = forecaster.Forecast(input);
            result.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(result.ProbabilityPercent);

            return new CompleteForecastAnalysis
            {
        
                MainForecast = result,
                HighLevelProbs = HighLevelProbabilities.Calculate(result),
                Variations = VariationProbabilities.Calculate(input, result),
                CurrentConditions = CurrentConditionAnalysis.Analyze(input),
                detailedPrediction = DetailedPrediction.Build(input, result)
            };
        }
    }
}
