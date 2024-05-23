using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Dog : Monster
    {
        public bool isFat { get; set; }

        public Dog(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isFat)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            
        }

        public override string ToString()
        {
            return base.ToString() + (isFat ? "Fat" : "Not Fat");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

           
            if (isFat)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
