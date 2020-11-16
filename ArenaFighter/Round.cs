using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Round
    {
        public int FightRound()
        {
            Dice rndDice = new Dice();
            int fighterDice = rndDice.RandomDice(1, 6);

            //Console.WriteLine("Fighter rolls a : {0}", fighterDice);

            return (fighterDice);
        } 
    }
}
