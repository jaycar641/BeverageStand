using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store 
    {


        double currentMoney; 
        int currentLemons;
        int currentIceCubes;
        int currentCups;
        int currentSugar;

        public void start(Player StorePlayer) 
        {

            currentMoney += StorePlayer.PlayerWallet.GetMoney(); 
            currentLemons += StorePlayer.PlayerInventory.lemons.Count;
            currentIceCubes += StorePlayer.PlayerInventory.icecubes.Count;
            currentCups += StorePlayer.PlayerInventory.cups.Count;
            currentSugar += StorePlayer.PlayerInventory.sugarcubes.Count;
            UserInterface.DisplayMenu(currentMoney, currentLemons, currentIceCubes, currentCups, currentSugar);
            
        }

        public Item MenuPrompt()
        {

            Item MenuItem = UserInterface.PurchaseItems(); 

            return MenuItem;
        }

        
        public int SetMenu(Item item, Player player1Store)
        
        {
            int inventoryAdd = int.Parse(Console.ReadLine()); 
            item.amount += inventoryAdd;
            return inventoryAdd;
        }

    }










}





