using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {

        public static int DisplayWelcome()
        {
            Console.WriteLine("Welcome to Lemonade Stand.  You can choose 7, 14, 21 for the amount of time that your in business" + "\n You will have control over the price, recipe, inventory, and purchasing supplies.");
            Console.WriteLine("How Many Days would you like to play?");
            int numberofDays = int.Parse(Console.ReadLine());
            return numberofDays;

        }

            
            public static string DisplayName()
            {
                Console.WriteLine("What is your name?");
                string name = Console.ReadLine();
                return name;
            }

        


        public static void DisplayNumberofDays(int numberofDays)
        {
            Console.WriteLine(numberofDays + "Days");
        }
    }
}
