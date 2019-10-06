using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        Random randomGenerator = new Random();
        public int tasteRatio;
        public bool doesPurchase;
        private List<string> names = new List<string>();
        public string name;
        
        
        public Customer(string weather, int temperature, double pricepercup)
        {
            int purchaseRatio = PurchaseRatio(weather, temperature, pricepercup);
          
            if (randomGenerator.Next(0, purchaseRatio) > 5)
            {
                doesPurchase = false;
            }
           else
            {
                doesPurchase = true;
            }

            tasteRatio = randomGenerator.Next(0, 6);  //sets taste
            //if clause for weather that effects x
            name = names.ElementAt(randomGenerator.Next(0, 10));  //
        }

        public int PurchaseRatio(string weather, int temperature, double pricepercup)
        {

            int purchaseRatio = 10;
                if (temperature <= 100 && temperature > 90)
                {
                    purchaseRatio -= 3;
                }

                else if (temperature <= 90 && temperature > 80)
                {
                    purchaseRatio -= 2;
                }

                else if (temperature <= 80 && temperature > 70)
                {
                    purchaseRatio -= 1;
                }


                switch (weather)
            {
                case "Cloudy":
                    purchaseRatio += 1;
                break;
                case "Rain":
                    purchaseRatio += 2;
                break;
                case "Sunny":
                    purchaseRatio -= 1;
                break;
                case "Overcast":
                    purchaseRatio += 0;
                break;

            }

            if (pricepercup <= 1.00 && pricepercup > .75)
            {
                purchaseRatio += 8;

            }

            else if (pricepercup <= .75 && pricepercup > .50)
            {
                purchaseRatio += 5;

            }
            else if (pricepercup <= 50 && pricepercup > .25)
            {
                purchaseRatio += 3;

            }

            else
            {
                purchaseRatio += 1;
            }

            return purchaseRatio;
           
           
        }

        public bool TasteRatio (int tasteratio)
        {
            bool doesLike;

            if (tasteRatio >= 3)
            {
                doesLike = true;
   
            }
            else
            {
                doesLike = false;
            }

            return doesLike;
        }


    }
}
