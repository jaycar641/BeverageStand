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


        public double SetMoney(double money)
        {
            this.money = money;
            return this.money;
        }
        public double GetMoney()
        {

            return money;
        }
    }
}
