namespace DungeonLibary
{

    public class Combat
    {
       

            //This is NOT a datatype class, so it will not have fields, 
            //properties, or constructors. It will simply serve as a 
            //"warehouse" for a variety of methods related to combat.

            //Let's create a method to handle a one-sided attack
            public static void DoAttack(Character attacker, Character defender)
            {
                //Get a random number from 1-100
                Random rand = new Random();
                int roll = rand.Next(1, 101);

                //Nothing is TRULY random in programming, but suspending 
                //the code execution briefly may help simulate the "randomness"
                //of the roll. We can use Thread.Sleep() for this, which is 
                //located in the System.Threading namespace.
                System.Threading.Thread.Sleep(30);

                //If the attacker "hits"
                if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
                {
                    //Calculate the damage
                    int damageDealt = attacker.CalcDamage();

                    //Subtract & assign the damage to the defender's life
                    defender.Life -= damageDealt;

                    //Ouput the result - Red text helps indicate damage
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} hit {1} for {2} damage!",
                        attacker.Name, defender.Name, damageDealt);

                    //Reset the color so our text returns to normal
                    Console.ResetColor();
                }
                //If the attacker "missed"
                else
                {
                    Console.WriteLine("{0} missed!", attacker.Name);
                }
            }

            //Now we can create a method to handle "battle" - attacks from both sides
            public static void DoBattle(Player player, Monster monster)
            {
                #region Potential Expansion - Initiative

                //Consider adding an "Initiative" property to Character, or Player & Monster
                //Then check the Initiative to determine who attacks first
                //if (player.Initiative >= monster.Initiative)
                //{
                //    DoAttack(player, monster);
                //}
                //else
                //{
                //    DoAttack(monster, player);
                //}

                #endregion

                //For this example, we'll grant the Player "initiative" by default
                DoAttack(player, monster);

                //If the Monster survives, they will attack the player
                if (monster.Life > 0)
                {
                    DoAttack(monster, player);
                }
            }
        
    }
    
}
