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
            Console.WriteLine("Enter your fighters name: ");
            string playerName = Console.ReadLine();
            // Create Player
            Fighter Player = new Fighter();
            
            // Create Battle
            bool fightOver = false;
            int i = 0;
            while (!fightOver)
            {
                Battle battle = new Battle();

                int playerDice = r.FightRound();
                int opponentDice = r.FightRound();

                if (playerDice > opponentDice)
                {
                    Console.WriteLine("Player rolls a : {0}", playerDice);
                    Console.WriteLine("Player wins round!");

                    fightOver = true;
                }
                else
                {
                    Console.WriteLine("Opponent rolls a : {0}", opponentDice);
                    Console.WriteLine("Opponent wins round!");
                    fightOver = true;
                }
                i++;
            }

            
            
            


            
        }
    }
}
