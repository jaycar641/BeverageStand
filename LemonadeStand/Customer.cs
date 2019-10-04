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
        public int purchaseRatio;
        private List<string> names = new List<string>();
        public string name;
        
        
        public Customer(string weather, int temperature)
        {
            int x = 5;
        
            //if clause for weather that effects x
            tasteRatio = randomGenerator.Next(0, 5);  //sets taste
            name = names.ElementAt(randomGenerator.Next(0, 10));  //
            purchaseRatio = randomGenerator.Next(0, x);
            Console.WriteLine(name);
        }
    }
}
