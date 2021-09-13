using System;
using System.Net.Security;

namespace ArenaFighter
{
    internal static class Program
    {
        public static void Main()
        {
            var HighscoreCommand = new HighscoreCommand();
            var HighscoreList = HighscoreCommand.InitCreateTop10();
            var Player = new Fighter("firstname", "lastname");
            var gameOn = true;
            
            Console.Clear();

            while (gameOn)
            {
                // Enter Player Fighter Name
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("WELCOME TO THE BATTLEGROUNDS!\n\n");
                
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("\tH I G H S C O R E S");
                Console.WriteLine("-----------------------------------");

                HighscoreCommand.PrintHighscoreList();
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("\t     Press any key to begin!");
                Console.WriteLine("--------------------------------------------------\n");
                Console.ReadKey();
                
                // Create Player
                Player = Fighter.CreatePlayer(Player);

                var tournamentOn = true;

                // Loop until one battle is over
                while (tournamentOn)
                {
                    // Start a Battle
                    var battle = new Battle(Player);

                    if (Player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("\tY O U  L O O S E, {0} {1}!!!", Player.FirstName, Player.LastName);
                        Console.WriteLine("\tYour total score is: {0}", Player.TotalScore);
                        Console.WriteLine("------------------------------------------");

                        HighscoreCommand.AddNewHighscore(Player.FirstName, Player.LastName, Player.TotalScore);

                        tournamentOn = false;
                    }
                    else                    
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("{0} {1} IS THE WINNER!!!", Player.FirstName, Player.LastName);
                        Console.WriteLine("\tYour total score is: {0}", Player.TotalScore);
                        Console.WriteLine("------------------------------------------");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (Player.Health <= 0) continue;
                    Console.WriteLine("Do you wanna keep fighting your way to the top? (Y/N)");
                    var input = Console.ReadLine();

                    if (input == "n" || input == "N")
                    {
                        HighscoreCommand.AddNewHighscore(Player.FirstName, Player.LastName, Player.TotalScore);

                        tournamentOn = false;
                        Console.WriteLine("Good riddance!");
                    }
                    else {
                        Console.WriteLine("G A M E  O N ! ! !");
                    }
                }

                Console.WriteLine("------------------------------------------");
                Console.WriteLine("\tH I G H S C O R E S");
                Console.WriteLine("------------------------------------------");
                
                    HighscoreCommand.PrintHighscoreList();

                    Console.WriteLine("Do you wanna play a new game of ArenaFighter|BattleGrounds? (Y/N)");
                var io = Console.ReadLine();

                if ( io == "n")
                {
                    gameOn = false;
                }
                else
                {
                    Console.WriteLine("Same player? (y/n)");
                    io = Console.ReadLine();
                    if (io == "y")
                    {
                        Player = new Fighter(Player.FirstName, Player.LastName);
                    }
                    else
                    {
                        Console.WriteLine( "\nWell, alrighty then...\n");
                        Player = new Fighter("firstname", "lastname");
                        Player = Fighter.CreatePlayer(Player);
                    }
                }
            }
        }
    }
}
