using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

            //Dice playerDice = new Dice(1,6); //Create dice object for player
            //Dice opponentDice = new Dice(1,6); //Create dice object for opponent
            
            //Player.Health += playerDice.ThrowDice; //Simulate Dice throw for player
            //Opponent.Health += opponentDice.ThrowDice; // Simulate Dice throw for opponent

            CreateRounds(Player, Opponent);
        }

        //Create Rounds until either Player or Opponent is beaten
        public void CreateRounds(Fighter Player, Fighter Opponent)
        {            
            bool roundOver = false;
            int i = 1;

            //Create list to hold all battle rounds for one battle
            List<Round> FightRounds = new List<Round>();

            while (!roundOver)
            {
                FightRounds.Add(new Round(Player, Opponent));

                Console.WriteLine("Get ready!\nPress any key for round no {0}!", i);
                Console.ReadKey();

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
            }

            int j = 1;
            foreach (var item in FightRounds)
            {
                Console.WriteLine("Log For Round: " + j);
                Console.WriteLine("--------------------");
                Console.WriteLine(FightRounds[j-1].RoundLogMessage);
                Console.WriteLine("--------------------");

                //Console.WriteLine("Player health: " + Player.Health + "\n");
                //Console.WriteLine("Opponent health: " + Opponent.Health + "\n");
                j++;
            }
            Console.ReadKey();
        
        }
        public object Player { get; }
        public object Opponent { get; }
        public object Round { get; }

    }
}
