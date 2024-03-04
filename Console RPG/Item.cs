using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string name;
        public string description;
        public string rarity;
        public int weight;
        public int shopPrice;
        public int sellPrice;

        public Item(string name, string description, string rarity, int shopPrice, int sellPrice, int weight = 1)
        {
            this.name = name;
            this.description = description;
            this.rarity = rarity;
            this.weight = weight;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
        }

        public abstract void Use(Entity user, Entity target);
    }

}
