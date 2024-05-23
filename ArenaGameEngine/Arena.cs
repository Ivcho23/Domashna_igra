using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Arena
    {
        private List<Hero> heroes = new List<Hero>();
        public GameEventListener EventListener { get; set; }

        public Arena(params Hero[] heroes)
        {
            this.heroes.AddRange(heroes);
        }

        public int NumberOfAliveHeroes()
        {
            return heroes.Count(hero => hero.IsAlive);
        }

        public Hero Battle()
        {
            Random random = new Random();
            while (heroes.Count > 1)
            {
                // Select a random attacker and defender
                int attackerIndex = random.Next(heroes.Count);
                int defenderIndex = random.Next(heroes.Count);
                while (defenderIndex == attackerIndex) // Ensure attacker and defender are different
                {
                    defenderIndex = random.Next(heroes.Count);
                }
                Hero attacker = heroes[attackerIndex];
                Hero defender = heroes[defenderIndex];

                // Perform attack and damage calculation
                int damage = attacker.Attack();
                defender.TakeDamage(damage);

                // Notify event listener about the game round
                if (EventListener != null)
                {
                    EventListener.GameRound(attacker, defender, damage);
                }

                // Check if defender is dead
                if (defender.IsDead)
                {
                    Console.WriteLine($"{defender.Name} has died.");
                    heroes.Remove(defender);
                }
            }

            // Return the last remaining hero as the winner
            return heroes.Count == 1 ? heroes[0] : null;
        }
    }
        
    
}
