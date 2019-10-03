using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public string condition;
        public int temperature;
        private List<string> WeatherConditions = new List<string>();
        public string PredictedForecast; //tells you in the recipe class
        Random weatherGenerator = new Random();
    
       public Weather()
       {
           
            int weather = weatherGenerator.Next(0,4);

            switch (weather)
            {
                case 0:
                    condition = "Cloud";
                    break;
                case 1:
                    condition = "Sunny";
                    break;
                case 2:
                    condition = "OverCast";
                    break;
                case 3:
                    condition = "Rain";
                    break;

            }
        }


        public string weatherConditions
        {
            set
            {
                WeatherConditions.Add("Cloudy");
                WeatherConditions.Add("Rain");
                WeatherConditions.Add("Sunny");
                WeatherConditions.Add("Overcast");

            }

        }

        public void Temperature()
        {
                temperature = 70 + (weatherGenerator.Next(0, 30));
            
        }

    }
}

