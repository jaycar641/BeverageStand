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
        public bool doesPurchase;
        private List<string> names = new List<string>();
        public string name;
        public int purchaseRatio = 0;
        
        public Customer(string weather, int temperature, double pricepercup)
        {
            purchaseRatio = 30;
            SetName();
            PurchaseRatio(weather, temperature, pricepercup);
          
            if (randomGenerator.Next(0, purchaseRatio) > 20)
            {
                doesPurchase = false;
            }
           else
            {
                doesPurchase = true;
            }

            name = names.ElementAt(randomGenerator.Next(0, 9));  //
            randomGenerator = null;
            purchaseRatio = 10;
        }

        public void PurchaseRatio(string weather, int temperature, double pricepercup)
        {

          
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
                    purchaseRatio -= 2;
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
                purchaseRatio -= 1;
            }

           
           
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
