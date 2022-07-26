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
            int recipeAmount = 0;
                Console.WriteLine("How much " + RecipeItem);
            try {
                recipeAmount = int.Parse(Console.ReadLine()); 
                }
            catch (FormatException e) {
                Console.WriteLine("Not a valid number");
                AskRecipe(RecipeItem);
            }
            
            if(RecipeItem == "Ice Cube" && recipeAmount <= 15) 
            {
                return recipeAmount;
                
            }
            else if (RecipeItem == "Ice Cube" && recipeAmount > 15) {
            Console.WriteLine("Cannot have more than 15 ice cubes in a recipe");
                AskRecipe(RecipeItem);
            }
            else{

                return recipeAmount;
            }
        return recipeAmount; 
        
        }

        public double AskPrice(string RecipeItem)
        {
            Console.WriteLine("How much do you want to charge");
           double recipeAmount = 0;
            try {
            recipeAmount = double.Parse(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("This is not valid");
                AskPrice(RecipeItem);
            }
                return recipeAmount;
            
        }




    }
}
