using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
     class UserInterface
    {

        public static int DisplayWelcome()
        {
            int numberofDays = 0;
            do
            {
                Console.WriteLine("Welcome to Lemonade Stand.  You can choose 7, 14, 21 for the amount of time that your in business" + "\n You will have control over the price, recipe, inventory, and purchasing supplies.");
                Console.WriteLine("How Many Days would you like to play?");
                
            try{
                numberofDays = int.Parse(Console.ReadLine());
            }
               
           catch(FormatException  ex)
           {
            Console.Write("Not a valid format. Please try again.");
           }
                
        
            } while (validEntry(numberofDays) == false );
 
            return numberofDays;

        }
         
         public static bool validEntry (int days) {

                 switch(days) {

                     case 7:
                         return true;
                        break;
                     case 14:
                        return true;
                         break;
                     case 21:
                        return true;
                        break;
                     default:
                         return false;
                         break;
                        
                 }
             
         }

            
            public static string DisplayName()
            {
                Console.WriteLine("What is your name?");
                string name = Console.ReadLine();
                return name;
            }

         public static void DisplayMenu(double currentMoney, int currentLemons, int currentIceCubes, int currentCups, int currentSugars)
        {
            Console.WriteLine("You currently have: " + "\n" + "Cups: " + currentCups + "\n" + "Lemons: " + currentLemons + "\n" + "IceCubes: " + currentIceCubes + "\n"+ "Sugar " + currentSugars + "\n" + "Money: " + currentMoney + "\n");
             Console.ReadLine();
            
        }

        public static void DisplayRecipe(String[] recipe, Recipe RecipeClass)
        {

            int[] recipeAmount = new int[3];
                recipeAmount[0] = RecipeClass.amountofLemons;
                recipeAmount[1] = RecipeClass.amountogSugarCubes;
                recipeAmount[2] = RecipeClass.amountOfIceCubes;
            
            double pricePerCup = RecipeClass.pricePerCup;
            ////prints array as menu

            for (int i = 0; i < recipeAmount.Length; i++)
            {
                Console.WriteLine("Per Pitcher: " + recipe[i] + " " + recipeAmount[i]);
            }

            Console.WriteLine("Price of Cups: $" + pricePerCup);



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

        public static string CashDisplay(double currentMoney) 
        {
            return Convert.ToString(currentMoney);
        }
         
        public static Item PurchaseItems ()
        {
            Item choosenitem = null;

                        
                
                string itemInput = Console.ReadLine();
           

                switch (itemInput)
                {
                    case "Lemon":
                    case "lemon":
                    case "L":
                    case "l":                        
                        choosenitem = new Lemon();

                        break;
                    case "Sugar":
                    case "sugar":
                    case "S":
                    case "s":
                        choosenitem = new SugarCube();
                        break;
                    case "Ice Cube":
                    case "ice cube":
                    case "I":
                    case "i":

                        choosenitem = new IceCube();
                        break;
                    case "Cup":
                    case "cup":
                    case "C":
                    case "c":

                        choosenitem = new Cup();
                        break;
                    case "Start":
                    case "start":
                        choosenitem = new Lemon();
                        choosenitem.name = "Start";
                        
                        break;

                    default:
                        {
                            Console.WriteLine("Please Try again");
                            choosenitem = null;
                            break;
                        }

                }
                    //if (choosenitem == null)//use function, will not return unless something is choosen
            //{
            //    PurchaseItems();
            //}

            //itemInput = null;
            return choosenitem;
            
        }
         

       public static int tasteRatio(Player player, Day day)
        {
            int tastenumber = 0;
            if (day.DayWeather.condition == "Sunny" && day.GetTemperature() >+ 90 && (player.PlayerRecipe.amountofLemons)/(player.PlayerRecipe.amountogSugarCubes) == 2)
            {
                tastenumber += 2;

            }
            return tastenumber;
        }



        public static void DisplayNumberofDays(int numberofDays)
        {
            Console.WriteLine(numberofDays + "Days");
        }

        

    }
}
