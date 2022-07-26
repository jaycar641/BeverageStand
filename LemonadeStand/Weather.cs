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
        public int weather;
        private List<string> WeatherConditions = new List<string>();
        
        public string PredictedForecast; //tells you in the recipe class
        

    
       public Weather()
       {
           weatherConditions();
            Random weatherGenerator = new Random();           
            weather = weatherGenerator.Next(0,4);

            switch (weather)
            {
                case 0:
                    condition = "Cloudy";
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
            Random temperatureGenerator = new Random();
            temperature = 70 + (temperatureGenerator.Next(0, 30));

        }


        public void weatherConditions()
        {
               this.WeatherConditions.Add("Cloudy");
                this.WeatherConditions.Add("Rain");
                this.WeatherConditions.Add("Sunny");
                this.WeatherConditions.Add("Overcast");

        }

    

    }
}

