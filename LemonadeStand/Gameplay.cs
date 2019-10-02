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
            player1.PlayerWallet.SetMoney(20); //before the gameloop starts the wallet is set to 0, use the get set property
            



            for (int i = 1; i < daysInbusiness; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } //adding those days to the list


            foreach(Day startDay in days) //the 
            {


                    //store
 
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
            int inventoryAdd = Console.Read(); //Reads menu amount


            for (int i = 1; i <+ inventoryAdd; i++)
            {
                item.amount += inventoryAdd;        //calculates the amount and puts it in the items amount
               // Console.WriteLine(item.amount);

            } //adding those days to the list

            switch (item.name)
            {
                case "lemon":
                      //creating actual lemons to be added to lists
                      
                    for (int i = 0; i < inventoryAdd; i++ ) 
                    {
                        Lemon menuLemon = new Lemon();
                        player1.PlayerInventory.lemons.Add(menuLemon);
                    }
                    break;

                case "ice":
                    //creating actual lemons to be added to lists

                    for (int i = 0; i < inventoryAdd; i++)
                    {
                        IceCube menuice = new IceCube();
                        player1.PlayerInventory.icecubes.Add(menuice);
                    }
                    break;


                case "sugar":
                    //creating actual lemons to be added to lists

                    for (int i = 0; i < inventoryAdd; i++)
                    {
                        SugarCube menusugar = new SugarCube();
                        player1.PlayerInventory.sugarcubes.Add(menusugar);
                    }
                    break;

                case "cups":
                    //creating actual lemons to be added to lists

                    for (int i = 0; i < inventoryAdd; i++)
                    {
                        Cup menucup = new Cup();
                        player1.PlayerInventory.cups.Add(menucup);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Please select an item");
                        SetMenu(item, player1inventory);
                        break;
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
                start();
            }

           return InputValid;
        }
    }
}
