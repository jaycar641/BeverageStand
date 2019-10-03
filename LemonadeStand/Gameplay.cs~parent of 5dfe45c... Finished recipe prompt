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
        Recipe RecipeClass = new Recipe();
        Player player1 = new Player();
        List<Day> days = new List<Day>();
        int CurrentDay;

        public void start()
        {

            int daysInbusiness = UserInterface.DisplayWelcome();//returns the number of days
            IsValid(daysInbusiness);
            player1.name = UserInterface.DisplayName();
            player1.PlayerWallet.SetMoney(20); //before the gameloop starts the wallet is set to 20, use the get set property
            



            for (int i = 1; i < daysInbusiness; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } //adding those days to the list


            foreach(Day startDay in days) //the 
            {


                //store
                Console.WriteLine("Welcome to the Lemonade Store");
                StoreClass.start(player1);
                
                for (int i = 0; i < 4; i++) //amount of items
                {
                    Item purchasedItem = StoreClass.MenuPrompt();
                    int amountPurchased = StoreClass.SetMenu(purchasedItem, player1);

                    for (int x = 0; x < amountPurchased; x++)
                    {//its going to add the amount of items
                        switch (purchasedItem.name) // make another function
                        {
                            case "Cup":
                                player1.PlayerInventory.cups.Add(new Cup());
                                break;
                            case "Lemon":
                                player1.PlayerInventory.lemons.Add(new Lemon());
                                break;
                            case "IceCube":
                                player1.PlayerInventory.icecubes.Add(new IceCube());
                                break;
                            case "Sugar":
                                player1.PlayerInventory.sugarcubes.Add(new SugarCube());
                                break;

                        }
                    }
                    purchasedItem = null;
                }


                //recipe
                RecipeClass.start();
                for (int i = 0; i < 4; i++)
                {
                   int iceCube  = UserInterface.ChangeIceCubes();
                    RecipeClass.amountOfIceCubes += iceCube;

                }








            }






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
