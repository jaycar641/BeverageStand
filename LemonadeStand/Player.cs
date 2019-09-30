using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {

        public string name; //Private or public
        public Inventory PlayerInventory = new Inventory();
        public Wallet PlayerWallet = new Wallet();
        public Recipe PlayerRecipe = new Recipe();
        public Pitcher PlayerPicther = new Pitcher();
        public double BusinessProfits;


    }
}
