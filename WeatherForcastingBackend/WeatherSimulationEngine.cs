using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class WeatherSimulationEngine
    {
        private readonly WeatherForecaster _forecaster = new WeatherForecaster();

        public WeatherSimulationResult RunHumidityIncreaseSimulation(WeatherInput baseInput, double increasePercent = 10.0)
        {
            WeatherResult baseResult = _forecaster.Forecast(baseInput);
            baseResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(baseResult.ProbabilityPercent);

            WeatherInput variedInput = new WeatherInput(
                baseInput.TemperatureC,
                baseInput.HumidityPercent + increasePercent,
                baseInput.PressureHpa,
                baseInput.WindSpeedMs
            );

            WeatherResult variedResult = _forecaster.Forecast(variedInput);
            variedResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(variedResult.ProbabilityPercent);

            string insight = BuildSensitivityInsight(
                "Humidity",
                increasePercent,
                "%",
                baseResult,
                variedResult
            );

            return new WeatherSimulationResult
            {
                BaseForecast = baseResult,
                SimulatedForecast = variedResult,
                VariedParameterName = "Humidity",
                ChangeDescriptionValue = increasePercent,
                ChangeDescriptionUnit = "%",
                SensitivityInsight = insight
            };
        }

        public WeatherSimulationResult RunPressureDecreaseSimulation(WeatherInput baseInput, double deltaHpa = -3.0)
        {
            WeatherResult baseResult = _forecaster.Forecast(baseInput);
            baseResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(baseResult.ProbabilityPercent);

            WeatherInput variedInput = new WeatherInput(
                baseInput.TemperatureC,
                baseInput.HumidityPercent,
                baseInput.PressureHpa + deltaHpa,
                baseInput.WindSpeedMs
            );

            WeatherResult variedResult = _forecaster.Forecast(variedInput);
            variedResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(variedResult.ProbabilityPercent);

            string insight = BuildSensitivityInsight(
                "Pressure",
                deltaHpa,
                " hPa",
                baseResult,
                variedResult
            );

            return new WeatherSimulationResult
            {
                BaseForecast = baseResult,
                SimulatedForecast = variedResult,
                VariedParameterName = "Pressure",
                ChangeDescriptionValue = deltaHpa,
                ChangeDescriptionUnit = " hPa",
                SensitivityInsight = insight
            };
        }

        private string BuildSensitivityInsight(string parameterName,
                                               double delta,
                                               string unit,
                                               WeatherResult baseResult,
                                               WeatherResult variedResult)
        {
            int diff = variedResult.ProbabilityPercent - baseResult.ProbabilityPercent;

            if (diff == 0 && baseResult.Condition == variedResult.Condition)
            {
                return $"{parameterName} change of {delta}{unit} did not significantly affect the forecast.";
            }

            string conditionChangeText = baseResult.Condition == variedResult.Condition
                ? $"kept condition as {variedResult.Condition}"
                : $"changed condition from {baseResult.Condition} to {variedResult.Condition}";

            string probText = diff > 0
                ? $"increased {variedResult.Condition} probability by {diff}%"
                : diff < 0
                    ? $"decreased {variedResult.Condition} probability by {-diff}%"
                    : "did not change the probability";

            return $"{parameterName} change of {delta}{unit} {conditionChangeText} and {probText}.";
        }
    }
}
