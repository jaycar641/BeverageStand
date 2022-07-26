using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Gameplay
    {

        Player player1 = new Player();
        List<Day> days = new List<Day>();
        public int CurrentDay;
        //double weeklyReceipts= 0;
        public double weeklyExpenses = 0;
        public int dailyCustomers = 0;  //in one day
       public int dailyPurchases = 0;
       public int totalCustomers = 0;
       public int totalPurchases = 0;
       
        public void start()
        {         
            int daysInbusiness = UserInterface.DisplayWelcome();//returns the number of days

            player1.name = UserInterface.DisplayName();
            player1.PlayerWallet.Money += 20; //before the gameloop starts the wallet is set to 20, use the get set property
            
            for (int i = 1; i <= daysInbusiness; i++)
            {
                int dayName = i;
                Day day = new Day();
                day.name = dayName;
                days.Add(day);

            } //adding those days to the list
            
            Store StoreClass = new Store();   
            foreach (Day startDay in days) 
            {


                
                Console.WriteLine("Welcome to the Lemonade Store");
                StoreClass.Startg(player1);//Grabbing the current state of the player and displaying its inventory

                //for (int i = 0; i < 4; i++) 
                Item purchasedItem;
                do//loops for 1 item being purchases a certain amount of times
                {
                    purchasedItem = StoreClass.MenuPrompt(); //repeats purchase items untill finished
                        
                    int amountPurchased = StoreClass.howMany(purchasedItem); //takes input of amount of items
                    
                   player1 =  StoreClass.SetMenuItem(purchasedItem, amountPurchased); //sets the game instance of the player, with the store instance of the player, after spending the money
                    
                        Console.ReadLine();
                    double cost = amountPurchased * purchasedItem.cost;
                    ///ice cubes are 10 for a dollar 
                    weeklyExpenses += cost; 
                            
                    
                    Console.WriteLine("Money:" + player1.PlayerWallet.Money);

                } while (purchasedItem.name != "Start"); //end of purchase loop


                purchasedItem = null;

                Console.WriteLine("Forecast " + startDay.DayWeather.condition);
                Console.WriteLine("Temperature " + startDay.DayWeather.temperature + "\n");
                Console.WriteLine("Inventory: " + "\n"+ "Lemons: " + player1.PlayerInventory.lemons.Count + "\n" + "Sugar: " + player1.PlayerInventory.sugarcubes.Count + "\n" + "Ice Cubes: " + player1.PlayerInventory.icecubes.Count + "\n" + "Cups: " + player1.PlayerInventory.cups.Count + "\n");
                Console.ReadLine();
                //recipe
                Console.WriteLine("Set the Recipe per Pitcher and Price per Cup");

                string[] recipeItems = new string[]
                {"Lemons", "Sugar Cubes", "Ice cubes", "Price per cup" };
                ///should be a function and if already set then skip
                player1.PlayerRecipe.amountofLemons = player1.PlayerRecipe.AskRecipe(recipeItems[0]);
                player1.PlayerRecipe.amountogSugarCubes = player1.PlayerRecipe.AskRecipe(recipeItems[1]);
                player1.PlayerRecipe.amountOfIceCubes = player1.PlayerRecipe.AskRecipe(recipeItems[2]);
                player1.PlayerRecipe.pricePerCup = player1.PlayerRecipe.AskPrice(recipeItems[3]);

                UserInterface.DisplayRecipe(recipeItems, player1.PlayerRecipe);
                Console.WriteLine("Press Enter to begin the Game!");
                Console.ReadLine();

                player1 = RunSimulation(player1, startDay);


            }

            Console.WriteLine(player1.name + " Your weekly profit: " + player1.BusinessProfits + "Total Customers:" + totalCustomers + "Total Purchases:" + totalPurchases);
           


        }


        public Player RunSimulation(Player player, Day day)
        {
            int timeHour = 0;
            double totalpopulatorVote = 0;   
            int totalPitchers = CountPitcher(player);
            int hourlypurchasingCustomers = 0;


            for (int j = 1; j < 10; j++) //9 hours of gameplay
            {
                timeHour = j;
                
                Console.WriteLine("Day " + day.name + " Hour " + timeHour.ToString() + " Weather " + day.DayWeather.condition + " Temperature " + day.DayWeather.temperature + " Wallet " + player.PlayerWallet.Money); //userinterface

                Random customers = new Random();
                int hourlyCustomers = customers.Next(8, 20);
                
                for (int k = 0; k < hourlyCustomers; k++)//new amount of customers every hour that purchase
                {

                    Customer customer = new Customer(day.DayWeather.condition, day.GetTemperature(), player.PlayerRecipe.pricePerCup);
                    //each customer should return different

                    ///////////////////////////////////////////////////////////////////////////////////////////////////
                    ///
                    //profit update after a purchase
                    if (customer.doesPurchase == true)
                    {
                        player.PlayerPicther.cupsleftInPitcher--;

                        player.PlayerWallet.Money += player.PlayerRecipe.pricePerCup;
                        player.BusinessProfits += player.PlayerRecipe.pricePerCup;

                        hourlypurchasingCustomers += 1;  //only used if sold out
                        dailyPurchases++;
                        
                        Console.WriteLine("Cups in Pitcher" + player.PlayerPicther.cupsleftInPitcher + "Money"  + player.PlayerWallet.Money + "Business Profits" + player.BusinessProfits + "Purchasing Customers" +  hourlypurchasingCustomers + "Daily purchases" + dailyPurchases + "Amount of Students" + hourlyCustomers);
                        Console.ReadLine();
                    
                    }
                    
                    if(player.PlayerInventory.lemons.Count < player.PlayerRecipe.amountofLemons && player.PlayerInventory.icecubes.Count < 10 && player.PlayerInventory.sugarcubes.Count < player.PlayerRecipe.amountogSugarCubes)
                        {          
                       // add the amount of customers up untill that point       
                    dailyPurchases += hourlypurchasingCustomers; //add amount of purchases until that point
                    Console.WriteLine("SOLD OUT");
                     Console.WriteLine("Day amount of customers " + dailyCustomers + " Purchases today" + dailyPurchases);
                            return player;
                       }

                    //there has to be a pitcher check after each customer
                    if (player.PlayerPicther.cupsleftInPitcher == 0)
                    {
                        
                        for(int l = 0; l < player.PlayerRecipe.amountofLemons; l++){
                               try{
                                   player.PlayerInventory.lemons.RemoveAt(0);
                               }
                             catch(ArgumentOutOfRangeException e) {
                                 // sold out function, that returns the player
                                 Console.WriteLine("SOLD OUT");
                     Console.WriteLine("Day amount of customers " + dailyCustomers + " Purchases today" + dailyPurchases);
                                 return player; 
                             }
                        }

                        for(int m = 0; m < player.PlayerRecipe.amountogSugarCubes; m++) {
                                try 
                                {
                                    player.PlayerInventory.sugarcubes.RemoveAt(0);
                                }
                                catch (ArgumentOutOfRangeException e) {
                                    //sold out function, that returns the player
                                    Console.WriteLine("SOLD OUT");
                     Console.WriteLine("Day amount of customers " + dailyCustomers + " Purchases today" + dailyPurchases);
                                    return player; 
                                }
                        }
                        for(int n = 0; n < player.PlayerRecipe.amountOfIceCubes; n++ ) {
                            try{    
                            player.PlayerInventory.icecubes.RemoveAt(0);
                            }
                            catch(ArgumentOutOfRangeException e) {
                                //sold out function that returns the player
                                Console.WriteLine("SOLD OUT");
                     Console.WriteLine("Day amount of customers " + dailyCustomers + " Purchases today" + dailyPurchases);
                                return player;
                            }
                        }
                        Console.WriteLine(player.PlayerInventory.lemons.Count);
                        Console.ReadLine();
                        totalPitchers--;
                        player.PlayerPicther.cupsleftInPitcher = 12;
                    }


                    dailyCustomers++; 
                
                    ////if you run out after this customer
                        
                    
                 }//end of the hour
                hourlypurchasingCustomers = 0;
                Console.WriteLine("Loading hour...");
                Thread.Sleep(5000);
            } ///End of the day
            
            totalPurchases += dailyPurchases;
            totalCustomers += dailyCustomers;
            dailyCustomers = 0;
            dailyPurchases = 0;   
             return player;                     
                                  }
            
                                                
        public int CountPitcher(Player player)
        {

            int pitchers = 0;
            

            int lemonCount =  player.PlayerInventory.lemons.Count;
            int iceCubesCount =  player.PlayerInventory.icecubes.Count;
            int sugarcubesCount = player.PlayerInventory.sugarcubes.Count;
            
            do
            {
              
                 lemonCount -= player.PlayerRecipe.amountofLemons;
                iceCubesCount -= player.PlayerRecipe.amountOfIceCubes;
                 sugarcubesCount -= player.PlayerRecipe.amountogSugarCubes;
                pitchers++;
                
            } while ( lemonCount > player.PlayerRecipe.amountofLemons && iceCubesCount > 10 && sugarcubesCount > player.PlayerRecipe.amountogSugarCubes );
                
            return pitchers;
        }  

       
       


    }
}


