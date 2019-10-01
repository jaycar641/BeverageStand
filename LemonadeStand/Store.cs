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
            // StorePlayer.PlayerPicther = " ";
           UserInterface.DisplayMenu(currentMoney, currentLemons, currentIceCubes, currentCups);

        }

        

    }
}
