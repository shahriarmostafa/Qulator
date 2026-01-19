using System;

namespace Sim1Test.WeatherForcastingBackend
{
    public class VariationProbabilities
    {
        public string Variation1 { get; set; }
        public string Variation2 { get; set; }
        public string Variation3 { get; set; }

        public static VariationProbabilities Calculate(WeatherInput input, WeatherResult baseResult)
        {
            double T = input.TemperatureC;
            double H = input.HumidityPercent;
            double P = input.PressureHpa;
            double W = input.WindSpeedMs;

            bool highHum = H > 70;
            bool medHum = H >= 40 && H <= 70;
            bool lowHum = H < 40;

            bool veryLowP = P < 1000;
            bool lowP = P < 1005;
            bool medP = P >= 1005 && P <= 1015;
            bool highP = P > 1015;
            bool veryHighP = P > 1020;

            bool lowWind = W < 3;
            bool modWind = W >= 3 && W < 8;
            bool highWind = W >= 8;

            bool lowTemp = T < 20;
            bool highTemp = T > 30;

            string var1 = "--";
            string var2 = "--";
            string var3 = "--";

            if (highHum && lowP)
            {
                var1 = veryLowP && highWind ? "Heavy rain with strong wind" :
                       lowP && highWind ? "Rain with wind" :
                       lowP && lowTemp ? "Cold rain" :
                       "Light rain";

                var2 = highTemp && highHum && modWind ? "Thunderstorm" : "Rainy but warm";

                var3 = highTemp && highHum && highWind && lowP ? "Cyclonic storm risk" :
                       highWind ? "Windy, unstable conditions" :
                       "Showery periods likely";
            }
            else if (lowHum && highP)
            {
                var1 = lowWind ? "Sunny and calm" :
                       highWind ? "Clear but windy" :
                       veryHighP ? "Stable clear weather" :
                       "Mostly clear";

                var2 = veryHighP ? "High-pressure dominance" : "Dry and comfortable";

                var3 = highWind ? "Blowing dust possible" : "Good visibility";
            }
            else if (medHum && medP)
            {
                var1 = "Cloudy transition";
                var2 = H > 60 && P < 1010 ? "Possible rain developing" : "Stable cloud cover";
                var3 = lowWind ? "Calm, overcast conditions" : "Cloudy with some breeze";
            }
            else if (highHum && highP)
            {
                var1 = "Humid but clear";
                var2 = lowWind ? "Sticky, still air" : "Humid with breeze";
                var3 = "Heat discomfort likely";
            }
            else if (lowHum && lowP)
            {
                var1 = "Dry but unstable";
                var2 = highWind ? "Dusty, windy" : "Sharp, dry air";
                var3 = "Changes possible soon";
            }
            else
            {
                var1 = baseResult.Condition;
                var2 = "Conditions may evolve";
                var3 = "Monitor humidity and pressure changes";
            }

            return new VariationProbabilities
            {
                Variation1 = var1,
                Variation2 = var2,
                Variation3 = var3
            };
        }
    }
}
