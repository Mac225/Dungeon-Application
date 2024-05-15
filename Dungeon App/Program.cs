using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System;


#region using statement - Block 5

using DungeonLibary;

#endregion
namespace Dungeon_App
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Title / Introduction

            Console.Title = "DUNGEON OF DOOM!";

            Console.WriteLine("Your journey begins...\n");

            #endregion

            #region Possible Expansion - Levels of Play

            //Possible Expansion: 
            //Define levels of play
            //int[] levels = { 5, 12, 20, 30, 45 };//Use with experience property in Character
            //inherited down to Player and Monster, to scale levelling.

            #endregion

            //TODO Variable to Keep score

            #region Variable to Track Score - Block 5

            int score = 0;

            #endregion

            //TODO Weapon Object Creation

            #region Weapon - Block 5

            Weapon sword = new Weapon(1, 8, "Long Sword", 10, false, WeaponType.Sword);

            #endregion

            #region Possible Expansion - Name Customization

            //Possible Expansion: 
            //Allow player to define chatacter name
            //Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            //Console.Clear();
            //Console.WriteLine("Welcome, {0}! Your journey begins...", userName);
            //Console.ReadKey();
            //Console.Clear();

            #endregion

            //TODO Player Object Creation

            #region Player Object Creation - Block 5

            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Human, sword);

            #endregion

            #region Main Game Loop

            //TODO Create the main game loop
            bool exit = false;

            do
            {

                //TODO Generate a random room
                Console.WriteLine(GetRoom());

                //TODO Select a random monster to inhabit the room
                #region Monsters - Block 5

                //Create a variety of Monsters
                Rabbit rabbit = new Rabbit("White Rabbit", 25, 25, 50, 20,
                  2, 8, "That's no ordinary rabbit! Look at the bones!",
                  true);
                Vampire vampire = new Vampire("Dracula", 25, 30, 70, 8, 1, 8, "The father of all the undead");
                Turtle turtle = new Turtle("Mikey", 17, 25, 50, 10, 1, 4, "He is no longer a teenager but he is still /a/ mutant turle", 3, 10);
                Dragon dragon = new Dragon("Smaug", 10, 20, 65, 20, 1, 15, "The last great dragon.", true);

                //Add the monsters to a collection
                Monster[] monsters = { rabbit, turtle, vampire, dragon };

                //Pick one at random to place in the room
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //Output
                Console.WriteLine("\nIn this room: " + monster.Name);

                #endregion

                //TODO Create the loop for the main gameplay menu

                #region Gameplay Menu Loop

                bool reload = false;
                do
                {

                    //TODO Create the main gameplay menu
                    #region MENU

                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //Capture user's menu selection
                    ConsoleKey userChoice = Console.ReadKey(true).Key;//Executes upon input without hitting enter

                    //Clear the console
                    Console.Clear();

                    //Use branching logic to act upon user's menu selection
                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            //TODO Combat

                            #region Possible Expansion - Racial/Weapon Bonus

                            //Possible Expansion: Give certain character races or characters with a certain weapon an advantage
                            //if (player.CharacterRace == Race.DarkElf)
                            //{
                            //    Combat.DoAttack(player, monster);
                            //}

                            #endregion

                            #region Combat - Block 5

                            //Execute combat
                            Combat.DoBattle(player, monster);

                            //Check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                #region Possible Expansion - Combat Rewards

                                //You could add some logic here to grant the Player life:
                                //player.Life += 5;

                                //Or, loot drops! (NOTE: This would require an Item class 
                                //as well as a property for the Player of type List<Item>):

                                //Item rubyNecklace = new Item("Ruby Necklace", "Increases Max Life", MaxLife, 10);
                                //inventory.add(rubyNecklace);
                                //Console.WriteLine($"{player.Name} received {rubyNecklace.Name}!");
                                //Console.WriteLine("{0}", rubyNecklace);

                                #endregion

                                //Use green text to highlight winning combat
                                Console.ForegroundColor = ConsoleColor.Green;

                                //Output the result
                                Console.WriteLine("\nYou killed {0}!\n",
                                    monster.Name);

                                //Reset the color
                                Console.ResetColor();

                                //Flip the reload bool to exit the current menu loop and get a new room
                                reload = true;

                                //Update the score
                                score++;

                            }

                            #endregion

                            break;

                        case ConsoleKey.R:

                            //TODO Run Away

                            #region Run Away - Block 5

                            Console.WriteLine("Run Away!!!");

                            //Monster gets an "attack of opportunity"
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);

                            //Formatting
                            Console.WriteLine();

                            //Flip the reload bool to exit the current menu loop and get a new room
                            reload = true;

                            #endregion

                            break;

                        case ConsoleKey.P:

                            //TODO Player Info

                            #region Player Info - Block 5

                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);


                            //Console.WriteLine("Monsters defeated: " + score);

                            #endregion

                            break;

                        case ConsoleKey.M:

                            //TODO Monster Info

                            #region Monster Info - Block 5

                            Console.WriteLine(monster);

                            #endregion

                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:

                            //TODO Exit

                            #region Exit

                            Console.WriteLine("No one likes a quitter...");
                            exit = true;

                            #endregion

                            break;

                        default:

                            //TODO Default / Invalid Input

                            #region Default / Invalid Input

                            Console.WriteLine("Thou hast chosen an improper option. Triest thou again.");

                            #endregion

                            break;

                    }//end switch

                    #endregion

                    //TODO Check Player Life
                    #region Check Player Life - Block 4

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude.... you died!\a");

                        //If the player is dead, flip the exit bool to end the game
                        exit = true;
                    }

                    #endregion

                } while (!exit && !reload);

                #endregion

            } while (!exit); //while exit is NOT TRUE keep looping

            #endregion


            //TODO Output Final Score
            #region Output Final Score - Block 5


            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));


            #endregion


        }//end Main


        #region GetRoom()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;

            #region An Example of Possible Refactoring

            //return rooms[new Random().Next(rooms.Length)];

            #endregion

        }//end GetRoom()

        #endregion

    }//end class
}
