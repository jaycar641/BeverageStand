﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon:Item
    {
        public Lemon(int amount)
        {
            name = "Lemon";
            this.amount += amount;
        }
    }
}
