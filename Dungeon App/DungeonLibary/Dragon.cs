using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Dragon : Monster
    {
        public bool IsScaly { get; set; }


        public Dragon(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isScaly)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsScaly = isScaly;
        }

        public override string ToString()
        {
            return base.ToString() + (IsScaly ? "Coated in thick scales" : "Has a soft, underdeveloped hide");
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
