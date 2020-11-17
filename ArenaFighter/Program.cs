using System;

namespace ArenaFighter
{
    class Program
    {
        static void Main()
        {
            // Declare and init variables and classes

            Round r = new Round();

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
            Console.WriteLine(Player.FirstName + " " + Player.LastName);
            Console.WriteLine(Player.Health);
            Console.WriteLine(Player.Strength + "\n");

            Console.WriteLine("Opponent:");
            Console.WriteLine(Opponent.FirstName + " " + Opponent.LastName);
            Console.WriteLine(Opponent.Health);
            Console.WriteLine(Opponent.Strength+ "\n");

            // Create Battle
            //Battle battle = new Battle();

            //Create Round
            bool fightOver = false;
            int i = 0;
            while (!fightOver)
            {
                int playerDice = 5;//r.FightRound();
                int opponentDice = 1; //r.FightRound();

                if (playerDice > opponentDice)
                {                    

                    Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strenght: {3}", playerDice, Player.FirstName + " " + Player.LastName, Player.Health, Player.Strength);
                    Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strength: {3}\n", opponentDice, Opponent.FirstName + " " + Opponent.LastName, Opponent.Health, Opponent.Strength);

                    Console.WriteLine("{0} takes a blow of {1}", Opponent.FirstName, playerDice);
                    //Opponent.Strength -= 2;
                    Opponent.Health -= playerDice;
                    
                    Console.WriteLine("Player wins round!");
                }
                else
                {                    
                    Console.WriteLine("{1} rolls a : {0}", playerDice, Player.FirstName + " " + Player.LastName);
                    Console.WriteLine("{0} rolls a : {0} \n", opponentDice, Opponent.FirstName + " " + Opponent.LastName);

                    Console.WriteLine("{0} takes a blow of {1}", Player.FirstName, opponentDice);

                    //Player.Strength -= 2;
                    Player.Health -= opponentDice;

                    Console.WriteLine("Opponent wins round!");                    
                }
                i++;
                if (Player.Health <= 0)
                {
                    Console.WriteLine("Playa' be dead! \n{0} ", Player.Health);
                    fightOver = true;
                }
                if (Opponent.Health <= 0)
                {
                    Console.WriteLine("Opponent' be dead! \n{0}", Opponent.Health);
                    fightOver = true;
                }
            }            
        }
    }
}
