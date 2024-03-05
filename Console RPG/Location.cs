using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {

        public static Location creatureCave = new Location("creature cave", "creatures dwell", new Battle(new List<Enemy>() { Enemy.slime1, Enemy.slime2 }));
        public static Location goblinCamp = new Location("goblin camp", "they live here");
        public static Location shop = new Location("Shop", "spend your money", new Shop("Lapis", new List<Item>() { HealthPotionItem.heal, HealthPotionItem.heal, HealthPotionItem.heal, HealthPotionItem.gheal }));
        public static Location forest = new Location("dark forest", "where strong beasts dwell");
        public static Location cabin = new Location("cabin", "a nice spot to rest your head");
        public static Location bridge = new Location("bridge", "guarded by a fierce beast");
        public static Location castle = new Location("castle", "the end of your quest");

        public string name;
        public string description;
        public Event feature;

        public Location north, east, south, west;
        public Location(string name, string description, Event feature = null)
        {
            this.name = name;
            this.description = description;
            this.feature = feature;
        }
        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {

            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }
            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }
            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }
            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }

        }
        public void Resolve(List<Player> players)
        {
            Console.WriteLine("");
            Console.WriteLine("You have arrived at the " + name);
            Console.WriteLine(description);
            Console.WriteLine("");
            //complete battle in location

            feature?.Resolve(players);

            if (!(north is null))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("NORTH: " + north.name);
            }
            if (!(east is null))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("EAST: " + east.name);
            }
            if (!(south is null))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SOUTH: " + south.name);
            }
            if (!(west is null))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WEST: " + west.name);
            }
            Console.ForegroundColor = ConsoleColor.White;
            string direction = Console.ReadLine();
            Location nextLocation = null;

            if (direction == "NORTH")
                nextLocation = north;
            if (direction == "EAST")
                nextLocation = east;
            if (direction == "SOUTH")
                nextLocation = south;
            if (direction == "WEST")
                nextLocation = west;
            if (nextLocation == null)
            {
                if (!(north is null))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    nextLocation = north;
                    Console.WriteLine("Unexpected input! Defaulting to NORTH");
                }
                else if (!(east is null))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    nextLocation = east;
                    Console.WriteLine("Unexpected input! Defaulting to EAST");
                }
                else if (!(south is null))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    nextLocation = south;
                    Console.WriteLine("Unexpected input! Defaulting to SOUTH");
                }
                else if (!(west is null))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    nextLocation = west;
                    Console.WriteLine("Unexpected input! Defaulting to WEST");
                }
                Console.ResetColor();
            }
            nextLocation.Resolve(players);
        }
    }
}
