using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        public bool doesPurchase;
        private List<string> names = new List<string>();
        public string name;
        public int purchaseRatio;
        Random randomGenerator = new Random();
        
        public Customer(string weather, int temperature, double pricepercup)
        {
           PurchaseRatio(weather, temperature, pricepercup);


            SetName();
          
            
            name = names.ElementAt(randomGenerator.Next(0, 9));  //
            randomGenerator = null;
            //purchaseRatio = 10;
        }

        public int PurchaseRatio(string weather, int temperature, double pricepercup)
        {
           purchaseRatio = randomGenerator.Next(0, 40);

            
            if (temperature <= 100 && temperature > 90)
                {
                    purchaseRatio += 15;
                }

                else if (temperature <= 90 && temperature > 80)
                {
                    purchaseRatio += 10;
                }

                else if (temperature <= 80 && temperature > 70)
                {
                    purchaseRatio += 5;
                }


                switch (weather)
            {
                case "Cloudy":
                    purchaseRatio -= 10;
                break;
                case "Rain":
                    purchaseRatio -= 30;
                break;
                case "Sunny":
                    purchaseRatio += 15;
                break;
                case "Overcast":
                    purchaseRatio -= 0;
                break;

            }

            if (pricepercup <= 1.00 && pricepercup > .75)
            {
                purchaseRatio -= 15;

            }

            else if (pricepercup <= .75 && pricepercup > .50)
            {
                purchaseRatio -= 5;

            }
            else if (pricepercup <= 50 && pricepercup > .25)
            {
                purchaseRatio += 15;

            }

            else
            {
                purchaseRatio += 10;
            }

            if (purchaseRatio <= 20)
            {
                doesPurchase = false;
            }
            else
            {
                doesPurchase = true;
            }


            return purchaseRatio;
        }


        public void SetName()
        {
            names.Add("Lisa");
            names.Add("Sarah");
            names.Add("Tom");
            names.Add("John");
            names.Add("Mike");
            names.Add("Emily");
            names.Add("Robert");
            names.Add("Patty");
            names.Add("Benjamin");
            names.Add("Claire");

        }


    }
}
