using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ArenaFighter
{
    public class Round
    {
        public string RoundLogMessage { get; set; }
        public int PlayerPoints { get; set; }
        public int OpponentPoints { get; set; }

        public Round(Fighter Player, Fighter Opponent)
        {
            //Create dice throws
            Dice rndDice1 = new Dice(1, 6);
            Dice rndDice2 = new Dice(1, 6);

            int playerDice = rndDice1.ThrowDice;
            int opponentDice = rndDice2.ThrowDice;

            //Check which dice are bigger
            if (playerDice > opponentDice)
            {
                Console.WriteLine("{1} rolls a {0}, Health: {2}, Strenght: {3}\n", playerDice, Player.FirstName + " " + Player.LastName, Player.Health, Player.Strength);
                Pause();
                Console.WriteLine("{1} rolls a {0}, Health: {2}, Strength: {3}\n", opponentDice, Opponent.FirstName + " " + Opponent.LastName, Opponent.Health, Opponent.Strength);
                Pause();
                Opponent.Health -= playerDice;
                Opponent.Strength -= 1;
                Player.Strength -= 1;
                PlayerPoints++;

                RoundLogMessage = Opponent.FirstName + " " + Opponent.LastName + " takes a blow of " + playerDice + ".\nLeaving the opponent with " + Opponent.Health + " health and " + Opponent.Strength + " strength.\nThe player with " + Player.Health + " health and " + Player.Strength + " strength.\nPlayer Wins The Round!";                
                Console.WriteLine(RoundLogMessage + "\n");
                Pause();

            }
            else
            {
                Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strenght: {3}\n", playerDice, Player.FirstName + " " + Player.LastName, Player.Health, Player.Strength);
                Pause();
                Console.WriteLine("{1} rolls a : {0}, Health: {2}, Strength: {3}\n", opponentDice, Opponent.FirstName + " " + Opponent.LastName, Opponent.Health, Opponent.Strength);
                Pause();
                Player.Health -= opponentDice;
                Player.Strength -= 1;
                Opponent.Strength -= 1;
                OpponentPoints ++;

                RoundLogMessage = Player.FirstName + " " + Player.LastName + " takes a blow of " + opponentDice + ".\nLeaving the player with " + Player.Health + " health and " + Player.Strength + " strength.\nThe opponent with " + Opponent.Health + " health and " + Opponent.Strength + " strength.\nOpponent Wins The Round!";
                Console.WriteLine(RoundLogMessage+ "\n");
                Pause();

            }
        }

        public void Pause()
        {
            var stopwatch = Stopwatch.StartNew();
            Thread.Sleep(750);
            stopwatch.Stop();
        }
    }
}
