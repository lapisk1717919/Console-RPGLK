using System;

namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public static HealthPotionItem lheal = new HealthPotionItem("Lesser Healing Potion", "Provides minimal healing.", "Common", 10, 7, 13);
        public static HealthPotionItem heal = new HealthPotionItem("Healing Potion", "Provides moderate healing.", "Uncommon", 15, 9, 25);
        public static HealthPotionItem gheal = new HealthPotionItem("Greater Healing Potion", "Provides significant healing.", "Rare", 25, 13, 40);

        public int healing;

        public HealthPotionItem(string name, string description, string rarity, int shopPrice, int sellPrice, int healing, int weight = 1) : base(name, description, rarity, shopPrice, sellPrice, healing)
        {
            this.healing = healing;
        }
        public override void Use(Entity user, Entity target)
        {
            target.currentHP += this.healing;
            Console.WriteLine(target.name + " healed " + this.healing + " hp!");
        }
    }

}
