using Sim1Test.Algorithms.GroverSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.WeatherForcastingBackend
{
    public class QuantumWeatherForecaster
    {
        private readonly WeatherForecaster classicalForecaster = new WeatherForecaster();

        public WeatherResult ForecastWithGroverDemo(WeatherInput input)
        {
            WeatherResult classical = classicalForecaster.Forecast(input);

            int markedIndex = MapInputToScenarioIndex(input, classical);

            int[] measuredBits = GroverSearch4Q.RunGrover4Qubits(markedIndex);
            int measuredIndex = BitsToIndex(measuredBits);

            WeatherResult quantumResult = ScenarioIndexToForecast(measuredIndex, input);


            return quantumResult;
        }

        private int BitsToIndex(int[] bits)
        {
            if (bits == null || bits.Length != 4)
                return 0;

            int q3 = bits[0];
            int q2 = bits[1];
            int q1 = bits[2];
            int q0 = bits[3];

            return (q3 << 3) | (q2 << 2) | (q1 << 1) | q0;
        }


        private int MapInputToScenarioIndex(WeatherInput input, WeatherResult classical)
        {
            int tempBucket =
                input.TemperatureC < 20 ? 0 :
                input.TemperatureC < 30 ? 1 : 2;

            int humBucket =
                input.HumidityPercent < 40 ? 0 :
                input.HumidityPercent < 70 ? 1 : 2;

            int pressureBucket =
                input.PressureHpa < 1005 ? 0 :
                input.PressureHpa < 1015 ? 1 : 2;

            int windBucket =
                input.WindSpeedMs < 3 ? 0 :
                input.WindSpeedMs < 8 ? 1 : 2;

            int b0 = tempBucket & 1;
            int b1 = humBucket & 1;
            int b2 = pressureBucket & 1;
            int b3 = windBucket & 1;

            int baseIndex = (b3 << 3) | (b2 << 2) | (b1 << 1) | b0;

            int offset =
                classical.Condition.Contains("Rain") ? 0 :
                classical.Condition.Contains("Cloudy") ? 4 : 8;

            int markedIndex = (baseIndex + offset) & 0xF;

            return markedIndex;
        }

        private WeatherResult ScenarioIndexToForecast(int idx, WeatherInput input)
        {
            if (idx < 4)
            {
                return new WeatherResult("Clear", 80);
            }
            if (idx < 10)
            {
                return new WeatherResult("Cloudy", 70);
            }
            return new WeatherResult("Rain", 75);
        }
    }
}
