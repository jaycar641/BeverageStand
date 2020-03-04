using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    
    class Store 
    {


        public double currentMoney; 
        public int currentLemons;
        public int currentIceCubes;
       public int currentCups;
        public int currentSugar;

        public void Startg(Player StorePlayer) 
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
            Item MenuItem;
            do
            {
                MenuItem = UserInterface.PurchaseItems();
            } while (isValidItem(MenuItem) == false);
            return MenuItem;
        }

        public bool isValidItem(Item item)
        {
            if ( item == null && item.name != "Start")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public int SetMenu()//take
        
        {
            try
            {
                int inventoryAdd = int.Parse(Console.ReadLine());
                return inventoryAdd;
            }
            catch
            {
                return 0;
            }
        }

    }










}





