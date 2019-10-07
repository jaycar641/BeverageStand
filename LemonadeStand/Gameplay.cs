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
        Player player1 = new Player();
        List<Day> days = new List<Day>();
        int CurrentDay;
        double weeklyProfits = 0;

        public void start()
        {
            //////Need to use Get set properties, constructors, and 

            int daysInbusiness = UserInterface.DisplayWelcome();//returns the number of days
            IsValid(daysInbusiness);
            player1.name = UserInterface.DisplayName();
            //before the gameloop starts the wallet is set to 20, use the get set property

            for (int i = 1; i < daysInbusiness; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } //adding those days to the list


            foreach (Day startDay in days) //the 
            {


                //store
                Console.WriteLine("Welcome to the Lemonade Store");
                StoreClass.start(player1);

                for (int i = 0; i < 4; i++) //takes all the items and prompts how many
                {
                    Item purchasedItem = StoreClass.MenuPrompt();
                    int amountPurchased = StoreClass.SetMenu(purchasedItem, player1);

                    for (int x = 0; x < amountPurchased; x++)
                    {//its going to add the amount of items
                        switch (purchasedItem.name) // make another function
                        {
                            case "Cup":
                                player1.PlayerInventory.cups.Add(new Cup(1));
                                player1.PlayerWallet.SetMoney(.10);
                                break;
                            case "Lemon":
                                player1.PlayerInventory.lemons.Add(new Lemon(1));

                                player1.PlayerWallet.SetMoney(.20);
                                break;
                            case "IceCube":
                                player1.PlayerInventory.icecubes.Add(new IceCube(1));
                                player1.PlayerWallet.SetMoney(4.00);
                                break;
                            case "Sugar":
                                player1.PlayerInventory.sugarcubes.Add(new SugarCube(1));
                                player1.PlayerWallet.SetMoney(.12);
                                break;

                        }
                    }///for each item it takes the amount purchased and adds it
                    purchasedItem = null;
                }

                Console.WriteLine("Wallet: " + player1.PlayerWallet.GetMoney());
                Console.WriteLine("Forecast " + startDay.DayWeather.condition);
                Console.WriteLine("Temperature " + startDay.DayWeather.temperature);

                //recipe
                Console.WriteLine("Set the Recipe per Pitcher and Price per Cup");

                string[] recipeItems = new string[]
                {"Lemons", "Sugar Cubes", "Ice cubes", "Price per cup" };
                player1.PlayerRecipe.amountofLemons = player1.PlayerRecipe.AskRecipe(recipeItems[0]);
                player1.PlayerRecipe.amountogSugarCubes = player1.PlayerRecipe.AskRecipe(recipeItems[1]);
                player1.PlayerRecipe.amountOfIceCubes = player1.PlayerRecipe.AskRecipe(recipeItems[2]);
                player1.PlayerRecipe.pricePerCup = player1.PlayerRecipe.AskPrice(recipeItems[3]);

                UserInterface.DisplayRecipe(recipeItems, player1.PlayerRecipe);
                Console.WriteLine("Press Enter to begin the Game!");
                Console.ReadLine();
                // Pitcher GamePitcher = MakePitcher(player1);  -maniuplate the players pitcher


                RunSimulation(player1, startDay);


            }


        }
    

        public void RunSimulation(Player player, Day day)
        {
            int timeHour = 0;
            double totalpopulatorVote = 0;
            int totalCustomers = 0;
            int totalPurchases = 0;
            //business profits

            //figure out which varibles are set outside the hour loop for results

            //total amount of purchases 
            //total amount of customers

            for (int i = 0; i < 9; i++) //hour loop
            {
                timeHour += i;
                int purchasingCustomers = 0;
                int popularVote = 0;
                Console.WriteLine("Day " + day.name + " Hour " + timeHour + " Weather " + day.DayWeather.condition + " Temperature " + day.GetTemperature() + " Wallet " + player1.PlayerWallet); //userinterface

                Random customers = new Random();
                int amountCustomers = customers.Next(8, 20);
                for (i = 0; i <= amountCustomers; i++)
                {
                    Customer customer = new Customer(day.DayWeather.condition, day.GetTemperature(), player1.PlayerRecipe.pricePerCup);
                    if (customer.doesPurchase == true)
                    {
                        player1.PlayerPicther.cupsleftInPitcher -= 1;
                        player1.PlayerWallet.SetMoney(-player1.PlayerRecipe.pricePerCup);
                        player1.BusinessProfits += (player1.PlayerRecipe.pricePerCup);
                        weeklyProfits += player1.PlayerRecipe.pricePerCup;
                        purchasingCustomers += 1;
                        customer.TasteRatio(UserInterface.tasteRatio(player1, day));
                        
                        bool likeDrink = customer.TasteRatio(customer.tasteRatio); //there should be  certain range of recipe that people like in taste ratio, eventually pass through weather
                        if (likeDrink == true)
                        {
                            popularVote += 1;

                        }
                    }
                    


                }



                Console.WriteLine("Amount of people " + amountCustomers + "Purchases " + purchasingCustomers);
                totalCustomers += amountCustomers;
                totalPurchases += purchasingCustomers;
                totalpopulatorVote += popularVote;
            }  //creates a number of customers     user stories, encapsulation userface, solid, case structure, check other assignments

            Console.WriteLine("Total Customers " + totalCustomers + "Amount of Purchases " +  totalPurchases + "Profit " + player1.BusinessProfits + "Overall Popularity " + totalpopulatorVote/totalPurchases);
            player1.BusinessProfits = 0;    
            
        }
        


    public Pitcher MakePitcher(Player player)
        {
            Pitcher GamePitcher = new Pitcher();

            
            int LemonPitcher = player1.PlayerInventory.lemons.Count - (player1.PlayerInventory.lemons.Count % player1.PlayerRecipe.amountofLemons);
            int SugarCubePitcher = player1.PlayerInventory.sugarcubes.Count - (player1.PlayerInventory.sugarcubes.Count % player1.PlayerRecipe.amountogSugarCubes);
            int IceCubePictcher = player1.PlayerInventory.icecubes.Count - (player1.PlayerInventory.icecubes.Count % player1.PlayerRecipe.amountOfIceCubes);
            int cupPitcher = player1.PlayerInventory.cups.Count - (player1.PlayerInventory.cups.Count % player1.PlayerInventory.cups.Count);

            
            return GamePitcher;
        }



       
        public static bool IsValid (int Input)
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
            }

           return InputValid;
        }



    }
}


