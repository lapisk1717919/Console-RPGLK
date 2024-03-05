using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() { HealthPotionItem.heal };
        public static int CoinCount = 0;

        public static Player player = new Player("player", 50, 25, new Stats(13, 8, 4, 2), 10);

        public int cash;
        public int carrylimit;
        public Player(string name, float hp, float mana, Stats stats, int cash, int carrylimit = 40) : base(name, hp, mana, stats)
        {
            this.cash = cash;
            this.carrylimit = carrylimit;
        }
        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("Write the number of the creature you want to target."); //enemies will be labelled "1.ENEMYNAME, 2.ENEMYNAME"
            Console.ForegroundColor = ConsoleColor.Red;
            //print list of enemies in the battle
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{choices[i].name}");
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Write the number of the item you want to use."); //items will be labelled "1.ITEMNAME, 2.ITEMNAME"
            Console.ForegroundColor = ConsoleColor.Red;
            //print list of items in inventory
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{choices[i].name}");
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public override void PhysAttack(Entity target)
        {
            target.currentHP -= stats.strength - target.stats.defense;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{name} attacked {target.name}!");
            Console.WriteLine($"{name} dealt {stats.strength - target.stats.defense} damage!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"what does {name} do?");
            Console.WriteLine("ATTACK | ITEM");
            Console.ForegroundColor = ConsoleColor.White;
            string choice = Console.ReadLine();
            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                PhysAttack(target);
            }
            else if (choice == "ITEM")
            {
                Item item = ChooseItem(Inventory);
                Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                UseItem(item, target);
                
            }
            else
            {
                Console.WriteLine("Invalid input! Defaulting to ATTACK.");
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                PhysAttack(target);
            }
        }
    }
}
