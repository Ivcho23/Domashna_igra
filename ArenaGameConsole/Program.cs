using ArenaGameEngine;

namespace ArenaGameConsole
{

    using ArenaGameEngine;
    
    namespace ArenaGameConsole
    {
        class ConsoleGameEventListener : GameEventListener
        {
            public override void GameRound(Hero attacker, Hero defender, int attack)
            {
                string message = $"{attacker.Name} attacked {defender.Name} for {attack} points";
                if (defender.IsAlive)
                {
                    message = message + $" but {defender.Name} survived.";
                }
                else
                {
                    message = message + $" and {defender.Name} died.";
                }
                Console.WriteLine(message);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Knight knight = new Knight("Sir John");
                Rogue rogue = new Rogue("Slim Shady");
                Archer archer = new Archer("Lady Aurora");
                Tank tank = new Tank("Prince Artur");

                Arena arena = new Arena(knight, rogue, archer, tank);
                arena.EventListener = new ConsoleGameEventListener();

                Console.WriteLine("Battle begins.");
                Hero winner = null;

                while (arena.NumberOfAliveHeroes() > 1)
                {
                    winner = arena.Battle();
                }

                // Output the winner
                if (winner != null)
                {
                    Console.WriteLine("Battle ended.");
                    Console.WriteLine($"Winner: {winner.Name}");
                }
                else
                {
                    Console.WriteLine("No winner. All heroes are defeated.");
                }

                Console.ReadLine();
            }
        }
    }
}