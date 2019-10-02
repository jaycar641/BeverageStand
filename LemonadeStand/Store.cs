using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store //this is called to set the current values of the players inventory.
    {

        // Player StorePlayer = new Player();

        public Store()
        {

        }
        public void start(Player StorePlayer) //player1 is passed through
        {

            double currentMoney = StorePlayer.PlayerWallet.GetMoney(); //change to get property
            int currentLemons = StorePlayer.PlayerInventory.lemons.Count;
            int currentIceCubes = StorePlayer.PlayerInventory.icecubes.Count;
            int currentCups = StorePlayer.PlayerInventory.cups.Count;
            int currentSugar = StorePlayer.PlayerInventory.sugarcubes.Count;
            // StorePlayer.PlayerPicther = " ";
            UserInterface.DisplayMenu(currentMoney, currentLemons, currentIceCubes, currentCups, currentSugar);
            
        }

        public Item MenuPrompt()
        {

            Item MenuItem = UserInterface.PurchaseItems(); // sets amounts for 4 items 


            return MenuItem;
        }

        
        public int SetMenu(Item item, Player player1Store)
        
        {
            int inventoryAdd = int.Parse(Console.ReadLine()); //when asked how much 
            item.amount += inventoryAdd;
            //calculates the amount and puts it in the items amount
            // Console.WriteLine(item.amount);

            //switch (item.name)
            // {
            //  case "Lemon":
            //creating actual lemons to be added to lists

            //    for (int i = 0; i < inventoryAdd; i++)
            //  {
            //  player1Store.PlayerInventory.lemons.Add(new Lemon());
            //}
            //  break;

            //case "IceCube":
            //creating actual lemons to be added to lists

            //  for (int i = 0; i < inventoryAdd; i++)
            //{
            //  player1Store.PlayerInventory.icecubes.Add(new IceCube());
            //}
            //break;


            //case "Sugar":
            //creating actual lemons to be added to lists

            //  for (int i = 0; i < inventoryAdd; i++)
            //{
            //  player1Store.PlayerInventory.sugarcubes.Add(new SugarCube());
            //}
            //                break;

            //          case "Cup":
            //creating actual lemons to be added to lists

            //             for (int i = 0; i < inventoryAdd; i++)
            //           {
            //             player1Store.PlayerInventory.cups.Add(new Cup());
            //       }
            //     break;
            //default:
            //  {
            //    Console.WriteLine("Please select an item");
            //  SetMenu(item, player1Store);
            //break;
            //                }

            return inventoryAdd;
        }

     //   inventoryAdd = 0;
       //     return item;
    }










}





