using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Console_RPG
{
    class Battle : Event
    {
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;

        }

        public override void Resolve(List<Player> players)
        {
            //loop turn system
            while (!isResolved)
            {
                //loop through all players
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(player.name + "'s turn!");
                        Console.WriteLine($"{player.currentHP}/{player.maxHP} HP");
                        Console.ForegroundColor = ConsoleColor.White;
                        player.DoTurn(players, enemies);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"{player.name} is down and can't take a turn!");
                    }
                }
                //loop through all enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(enemy.name + "'s turn!");
                        Console.WriteLine($"{enemy.currentHP}/{enemy.maxHP} HP");
                        Console.ForegroundColor = ConsoleColor.White;
                        enemy.DoTurn(players, enemies);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"{enemy.name} is down and can't take a turn!");
                    }
                    //if players lose
                    if (players.TrueForAll(player => player.currentHP <= 0))
                    {
                        Console.WriteLine("Game over, man, game over!");
                        throw new Exception("skill issue");
                    }
                    //if players win
                    if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                    {
                        Player.CoinCount += enemy.cashdropped;
                        isResolved = true;
                    }
                }
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You won!");
            Console.WriteLine($"You now hold {Player.CoinCount}¢.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
