﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ArenaFighter
{
    class Program
    {
        public static void Main()
        {
            // Declare and init variables and classes
            //var Highscores = new List<Highscore>();            

            var gameOn = true;
            //int j = 0;
            
            //TODO Show Highscore on startscreen
            
            while (gameOn)
            {
                // Enter Player Fighter Name
                Console.Clear();
                Console.WriteLine("WELCOME TO THE BATTLEGROUNDS!\n");
                Highscore.PrintHighScoreList();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t--------------------------------------------------");
                Console.WriteLine("\t\t     Press any key to begin!");
                Console.WriteLine("\t--------------------------------------------------\n");
                Console.ReadKey();
                
                Console.WriteLine("First, Enter your fighters first name: ");
                var playerFirstName = Console.ReadLine();
                Console.WriteLine("Now, Enter your fighters last name: ");
                var playerLastName = Console.ReadLine();

                // Create Player
                var Player = new Fighter()
                {
                    FirstName = playerFirstName,
                    LastName = playerLastName
                };

                var tournamentOn = true;

                // Loop until one battle is over
                while (tournamentOn)
                {
                    // Start a Battle
                    Battle battle = new Battle(Player);

                    if (Player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("\tY O U  L O O S E!!! {0} {1}", Player.FirstName, Player.LastName);
                        Console.WriteLine("------------------------------------------");

                        //Highscore.AddNewHighscore(Player.FirstName, Player.LastName, Player.TotalScore);

                        tournamentOn = false;
                    }
                    else                    
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("{0} {1} ARE THE WINNER!!!", Player.FirstName, Player.LastName);
                        Console.WriteLine("\tThe players total score is: {0}", Player.TotalScore);
                        Console.WriteLine("------------------------------------------");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (Player.Health <= 0) continue;
                    Console.WriteLine("Do you wanna keep fighting your way to the top? (Y/N)");
                    var input = Console.ReadLine();

                    if (input == "n" || input == "N")
                    {
                        Highscore.AddNewHighscore(Player.FirstName, Player.LastName, Player.TotalScore);
                        //Highscores.Add(new Highscore(Player.FirstName, Player.LastName, Player.TotalScore));

                        tournamentOn = false;
                    }
                    else {
                        Console.WriteLine("G A M E  O N ! ! !");
                    }
                }

                Console.WriteLine("H I G H S C O R E");
                Console.WriteLine("------------------------------------------");
                // var isEmpty = !Highscores.Any();
                // if (isEmpty)
                // {
                //     Console.WriteLine("No Highscores yet!");
                // }
                // else
                // {
                    Highscore.PrintHighScoreList();
                //}

                Console.WriteLine("Wanna play a new game of ArenaFighter|BattleGrounds? (Y/N)");
                var io = Console.ReadLine();

                if ( io == "n")
                {
                    gameOn = false;
                }
            }
        }
    }
}
