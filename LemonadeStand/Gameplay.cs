using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Gameplay
    {
        Store StoreClass = new Store();
        Recipe RecipeClass = new Recipe();
        Player player1;
        List<Day> days = new List<Day>();
        int CurrentDay;

        public void start()
        {
            Console.WriteLine("Welcome to Lemonade Stand.  You can choose 7, 14, 21 for the amount of time that your in business" + "\n You will have control over the price, recipe, inventory, and purchasing supplies.");
            Console.WriteLine("How Many Days would you like to play?");
            int numberofDays = int.Parse(Console.ReadLine());
            IsValid(numberofDays);
            Console.WriteLine(numberofDays + " Days ");

            Console.WriteLine("What is your name?");
            player1.name = Console.ReadLine();
            



            for (int i = 1; i < numberofDays; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } //adding those days to the list


            foreach(Day startDay in days)
            {


                    //store

                StoreClass.start();
                //recipe

                RecipeClass.start();








            }






        }

        public bool IsValid (int Input)
        {
            bool InputValid = false;

            if (Input == 7)
            {
                InputValid = true;
            }
            else if (Input == 14)
            {
                InputValid = true;
            }

            else if (Input == 21)
            {
                InputValid = true;
            }

            else
            {
                InputValid = false;
                Console.WriteLine("Invalid Input");
                start();
            }

           return InputValid;
        }
    }
}
