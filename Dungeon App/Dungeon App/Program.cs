﻿using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System;

using DungeonLibary;


namespace Dungeon_App
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Console.Title = "DUNGEON OF Death!";

            Console.WriteLine("The fight begins!\n");

            int score = 0;


            //TODO Weapon Object Creation


            Weapon Knife = new Weapon(1, 11, "Sharp Knife", 12, false, WeaponType.Knife);
            Weapon Bat = new Weapon(1, 5, "Wooden Bat", 15, false, WeaponType.Bat);
            Weapon Staff = new Weapon(1, 10, "Short Staff", 11, false, WeaponType.Staff);
            Weapon Sword = new Weapon(1, 8, "Long Sword", 10, false, WeaponType.Sword);


            //Define name
            Console.Write("Enter your name: ");

            string userName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Welcome, {0}! Your journey begins...", userName);

            Console.Clear();

            //Customize character



            Console.Write("\nPlease choose an action:\n" +
                        "O) Orc\n" +
                        "H) Human\n" +
                        "E) Elf\n" +
                        "P) Halfling\n");
                        

            ConsoleKey userChoice1 = Console.ReadKey(true).Key;

            Console.Clear();

            //bool exit2 = false;

            
            

            Console.Clear();



            Player player = new Player(userName, 70, 5, 40, 40, Race.Human, Sword);

          
            bool exit = false;

            do
            {
                Console.WriteLine(GetRoom());


                Dog dog = new Dog("Doggy", 25, 25, 50, 20,
                  2, 8, "That's not a small dog! Look at its long teeth!",
                  true);
                Wasp wasp = new Wasp("BuzzKill", 25, 30, 70, 8, 1, 8, "Extra stingy");
                Ferret ferret = new Ferret("Bear", 17, 25, 50, 10, 1, 4, "A large fat ferret", 3, 10);
                Rat rat = new Rat("Sneaky", 10, 20, 65, 20, 1, 15, "The fattest rat.", true);
                Monster[] monsters = { dog, wasp, ferret, rat };

                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room: " + monster.Name);


                bool reload = false;
                do
                {

                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                  
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                   
                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            

                            
                            Combat.DoBattle(player, monster);

                            if (monster.Life <= 0)
                            {
                              
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n",
                                    monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;

                            }


                            break;

                        case ConsoleKey.R:


                            Console.WriteLine("Run Away!!!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;

                            break;

                        case ConsoleKey.P:


                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);


                            break;

                        case ConsoleKey.M:


                            Console.WriteLine(monster);

                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:

                          
                            Console.WriteLine("You ran away...");
                            exit = true;


                            break;

                        default:


                            Console.WriteLine("Thou hast chosen an wrong option. try agian.");


                            break;

                    }

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You died!\a");

                        exit = true;
                    }


                } while (!exit && !reload);


            } while (!exit); 




            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));


          


        }


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


        }


    }
}
