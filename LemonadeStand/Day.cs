﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public int name;
        public Weather DayWeather = new Weather();
        public Customer LocalCustomers = new Customer();
    }
}