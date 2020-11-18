using System;
using System.Collections.Generic;

namespace ArenaFighter
{
    class Program
    {
        static void Main()
        {
            // Declare and init variables and classes

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
            
            // Create Battle
            Battle battle = new Battle(Player);

            

        }
    }
}
