using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Round
    {
        public Round(Fighter Player, Fighter Opponent)
        {
            Dice rndDice = new Dice();
            int playerDice = rndDice.ThrowDice;
            int opponentDice = rndDice.ThrowDice;            

            if (playerDice > opponentDice)
            {
                //Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strenght: {3}", playerDice, Player.FirstName + " " + Player.LastName, Player.Health, Player.Strength);
                //Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strength: {3}\n", opponentDice, Opponent.FirstName + " " + Opponent.LastName, Opponent.Health, Opponent.Strength);

                Console.WriteLine("{0} takes a blow of {1}", Opponent.FirstName, playerDice);
                //Opponent.Strength -= 2;
                Opponent.Health -= playerDice;

                Console.WriteLine("Player wins round!");
            }
            else
            {
                //Console.WriteLine("{1} rolls a : {0}", playerDice, Player.FirstName + " " + Player.LastName);
                //Console.WriteLine("{0} rolls a : {0} \n", opponentDice, Opponent.FirstName + " " + Opponent.LastName);

                Console.WriteLine("{0} takes a blow of {1}", Player.FirstName, opponentDice);

                //Player.Strength -= 2;
                Player.Health -= opponentDice;

                Console.WriteLine("Opponent wins round!");
            }
        }
    }
}
