namespace DungeonLibary
{

    public class Combat
    {
       

            public static void DoAttack(Character attacker, Character defender)
            {
                Random rand = new Random();
                int roll = rand.Next(1, 101);

                System.Threading.Thread.Sleep(30);

                if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
                {
                    int damageDealt = attacker.CalcDamage();
                    defender.Life -= damageDealt;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} hit {1} for {2} damage!",
                        attacker.Name, defender.Name, damageDealt);

                    Console.ResetColor();
                }

                else
                {
                    Console.WriteLine("{0} missed!", attacker.Name);
                }
            }

            public static void DoBattle(Player player, Monster monster)
            {
                DoAttack(player, monster);
                if (monster.Life > 0)
                {
                    DoAttack(monster, player);
                }
            }
        
    }
    
}
