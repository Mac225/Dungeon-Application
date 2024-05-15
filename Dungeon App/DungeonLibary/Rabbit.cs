using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Rabbit : Monster
    {
        public bool IsFluffy { get; set; }

        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isFluffy)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsFluffy = isFluffy;
        }

        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffy" : "Not so fluffy");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            //Apply a 50% increase to the Rabbit's block if it's fluffy
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
