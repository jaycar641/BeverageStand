using System;
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
        public double pricePerCup = 0;


        public Recipe()
        {
            amountOfIceCubes = 0;
            amountofLemons = 0;
            amountogSugarCubes = 0;
            pricePerCup = 0;

        }

        public int AskRecipe(string RecipeItem)
        {
            
                Console.WriteLine("How much " + RecipeItem);
                int recipeAmount = int.Parse(Console.ReadLine()); 

            //error handling
            return recipeAmount;
        }

        public double AskPrice(string RecipeItem)
        {
            Console.WriteLine("How much " + RecipeItem);
            double recipeAmount = double.Parse(Console.ReadLine());
            return recipeAmount;
        }




    }
}
