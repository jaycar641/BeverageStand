﻿using System;
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
                numberofDays = int.Parse(Console.ReadLine());
            } while (IsValid(numberofDays) == false);

            return numberofDays;

        }

            
            public static string DisplayName()
            {
                Console.WriteLine("What is your name?");
                string name = Console.ReadLine();
                return name;
            }

        public static void DisplayRecipe(String[] recipe, Recipe RecipeClass)
        {
            int[] recipeAmount = new int[3];
            for (int i = 0; i < recipeAmount.Length; i++) //adds recipe amounts to an array
            {
                recipeAmount[0] = RecipeClass.amountofLemons;
                recipeAmount[1] = RecipeClass.amountogSugarCubes;
                recipeAmount[2] = RecipeClass.amountOfIceCubes;
            }

            double pricePerCup = RecipeClass.pricePerCup;
            ////prints array as menu

            for (int i = 0; i < recipeAmount.Length; i++)
            {
                Console.WriteLine("Per Pitcher: " + recipe[i] + " " + recipeAmount[i]);
            }

            Console.WriteLine("Price of Cups: $" + pricePerCup);



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
            Console.WriteLine("Sugar " + currentSugars);
            Console.WriteLine("\n");
            Console.WriteLine("Money: " + currentMoney);
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

        public static string CashDisplay(double currentMoney) 
        {
            return Convert.ToString(currentMoney);
        }
        public static Item PurchaseItems ()
        {
            Item choosenitem = null;

            do
            {
                Console.WriteLine("Enter the item you like to purchase: Lemon, Sugar, Ice Cube, Cup....Enter Start to Skip");
                string itemInput = Console.ReadLine();
           

                switch (itemInput)
                {
                    case "Lemon":
                        Console.WriteLine("How many? .20$ each");
                        choosenitem = new Lemon(0);
                        break;
                    case "Sugar":
                        Console.WriteLine("How much? .12$ each");
                        choosenitem = new SugarCube(0);
                        break;
                    case "Ice Cube":
                        Console.WriteLine("How many? 1.00$ for 10");
                        choosenitem = new IceCube(0);
                        break;
                    case "Cup":
                        Console.WriteLine("How many? .10$");
                        choosenitem = new Cup(0);
                        break;
                    case "Start":
                        choosenitem = new Lemon(0);
                        choosenitem.name = "Start";
                        break;

                    default:
                        {
                            Console.WriteLine("Please Try again");
                            choosenitem = null;
                            break;
                        }

                }
            } while (choosenitem == null);
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

        public static bool IsValid(int Input)
        {
            bool InputValid = false;

            if (Input == 7)
            {
                InputValid = true;
            }
            else if (Input == 14)
            {
                InputValid = true;
            }

            else if (Input == 21)
            {
                InputValid = true;
            }

            else
            {
                InputValid = false;
                Console.WriteLine("Invalid Input");
            }

            return InputValid;
        }

    }
}
