using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    internal class Shop : Event
    {
        public string ShopKeeperName;
        public List<Item> items;

        public Shop(string shopKeeperName, List<Item> items) : base(false)
        {
            ShopKeeperName = shopKeeperName;
            this.items = items;
        }

        public override void Resolve(List<Player> players)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"SHOPKEEP: 'Welcome to my shop. I'm {ShopKeeperName}, take a look around.'");
            Console.WriteLine("");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("BUY | TALK | LEAVE");
                string userChoice = Console.ReadLine();
                Console.WriteLine("");
                //BUY
                if (userChoice == "BUY")
                {
                    Item item = ChooseItem(items);
                    if (Player.CoinCount < item.shopPrice)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Can't afford item! (Costs {item.shopPrice}§, client has {Player.CoinCount}§)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Player.CoinCount -= item.shopPrice; //Spend money
                        Player.Inventory.Add(item); //Get item
                        Console.WriteLine($"You bought {item.name}."); //Tell user they got the item
                    }
                }
                //TALK
                else if (userChoice == "TALK")
                {
                    Console.WriteLine("SHOPKEEP: 'Sorry i'm not letting you sell items. It's already hard making a living in a land 5 locations wide.'");
                }
                else if (userChoice == "LEAVE")
                {
                    Console.WriteLine("SHOPKEEP: 'Come back soon.'");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Defaulting to LEAVE.");
                }
                }
                Console.ForegroundColor = ConsoleColor.White;

        }
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Write the number of the item you want to buy."); //items will be labelled "1.ITEMNAME, 2.ITEMNAME"
            Console.ForegroundColor = ConsoleColor.Yellow;
            //print list of items in shop
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{choices[i].name} ({choices[i].shopPrice}§)");
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
}
