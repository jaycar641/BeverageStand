using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Gameplay
    {
        Store StoreClass = new Store();
        Player player1 = new Player();
        List<Day> days = new List<Day>();
        int CurrentDay;

        public void start()
        {
            //////Need to use Get set properties, constructors, and 

            int daysInbusiness = UserInterface.DisplayWelcome();//returns the number of days
            IsValid(daysInbusiness);
            player1.name = UserInterface.DisplayName();
            //before the gameloop starts the wallet is set to 20, use the get set property




            for (int i = 1; i < daysInbusiness; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } //adding those days to the list


            foreach (Day startDay in days) //the 
            {


                //store
                Console.WriteLine("Welcome to the Lemonade Store");
                StoreClass.start(player1);

                for (int i = 0; i < 4; i++) //takes all the items and prompts how many
                {
                    Item purchasedItem = StoreClass.MenuPrompt();
                    int amountPurchased = StoreClass.SetMenu(purchasedItem, player1);

                    for (int x = 0; x < amountPurchased; x++)
                    {//its going to add the amount of items
                        switch (purchasedItem.name) // make another function
                        {
                            case "Cup":
                                player1.PlayerInventory.cups.Add(new Cup());
                                player1.PlayerWallet.SetMoney(.10);
                                break;
                            case "Lemon":
                                player1.PlayerInventory.lemons.Add(new Lemon());
                                player1.PlayerWallet.SetMoney(.20);
                                break;
                            case "IceCube":
                                player1.PlayerInventory.icecubes.Add(new IceCube());
                                player1.PlayerWallet.SetMoney(4.00);
                                break;
                            case "Sugar":
                                player1.PlayerInventory.sugarcubes.Add(new SugarCube());
                                player1.PlayerWallet.SetMoney(.12);
                                break;

                        }
                    }///for each item it takes the amount purchased and adds it
                    purchasedItem = null;
                }

                Console.WriteLine("Wallet: " + player1.PlayerWallet.GetMoney());
                Console.WriteLine("Forecast " + startDay.DayWeather.condition);
                Console.WriteLine("Temperature " + startDay.DayWeather.temperature);

                //recipe
                Console.WriteLine("Set the Recipe per Pitcher and Price per Cup");

                string[] recipeItems = new string[]
                {"Lemons", "Sugar Cubes", "Ice cubes", "Price per cup" };
                player1.PlayerRecipe.amountofLemons = player1.PlayerRecipe.AskRecipe(recipeItems[0]);
                player1.PlayerRecipe.amountogSugarCubes = player1.PlayerRecipe.AskRecipe(recipeItems[1]);
                player1.PlayerRecipe.amountOfIceCubes = player1.PlayerRecipe.AskRecipe(recipeItems[2]);
                player1.PlayerRecipe.pricePerCup = player1.PlayerRecipe.AskRecipe(recipeItems[3]);

                UserInterface.DisplayRecipe(recipeItems, player1.PlayerRecipe);

                RunSimulation()


            }




        }




        public void RunSimulation()
        {

        }
        public static bool IsValid (int Input)
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
