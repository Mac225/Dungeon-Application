using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{
    public class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace,
            Weapon equippedWeapon) : base(name, hitChance, block, maxLife, life)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

          
        }

        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orc";
                    HitChance += 5;
                    break;
                case Race.Human:
                    description = "Human";
                    HitChance += 6;
                    break;
                case Race.Elf:
                    description = "Elf";
                    HitChance += 2;
                    break;
                case Race.Halfling:
                    description = "Halfling";
                    HitChance += 7;
                    break;
                
            }

            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Weapon:\n{4}\nBlock: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block,
                description);
        }

        public override int CalcDamage()
        {
           
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
