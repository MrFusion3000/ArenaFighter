using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Dice
    {
       private readonly Random _randomDice = new Random();

        public int RandomDice(int min, int max)
        {            
            return _randomDice.Next(min,max);
        }
    }
}
