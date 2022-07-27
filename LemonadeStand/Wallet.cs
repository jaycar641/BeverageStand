using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Wallet
    {
        private double money = 0;

        public Wallet()
        {
        
        }

        //set money and get money functions replaced by this
        public double Money
        {
            get
            {
                money = Math.Round(money, 2);
                return money;
            }

            set
            {
                
                money = value;
            }

        }
        
    
    }
}
