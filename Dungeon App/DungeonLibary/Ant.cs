using DungeonLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Ant : Monster
    {
       

        public Ant(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {

        }


       
    }
}
