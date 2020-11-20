using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ArenaFighter
{
    class Battle
    {
        public Battle(Fighter Player)
        {
        //Create New Opponent
        Fighter Opponent = new Fighter();

            //Print info to console
            Console.WriteLine("Player:");
            Console.WriteLine("Name:" + Player.FirstName + " " + Player.LastName);
            Console.WriteLine("Health: " + Player.Health);
            Console.WriteLine("Strength: " + Player.Strength + "\n");

            Console.WriteLine("Opponent:");
            Console.WriteLine("Name:" + Opponent.FirstName + " " + Opponent.LastName);
            Console.WriteLine("Health: " + Opponent.Health);
            Console.WriteLine("Strength " + Opponent.Strength + "\n");        

            CreateRounds(Player, Opponent);
        }

        //Create Rounds until either Player or Opponent is beaten
        public void CreateRounds(Fighter Player, Fighter Opponent)
        {            
            bool roundOver = false;
            int i = 1;

            //Create list to hold all battle rounds for one battle
            List<Round> FightRounds = new List<Round>();
            int PlayerScore = 0;           
            int OpponentScore = 0;

            while (!roundOver)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\t--------------------------------------------------");
                Console.WriteLine("\tGet ready!\n\tPress any key for round no {0}!", i);
                Console.WriteLine("\t--------------------------------------------------\n");

                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Gray;
                FightRounds.Add(new Round(Player, Opponent));
                PlayerScore += FightRounds[i-1].PlayerPoints;
                OpponentScore += FightRounds[i-1].OpponentPoints;

                Console.WriteLine("\t" + Player.FirstName + " " + Player.LastName + "\t" + PlayerScore + "\t-\t" + OpponentScore + "\t" + Opponent.FirstName + " " + Opponent.LastName);
                i++;
                if (Player.Health <= 0)
                {
                    Pause();
                    //Player.Health = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t--------------------------------------------------");
                    Console.WriteLine("\tPlaya' be dead!");
                    Console.WriteLine("\t--------------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    roundOver = true;
                    Pause();
                }
                if (Opponent.Health <= 0)
                {
                    Pause();
                    //Opponent.Health = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Opponent be dead!");
                    Console.WriteLine("--------------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("Player gets a health and strength refill!\n");

                    //Give Player replenished Health and Strength
                    Player.Strength = Player.AttributeConfig();
                    Player.Health = Player.AttributeConfig();
                    roundOver = true;
                    Pause();
                }
            }

            Pause();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------");
            int j = 1;
            foreach (var item in FightRounds)
            {                
                Console.WriteLine("Log For Round: " + j);
                Console.WriteLine("--------------------------------------------------");
                Pause();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(FightRounds[j - 1].RoundLogMessage); //+ "\nRound Score: " + FightRounds[j-1].PlayerPoints + " - " + FightRounds[j-1].OpponentPoints);
                Console.ForegroundColor = ConsoleColor.White;
                Pause();
                Console.WriteLine("--------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                //Add points from each round to the Players TotalScore
                Player.TotalScore += FightRounds[j - 1].PlayerPoints;

                j++;
            }       
        }
        public void Pause()
        {
            var stopwatch = Stopwatch.StartNew();
            Thread.Sleep(500);
            stopwatch.Stop();
        }
    }
}
