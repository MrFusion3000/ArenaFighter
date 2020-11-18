using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Round
    {
        public Round(Fighter Player, Fighter Opponent)
        {
            //Create dice throws
            Dice rndDice1 = new Dice(1,6);
            Dice rndDice2 = new Dice(1, 6);

            int playerDice = rndDice1.ThrowDice;
            int opponentDice = rndDice2.ThrowDice;            
            int hitPower;

            //Check which dice are bigger
            if (playerDice > opponentDice)
            {
                //hitPower = (playerDice - opponentDice);
                Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strenght: {3}", playerDice, Player.FirstName + " " + Player.LastName, Player.Health, Player.Strength);
                Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strength: {3}\n", opponentDice, Opponent.FirstName + " " + Opponent.LastName, Opponent.Health, Opponent.Strength);

                RoundLogMessage = Opponent.FirstName + " " + Opponent.LastName + " takes a blow of " + playerDice;
                Console.WriteLine(RoundLogMessage + "\n");
                //Opponent.Strength -= 2;
                Opponent.Health -= playerDice;

                Console.WriteLine("Player wins round!\n");
            }
            else
            {
                hitPower = (opponentDice - playerDice);
                Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strenght: {3}", playerDice, Player.FirstName + " " + Player.LastName, Player.Health, Player.Strength);
                Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strength: {3}\n", opponentDice, Opponent.FirstName + " " + Opponent.LastName, Opponent.Health, Opponent.Strength);

                RoundLogMessage = Player.FirstName + " " + Player.LastName + " takes a blow of " + opponentDice;
                Console.WriteLine(RoundLogMessage);

                //Player.Strength -= 2;
                Player.Health -= opponentDice;

                Console.WriteLine("Opponent wins round!\n");
            }
        }

        public string RoundLogMessage { get; set; }
    }
}
