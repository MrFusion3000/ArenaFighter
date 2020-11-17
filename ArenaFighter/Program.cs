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

            Fighter Opponent = new Fighter();

            Console.WriteLine("Player:");
            Console.WriteLine("Name:" + Player.FirstName + " " + Player.LastName);
            Console.WriteLine("Health: " + Player.Health);
            Console.WriteLine("Strength: " + Player.Strength + "\n");

            Console.WriteLine("Opponent:");
            Console.WriteLine("Name:" + Opponent.FirstName + " " + Opponent.LastName);
            Console.WriteLine("Health: " + Opponent.Health);
            Console.WriteLine("Strength " + Opponent.Strength+ "\n");

            // Create Battle
            //Battle battle = new Battle();

            Dice playerDice = new Dice(); //Create dice object for player
            Dice opponentDice = new Dice(); //Create dice object for opponent

            Player.Health += playerDice.ThrowDice; //Simulate Dice throw for player
            Opponent.Health += opponentDice.ThrowDice; // Simulate Dice throw for opponent

            //Create Round
            bool roundOver = false;
            int i = 0;

            List<Round> FightRounds = new List<Round>();

            while (!roundOver)
            {
                FightRounds.Add (new Round(Player, Opponent));

                i++;
                if (Player.Health <= 0)
                {
                    Player.Health = 0;
                    Console.WriteLine("Playa' be dead! \n{0} ", Player.Health);
                    roundOver = true;
                }
                if (Opponent.Health <= 0)
                {
                    Opponent.Health = 0;
                    Console.WriteLine("Opponent be dead! \n{0}", Opponent.Health);
                    roundOver = true;
                }                

                Console.WriteLine("Get ready!\nPress any key round no {0}!", i);
                Console.ReadKey();
            }

            int j = 1;
            foreach (var item in FightRounds)
            {
                Console.WriteLine("Round: " + j);
                Console.WriteLine("Player health: " + Player.Health + "\n");
                Console.WriteLine("Opponent health: " + Opponent.Health + "\n");
                j++;
            }
            Console.ReadKey();

        }
    }
}
