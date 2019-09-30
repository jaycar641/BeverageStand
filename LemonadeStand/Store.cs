using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store:Player //this is called to set the current values of the players inventory.
    {

        Player StorePlayer = new Player();
        
        public void start()
        {
            StorePlayer.PlayerInventory = "";
            StorePlayer.PlayerPicther = "";
            StorePlayer.PlayerRecipe = "";
            StorePlayer.PlayerWallet = ""


        }
        
    }
}
