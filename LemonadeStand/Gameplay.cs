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
                for (int i = 0; i < 4;  i++) {
                    SetMenu(UserInterface.PurchaseItems(), player1); // sets amounts for 4 items 
                }



                //recipe

                RecipeClass.start();








            }






        }
        public void SetMenu(Item item, Player player1inventory)
        {
            int inventoryAdd = int.Parse(Console.ReadLine()); //Reads menu amount


           
                item.amount += inventoryAdd;        //calculates the amount and puts it in the items amount
               // Console.WriteLine(item.amount);

            switch (item.name)
            {
                case "Lemon":
                      //creating actual lemons to be added to lists
                      
                    for (int i = 0; i < inventoryAdd; i++ ) 
                    {
                        player1.PlayerInventory.lemons.Add(new Lemon());
                    }
                    break;

                case "IceCube":
                    //creating actual lemons to be added to lists

                    for (int i = 0; i < inventoryAdd; i++)
                    {
                        player1.PlayerInventory.icecubes.Add(new IceCube());
                    }
                    break;


                case "Sugar":
                    //creating actual lemons to be added to lists

                    for (int i = 0; i < inventoryAdd; i++)
                    {
                        player1.PlayerInventory.sugarcubes.Add(new SugarCube());
                    }
                    break;

                case "Cup":
                    //creating actual lemons to be added to lists

                    for (int i = 0; i < inventoryAdd; i++)
                    {
                        player1.PlayerInventory.cups.Add(new Cup());
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Please select an item");
                        SetMenu(item, player1inventory);
                        break;
                    }


            }

            inventoryAdd = 0;

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
