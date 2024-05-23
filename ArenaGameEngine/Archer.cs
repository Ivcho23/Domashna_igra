using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Archer : Hero
    {
        public Archer() : this("Lady Aurora") 
        {
        }

        public Archer(string name) : base(name)
        {
           
        }

        public override int Attack()
        {
            // Archer hits 2 times with her bow
            int totalDamage = 0;
            for (int i = 0; i < 2; i++)
            {
                int arrowDamage = Random.Shared.Next(30, 51); // Each arrow can deal 30-50 damage
                totalDamage += arrowDamage;
            }
            return totalDamage;
        }
    }
}

