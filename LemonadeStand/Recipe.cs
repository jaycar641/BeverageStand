﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {

        public int amountofLemons;
        public int amountogSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;

        public void start()
        {

            amountOfIceCubes = 0;
            amountofLemons = 0;
            amountogSugarCubes = 0;
            pricePerCup = 0;

        }

        public int AskRecipe(string RecipeItem)
        {
            
                Console.WriteLine("What would you like to set the " + RecipeItem );
                int recipeAmount = int.Parse(Console.ReadLine());


            return recipeAmount;
        }




    }
}
