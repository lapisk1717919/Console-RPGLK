using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Location.shop.SetNearbyLocations(north: Location.goblinCamp, east: Location.bridge, south: Location.creatureCave, west: Location.forest);
            Location.creatureCave.SetNearbyLocations(north: Location.shop /*add DOWN later*/);
            Location.goblinCamp.SetNearbyLocations(south: Location.shop);
            Location.forest.SetNearbyLocations(north: Location.cabin, east: Location.shop);
            Location.cabin.SetNearbyLocations(south: Location.forest);
            Location.bridge.SetNearbyLocations(east: Location.castle, west: Location.shop);
            Location.castle.SetNearbyLocations(west: Location.bridge);

            Location.shop.Resolve(new List<Player>() { Player.player });
        }
    }
}
