using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Wasp : Monster
    {
        public DateTime HourChangeBack { get; set; }

        public Wasp(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            HourChangeBack = DateTime.Now;

            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10;
                Block += 10;
                MinDamage += 1;
                MaxDamage += 2;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}",
                base.ToString(),
                HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 ?
                "Stronger by hive" : "Weak from hunger");
        }
    }
}
