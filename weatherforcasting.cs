//public class WeatherInput
//{
//    public double TemperatureC { get; set; }
//    public double HumidityPercent { get; set; }
//    public double PressureHpa { get; set; }
//    public double WindSpeedMs { get; set; }

//    public WeatherInput(double temperatureC, double humidityPercent, double pressureHpa, double windSpeedMs)
//    {
//        TemperatureC = temperatureC;
//        HumidityPercent = humidityPercent;
//        PressureHpa = pressureHpa;
//        WindSpeedMs = windSpeedMs;
//    }
//}

//public class WeatherResult
//{
//    public string Condition { get; set; }
//    public int ProbabilityPercent { get; set; }

//    public string ConfidenceLabel { get; set; }
//    public string Explanation { get; set; }

//    public WeatherResult(string condition, int probabilityPercent)
//    {
//        Condition = condition;
//        ProbabilityPercent = probabilityPercent;
//        ConfidenceLabel = string.Empty;
//        Explanation = string.Empty;
//    }
//}

//public class WeatherSimulationResult
//{
//    public WeatherResult BaseForecast { get; set; }
//    public WeatherResult SimulatedForecast { get; set; }

//    public string VariedParameterName { get; set; }
//    public double ChangeDescriptionValue { get; set; }
//    public string ChangeDescriptionUnit { get; set; }

//    public string SensitivityInsight { get; set; }

//    public WeatherSimulationResult()
//    {
//        SensitivityInsight = string.Empty;
//    }
//}


//public static class WeatherAnalysisHelpers
//{
//    public static string GetConfidenceLabel(int probabilityPercent)
//    {
//        if (probabilityPercent >= 80) return "High";
//        if (probabilityPercent >= 50) return "Medium";
//        return "Low";
//    }
//}



//public class WeatherForecaster
//{
//    public WeatherResult Forecast(WeatherInput input)
//    {
//        double humidity = Clamp(input.HumidityPercent, 0, 100);
//        double pressure = input.PressureHpa;
//        double wind = Math.Max(input.WindSpeedMs, 0);

//        if (humidity > 70 && pressure < 1005)
//        {
//            int baseProb = 70;

//            baseProb += (int)((humidity - 70) * 0.8);

//            if (wind > 5) baseProb += 5;
//            if (wind > 10) baseProb += 5;

//            int probability = Clamp(baseProb, 60, 100);
//            return new WeatherResult("Rain", probability);
//        }

//        if (humidity >= 40 && humidity <= 70 &&
//            pressure >= 1005 && pressure <= 1015)
//        {
//            int baseProb = 60;

//            baseProb += (int)Math.Min(wind, 10);

//            int probability = Clamp(baseProb, 40, 90);
//            return new WeatherResult("Cloudy", probability);
//        }

//        if (humidity < 40 && pressure > 1015)
//        {
//            int baseProb = 70;

//            baseProb += (int)((40 - humidity) * 0.5);

//            if (wind > 3 && wind <= 8)
//            {
//                baseProb += 5;
//            }

//            int probability = Clamp(baseProb, 50, 100);
//            return new WeatherResult("Clear", probability);
//        }

//        int fallbackProb = 40;
//        string condition;

//        if (humidity > 60)
//        {
//            condition = "Likely Rain / Showers";
//            fallbackProb += 10;
//            if (wind > 8) fallbackProb += 5;
//        }
//        else if (humidity < 30)
//        {
//            condition = "Likely Clear / Partly Cloudy";
//            fallbackProb += 10;
//        }
//        else
//        {
//            condition = "Variable / Uncertain";
//        }

//        int finalProb = Clamp(fallbackProb, 20, 80);
//        return new WeatherResult(condition, finalProb);
//    }

//    private static int Clamp(double value, int min, int max)
//    {
//        if (value < min) return min;
//        if (value > max) return max;
//        return (int)value;
//    }
//}


//public class WeatherSimulationEngine
//{
//    private readonly WeatherForecaster _forecaster = new WeatherForecaster();


//    public WeatherSimulationResult RunHumidityIncreaseSimulation(WeatherInput baseInput, double increasePercent = 10.0)
//    {
//        WeatherResult baseResult = _forecaster.Forecast(baseInput);
//        baseResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(baseResult.ProbabilityPercent);

//        WeatherInput variedInput = new WeatherInput(
//            baseInput.TemperatureC,
//            baseInput.HumidityPercent + increasePercent,
//            baseInput.PressureHpa,
//            baseInput.WindSpeedMs
//        );

//        WeatherResult variedResult = _forecaster.Forecast(variedInput);
//        variedResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(variedResult.ProbabilityPercent);

//        string insight = BuildSensitivityInsight(
//            "Humidity",
//            increasePercent,
//            "%",
//            baseResult,
//            variedResult
//        );

//        return new WeatherSimulationResult
//        {
//            BaseForecast = baseResult,
//            SimulatedForecast = variedResult,
//            VariedParameterName = "Humidity",
//            ChangeDescriptionValue = increasePercent,
//            ChangeDescriptionUnit = "%",
//            SensitivityInsight = insight
//        };
//    }

//    public WeatherSimulationResult RunPressureDecreaseSimulation(WeatherInput baseInput, double deltaHpa = -3.0)
//    {
//        WeatherResult baseResult = _forecaster.Forecast(baseInput);
//        baseResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(baseResult.ProbabilityPercent);

//        WeatherInput variedInput = new WeatherInput(
//            baseInput.TemperatureC,
//            baseInput.HumidityPercent,
//            baseInput.PressureHpa + deltaHpa,
//            baseInput.WindSpeedMs
//        );

//        WeatherResult variedResult = _forecaster.Forecast(variedInput);
//        variedResult.ConfidenceLabel = WeatherAnalysisHelpers.GetConfidenceLabel(variedResult.ProbabilityPercent);

//        string insight = BuildSensitivityInsight(
//            "Pressure",
//            deltaHpa,
//            " hPa",
//            baseResult,
//            variedResult
//        );

//        return new WeatherSimulationResult
//        {
//            BaseForecast = baseResult,
//            SimulatedForecast = variedResult,
//            VariedParameterName = "Pressure",
//            ChangeDescriptionValue = deltaHpa,
//            ChangeDescriptionUnit = " hPa",
//            SensitivityInsight = insight
//        };
//    }

//    private string BuildSensitivityInsight(string parameterName,
//                                           double delta,
//                                           string unit,
//                                           WeatherResult baseResult,
//                                           WeatherResult variedResult)
//    {
//        int diff = variedResult.ProbabilityPercent - baseResult.ProbabilityPercent;

//        if (diff == 0 && baseResult.Condition == variedResult.Condition)
//        {
//            return $"{parameterName} change of {delta}{unit} did not significantly affect the forecast.";
//        }

//        string conditionChangeText = baseResult.Condition == variedResult.Condition
//            ? $"kept condition as {variedResult.Condition}"
//            : $"changed condition from {baseResult.Condition} to {variedResult.Condition}";

//        string probText = diff > 0
//            ? $"increased {variedResult.Condition} probability by {diff}%"
//            : diff < 0
//                ? $"decreased {variedResult.Condition} probability by {-diff}%"
//                : "did not change the probability";

//        return $"{parameterName} change of {delta}{unit} {conditionChangeText} and {probText}.";
//    }
//}


//public class QuantumWeatherForecaster
//{
//    private readonly WeatherForecaster classicalForecaster = new WeatherForecaster();

//    public WeatherResult ForecastWithGroverDemo(WeatherInput input)
//    {
//        WeatherResult classical = classicalForecaster.Forecast(input);

//        int markedIndex = MapInputToScenarioIndex(input, classical);

//        int[] measuredBits = GroverSearch4Q.RunGrover4Qubits(markedIndex);
//        int measuredIndex = BitsToIndex(measuredBits);

//        WeatherResult quantumResult = ScenarioIndexToForecast(measuredIndex, input);


//        return quantumResult;
//    }

//    private int BitsToIndex(int[] bits)
//    {
//        if (bits == null || bits.Length != 4)
//            return 0;

//        int q3 = bits[0];
//        int q2 = bits[1];
//        int q1 = bits[2];
//        int q0 = bits[3];

//        return (q3 << 3) | (q2 << 2) | (q1 << 1) | q0;
//    }


//    private int MapInputToScenarioIndex(WeatherInput input, WeatherResult classical)
//    {
//        int tempBucket =
//            input.TemperatureC < 20 ? 0 :
//            input.TemperatureC < 30 ? 1 : 2;

//        int humBucket =
//            input.HumidityPercent < 40 ? 0 :
//            input.HumidityPercent < 70 ? 1 : 2;

//        int pressureBucket =
//            input.PressureHpa < 1005 ? 0 :
//            input.PressureHpa < 1015 ? 1 : 2;

//        int windBucket =
//            input.WindSpeedMs < 3 ? 0 :
//            input.WindSpeedMs < 8 ? 1 : 2;

//        int b0 = tempBucket & 1;
//        int b1 = humBucket & 1;
//        int b2 = pressureBucket & 1;
//        int b3 = windBucket & 1;

//        int baseIndex = (b3 << 3) | (b2 << 2) | (b1 << 1) | b0;

//        int offset =
//            classical.Condition.Contains("Rain") ? 0 :
//            classical.Condition.Contains("Cloudy") ? 4 : 8;

//        int markedIndex = (baseIndex + offset) & 0xF;

//        return markedIndex;
//    }

//    private WeatherResult ScenarioIndexToForecast(int idx, WeatherInput input)
//    {
//        if (idx < 4)
//        {
//            return new WeatherResult("Clear", 80);
//        }
//        if (idx < 10)
//        {
//            return new WeatherResult("Cloudy", 70);
//        }
//        return new WeatherResult("Rain", 75);
//    }
//}


