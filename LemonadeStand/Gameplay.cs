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
        Player player1 = new Player();
        List<Day> days = new List<Day>();
        int CurrentDay;

        public void start()
        {

            int daysInbusiness = UserInterface.DisplayWelcome();//returns the number of days
            IsValid(daysInbusiness);
            player1.name = UserInterface.DisplayName();
            player1.PlayerWallet.SetMoney(20); //before the gameloop starts the wallet is set to 0, use the get set property
            



            for (int i = 1; i < daysInbusiness; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } //adding those days to the list


            foreach(Day startDay in days) //the 
            {


                    //store
 
                StoreClass.start(player1);
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
