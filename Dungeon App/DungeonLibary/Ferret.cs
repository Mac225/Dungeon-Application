using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Ferret : Monster
    {
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        public Ferret(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, int bonusBlock, int hidePercent)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}% chance it will hide, granting {2} bonus block.",
                base.ToString(), HidePercent, BonusBlock);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            Random rand = new Random();
            int percent = rand.Next(101);

            if (percent <= HidePercent)
            {
                calculatedBlock += BonusBlock;
            }

            return calculatedBlock;
        }
    }
}
