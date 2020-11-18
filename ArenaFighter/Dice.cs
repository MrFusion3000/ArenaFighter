using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Dice
    {
        //Dice Overload 0 - Generate Dice throw
        //public Dice()
        //{
        //    ThrowDice = RandomDice(1,6);
        //}

        //Dice Overload 1 - Generate Dice throw with min max
        public Dice(int min, int max)
        {
            ThrowDice = RandomDice(min, max);
        }                

        private int RandomDice(int min, int max)
        {
            return _randomDice.Next(min, max);
        }

        public int ThrowDice { get; set; }

        private readonly Random _randomDice = new Random();

    }
}
