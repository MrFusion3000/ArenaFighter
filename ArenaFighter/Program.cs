using System;
using System.Collections.Generic;

namespace ArenaFighter
{
    class Program
    {
        static void Main()
        {
            // Declare and init variables and classes

            bool gameOn = true;

            while (gameOn)
            {
                // Enter Player Fighter Name
                Console.Clear();
                Console.WriteLine("WELCOME TO THE BATTLEGROUNDS!");
                Console.WriteLine("First, Enter your fighters first name: ");
                string playerFirstName = Console.ReadLine();
                Console.WriteLine("Now, Enter your fighters last name: ");
                string playerLastName = Console.ReadLine();

                // Create Player
                Fighter Player = new Fighter()
                {
                    FirstName = playerFirstName,
                    LastName = playerLastName
                };

                bool tournamentOn = true;

                while (tournamentOn)
                {
                    // Create Battle
                    Battle battle = new Battle(Player);

                    if (Player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Y O U  L O O S E!!! {0} {1}", Player.FirstName, Player.LastName);
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("{0} {1} ARE THE WINNER!!!", Player.FirstName, Player.LastName);
                        Console.WriteLine("The players total score is: {0}", Player.TotalScore);
                        Console.WriteLine("------------------------------------------");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (Player.Health <= 0)
                    {
                        tournamentOn = false;
                    }
                }

                Console.WriteLine("Wanna play again? (Y/N)");
                string io = Console.ReadLine();

                if ( io == "n")
                {
                    gameOn = false;
                }
            }
            

        }
    }
}
