using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class IceCube:Item
    {
        public IceCube(int amount)
        {
            name = "Ice Cube";
            this.amount += amount;
        }
    }
}
