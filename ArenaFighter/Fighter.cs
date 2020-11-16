using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Fighter
    {
        public string Name { get; set = FighterConfig; }
        public int Strength { get; set; }


        public int FighterConfig()
        {
            Dice rndDice = new Dice();

            int _strength;

            _strength = rndDice.RandomDice(1,6);

            return _strength;
        }
    }
}
