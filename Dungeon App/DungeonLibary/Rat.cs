using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Rat : Monster
    {
        public bool IsScaly { get; set; }


        public Rat(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isScaly)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsScaly = isScaly;
        }

        public override string ToString()
        {
            return base.ToString() + (IsScaly ? "Fuzzy" : "Is soft");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsScaly)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
