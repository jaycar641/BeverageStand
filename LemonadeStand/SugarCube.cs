﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SugarCube:Item
    {
        public SugarCube(int amount)
        {
            this.amount += amount;
            name = "Sugar";
        }
    }
}
