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


        public static void DisplayMenu(double currentMoney, int currentLemons, int currentIceCubes, int currentCups, int currentSugars)
        {
            Console.WriteLine("You currently have: ");
            Console.WriteLine("\n");
            Console.WriteLine("Cups: " + currentCups);
            Console.WriteLine("\n");
            Console.WriteLine("Lemons: " + currentLemons);
            Console.WriteLine("\n");
            Console.WriteLine("IceCubes: " + currentIceCubes);
            Console.WriteLine("\n");
            Console.WriteLine("Money: " + currentMoney);
            Console.WriteLine("\n");
            Console.WriteLine("Sugar " + currentSugars);
            Console.WriteLine("\n");
            Console.ReadLine();
        }

        public static void ChangeIceCubes()
        {


        }
        public static string WeatherDisplay(string weather)
        {
            return weather;
        }

        public static int temperature(int temperature)
        {
            return temperature;

        }

        public static string CashDisplay(double currentMoney) //takes in the current money and displays it 
        {
            return Convert.ToString(currentMoney);
        }
        public static Item PurchaseItems ()
        {
            Console.WriteLine("Enter the item you like to purchase");
            string itemInput = Console.ReadLine();
            Item choosenitem = null;
            switch (itemInput)
            {
                case "Lemon":
                    Console.WriteLine("How many?");
                    choosenitem = new Lemon();
                    break;
               case "Sugar":
                    Console.WriteLine("How much?");
                    choosenitem = new SugarCube();
                    break;
               case "IceCube":
                    Console.WriteLine("How many?");
                   choosenitem = new IceCube();
                    break;
                case "Cup":
                    Console.WriteLine("How many?");
                    choosenitem = new Cup();
                    break;
                default:
                    {
                        Console.WriteLine("Please Try again");
                        break;
                    }

            }

            if (choosenitem == null)//use function, will not return unless something is choosen
            {
                PurchaseItems();
            }

            itemInput = null;
            return choosenitem;
            
        }



        public static void DisplayNumberofDays(int numberofDays)
        {
            Console.WriteLine(numberofDays + "Days");
        }
    }
}
