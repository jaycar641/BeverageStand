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
        double weeklyReceipts= 0;
        double weeklyExpenses = 0;

        public void start()
        {
          

            int daysInbusiness = UserInterface.DisplayWelcome();
            IsValid(daysInbusiness);
            player1.name = UserInterface.DisplayName();
           

            for (int i = 1; i < daysInbusiness; i++)
            {
                Day day = new Day();
                day.name = i;
                days.Add(day);

            } 

            foreach (Day startDay in days) 
            {


                
                Console.WriteLine("Welcome to the Lemonade Store");
                StoreClass.start(player1);

                for (int i = 0; i < 4; i++) 
                {
                    Item purchasedItem = StoreClass.MenuPrompt();
                    int amountPurchased = StoreClass.SetMenu(purchasedItem, player1);

                    for (int x = 0; x < amountPurchased; x++)
                    {
                        switch (purchasedItem.name) 
                        {
                            case "Cup":
                                player1.PlayerInventory.cups.Add(new Cup(1));
                                player1.PlayerWallet.SetMoney(.10);
                                weeklyExpenses += .10;
                                break;
                            case "Lemon":
                                player1.PlayerInventory.lemons.Add(new Lemon(1));
                                player1.PlayerWallet.SetMoney(.20);
                                weeklyExpenses += .20;
                                break;
                            case "Ice Cube":
                                for (int j = 0; j <= 9; j++)
                                {
                                    player1.PlayerInventory.icecubes.Add(new IceCube(1));
                                }
                                player1.PlayerWallet.SetMoney(1.00);
                                weeklyExpenses += 1.00;
                                break;
                            case "Sugar":
                                player1.PlayerInventory.sugarcubes.Add(new SugarCube(1));
                                player1.PlayerWallet.SetMoney(.12);
                                weeklyExpenses += .12;
                                break;

                        }



                    }
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

                RunSimulation(player1, startDay);


            }

            Console.WriteLine(player1.name + " Your weekly profit: " + (weeklyReceipts-weeklyExpenses));
           


        }


        public void RunSimulation(Player player, Day day)
        {
            int timeHour = 0;
            double totalpopulatorVote = 0;
            int totalCustomers = 0;
            int totalPurchases = 0;
            int totalPitchers = CountPitcher(player1); 


            for (int i = 0; i < 9; i++) 
            {
                timeHour += i;
                int purchasingCustomers = 0;
                int dailyCustomers = 0;
                
                Console.WriteLine("Day " + day.name + " Hour " + i + " Weather " + day.DayWeather.condition + " Temperature " + day.GetTemperature() + " Wallet " + player1.PlayerWallet.GetMoney()); //userinterface

                Random customers = new Random();
                int amountCustomers = customers.Next(8, 20);
                
                for (int j = 0; j <= amountCustomers -1; j++)
                {
                    Customer customer = new Customer(day.DayWeather.condition, day.GetTemperature(), player1.PlayerRecipe.pricePerCup);
                    if (customer.doesPurchase == true)
                    {
                        player1.PlayerPicther.cupsleftInPitcher--;
                        player1.PlayerWallet.SetMoney(-player1.PlayerRecipe.pricePerCup);
                        player1.BusinessProfits += (player1.PlayerRecipe.pricePerCup);
                        weeklyReceipts += player1.BusinessProfits;
                        purchasingCustomers += 1;
                        
                    }

                    if (player1.PlayerPicther.cupsleftInPitcher == 0)
                    {
                        for(int k = 0; k <player1.PlayerRecipe.amountofLemons -1; k++)
                        {
                            if (player1.PlayerRecipe.amountofLemons >= player1.PlayerInventory.lemons.Count)
                            {
                                Console.WriteLine("SOLD OUT");
                                Console.WriteLine("Amount of people " + amountCustomers + " Purchases " + purchasingCustomers);
                                totalCustomers += amountCustomers;
                                totalPurchases += purchasingCustomers;
                                return;
                                
                            }
                            else
                            {
                                player1.PlayerInventory.lemons.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < player1.PlayerRecipe.amountogSugarCubes - 1; k++)
                        {
                            if (player1.PlayerRecipe.amountogSugarCubes >= player1.PlayerInventory.sugarcubes.Count)
                            {
                                Console.WriteLine("SOLD OUT");

                                Console.WriteLine("Amount of people " + amountCustomers + " Purchases " + purchasingCustomers);
                                totalCustomers += amountCustomers;
                                totalPurchases += purchasingCustomers;
                                return;
                            }
                            else
                            {
                                player1.PlayerInventory.sugarcubes.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < player1.PlayerRecipe.amountOfIceCubes - 1; k++)
                        {
                            if (player1.PlayerRecipe.amountOfIceCubes >= player1.PlayerInventory.icecubes.Count)
                            {
                                Console.WriteLine("SOLD OUT");
                                Console.WriteLine("Amount of people " + amountCustomers + " Purchases " + purchasingCustomers);
                                totalCustomers += amountCustomers;
                                totalPurchases += purchasingCustomers;
                                return;
                            }
                            else
                            {
                                player1.PlayerInventory.icecubes.RemoveAt(k);
                            }
                        }

                        totalPitchers--;
                        player1.PlayerPicther.cupsleftInPitcher = 12;

                    }

                   
                    Console.ReadLine();

                    totalCustomers += amountCustomers;
                    totalPurchases += purchasingCustomers;
                    Console.WriteLine("Amount of people " + amountCustomers + " Purchases " + (totalPurchases += purchasingCustomers));

                    amountCustomers = 0;

                }

                
               
            }  

            Console.WriteLine(player1.name + " Total Customers " + totalCustomers + " Amount of Purchases " + totalPurchases + " Profit " + player1.BusinessProfits);
            player1.BusinessProfits = 0;

        }










        public int CountPitcher(Player player)
        {

            int pitchers = 0;
            int lemons = 0;
            int sugar = 0;
            int ice = 0;





            do
            {
                for (int j = 0; j <= player.PlayerRecipe.amountofLemons - 1; j++)
                {
                    lemons += 1;
                }

                for (int j = 0; j <= player.PlayerRecipe.amountOfIceCubes - 1; j++)

                {

                    ice += 1;
                }

                for (int j = 0; j <= player.PlayerRecipe.amountogSugarCubes - 1; j++)
                {
                    sugar += 1;
                }


                pitchers++;
            } while (ice <= player1.PlayerInventory.icecubes.Count && sugar <= player1.PlayerInventory.sugarcubes.Count && lemons <= player1.PlayerInventory.lemons.Count);
                
            return pitchers;
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


