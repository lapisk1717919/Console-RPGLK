using System.Collections.Generic;
using System;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy slime1 = new Enemy("Slime", 10, 10, new Stats(10, 10, 2, 1), 5);
        public static Enemy slime2 = new Enemy("Slime", 10, 10, new Stats(10, 10, 2, 1), 5);
        public static Enemy goblin = new Enemy("Goblin", 15, 10, new Stats(10, 8, 4, 3), 8);

        public int cashdropped;
        public Enemy(string name, float hp, float mana, Stats stats, int cashdropped) : base(name, hp, mana, stats)
        {
            this.cashdropped = cashdropped;
        }
        public override Entity ChooseTarget(List<Entity> choices)
        {
            Random random = new Random();
            return choices[random.Next(choices.Count)];
        }
        public override void PhysAttack(Entity target)
        {
            target.currentHP -= stats.strength - target.stats.defense;
            Console.WriteLine($"{name} attacked {target.name}!");
            Console.WriteLine($"{target.name} took {stats.strength - target.stats.defense} damage!");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            PhysAttack(target);
        }
    }
}
