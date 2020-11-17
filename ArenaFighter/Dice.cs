using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Dice
    {
        //Dice Overload 0 - Generate Dice throw
        public Dice()
        {
            ThrowDice = RandomDice(1,6);
        }

        public Dice(int min, int max)
        {
            ThrowDice = RandomDice(min, max);
        }

        public int ThrowDice { get; set; }

        private int RandomDice(int min, int max)
        {
            return _randomDice.Next(min, max);
        }

        //public int FightRound()
        //{
        //    Dice rndDice = new Dice();
        //    int fighterDice = rndDice.RandomDice(1, 6);

        //    return (fighterDice);
        //}

        private readonly Random _randomDice = new Random();

    }
}
