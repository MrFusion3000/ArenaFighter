using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaFighter
{
    class Fighter
    {
        //private int _strength; //field
        //private int _health; //field

        //Fighter Overload 0 - if name is omitted it's considered to be an opponent
        public Fighter() 
        {
            FirstName = OpponentRndFirstName();
            LastName = OpponentRndLastName();
            Health = HealthConfig();
            Strength = StrengthConfig();
        }

        //Fighter Overload 1 - if name is entered it's considered to be the player
        public Fighter(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Health = HealthConfig();
            Strength = StrengthConfig();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Strength { get; set; }

        public int Health { get;  set; }

        public override string ToString() => FirstName + LastName;

        public int StrengthConfig()
        {
            Dice rndDice = new Dice();

            return rndDice.ThrowDice;
        }

        public int HealthConfig()
        {
            Dice rndDice = new Dice();

            return rndDice.ThrowDice;
        }

        public string OpponentRndFirstName()
        {
            var OpponentFirstNameList = new List<string>
            {
                "Sven",
                "Colt",
                "Sayonarah",
                "Billy-Bob",
                "Cletus",
                "Firehawk",
                "Berzerk",
                "Lindaaargh",
                "Nadine",
                "Witchmastress"
            };

            Dice rndDice = new Dice(1,10);

            // Randomize name from list
            string OpponentFirstName = OpponentFirstNameList.ElementAt(rndDice.ThrowDice);

            return OpponentFirstName;
        }

        public string OpponentRndLastName()
        {
            var OpponentLastNameList = new List<string>
            {
                "Jolt",
                "Shootfirst",
                "Vindalooloo",
                "Jo-Bob",
                "Washbagger",
                "Flamer",
                "Berzerk",
                "Biatchsmasher",
                "Hornblower",
                "MacDougall"
            };

            Dice rndDice = new Dice(1,10);

            // Randomize name from list
            string OpponentLastName = OpponentLastNameList.ElementAt(rndDice.ThrowDice);

            return OpponentLastName;
        }
    }
}
