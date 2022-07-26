using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    
    class Store 
    {


        public double currentMoney; 
        public int currentLemons;
        public int currentIceCubes;
       public int currentCups;
        public int currentSugar;
       Player StorePlayer = new Player (); //whatever is passed down becomes this instance

        public void Startg(Player player1) 
        {

            StorePlayer = player1;
            
            currentMoney = StorePlayer.PlayerWallet.Money; 

            
            currentLemons = StorePlayer.PlayerInventory.lemons.Count;
            currentIceCubes = StorePlayer.PlayerInventory.icecubes.Count;
            currentCups = StorePlayer.PlayerInventory.cups.Count;
            currentSugar = StorePlayer.PlayerInventory.sugarcubes.Count;
            UserInterface.DisplayMenu(currentMoney, currentLemons, currentIceCubes, currentCups, currentSugar);
            
        }

        public Item MenuPrompt()
        {
            Item MenuItem;
            do
            {
                Console.WriteLine("Enter the item you like to purchase: Lemon, Sugar, Ice Cube, Cup....Enter Start to Skip");
                MenuItem = UserInterface.PurchaseItems();
            } while (MenuItem == null);
            return MenuItem;
        }

        
        
        public int howMany(Item item)//take
        
        {
            int amount = 0;
            
            Console.WriteLine("How Many?");
            Console.WriteLine("Lemons: .25$ SugarCube: .12$ Cup: 10$ Ice Cube 1.00 for 10");

                string response = Console.ReadLine();
            try
            {
                amount = Convert.ToInt16(response);
                
            }
            catch(FormatException e)
            {
            Console.WriteLine("Not valid");
             this.howMany(item);   
            }

            if(item.name == "Ice Cube" && amount % 10 == 0) 
            {
                return amount;
                
            }
            else if (item.name == "Ice Cube" && amount %10 != 0) {
            Console.WriteLine("Amount of ice cubes must be a multiple of 10");
                this.howMany(item);
            }
            else{

                return amount;
            }
            return 0;
            
             
         }          

            public Player SetMenuItem (Item item, int amount) ////amount is how many were purchased, item is what item
            {

                for(int i = 0; i < amount; i++) {
       
                        switch (item.name)
                        {
                            case "Cup":
                                Cup cup = new Cup();
                                StorePlayer.PlayerInventory.cups.Add(cup);
                                StorePlayer.PlayerWallet.Money -= .10;

                               
                                break;
                            case "Lemon":
                                Lemon lemon = new Lemon();
                                StorePlayer.PlayerInventory.lemons.Add(lemon);
                                StorePlayer.PlayerWallet.Money -= .20;


                                break;
                            case "Ice Cube":
                                IceCube icecube = new IceCube ();
                                 StorePlayer.PlayerInventory.icecubes.Add(icecube);
                                StorePlayer.PlayerWallet.Money -= .10;

                                break;
                            case "Sugar":
                                SugarCube sugarcube = new SugarCube();
                                StorePlayer.PlayerInventory.sugarcubes.Add(sugarcube);
                                                                                                            
                                StorePlayer.PlayerWallet.Money -= .12;
                            break;
                            default:
                                
                                break;

                        }
                        //Add a tip writeline here for perfect ratio for recipe
                }
                return StorePlayer;
           
            }        




        
        }

    }
















