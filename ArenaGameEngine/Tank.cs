using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Tank : Hero
    {
        public Tank() : this("Prince Artur") 
        {
        }

        public Tank(string name) : base(name)
        {
          
        }

        public override int Attack()
        {
            // Tank can deal 30-55 damage
            return Random.Shared.Next(30, 56);
        }


        public override void TakeDamage(int incomingDamage)
        {
            // Tank has a 30% chance to block incoming damage with his shield
            int dice = Random.Shared.Next(0, 101);
            if (dice <= 30)
            {
                // Blocked by shield, no damage taken
                incomingDamage = 0;
                Console.WriteLine($"{Name} uses his shield and blocks the attack from.");
            }
            base.TakeDamage(incomingDamage);
        }
    }
}

