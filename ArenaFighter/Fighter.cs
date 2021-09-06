using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaFighter
{
    public class Fighter
    {
        //Fighter Overload 0 - if name is omitted it's considered to be an opponent
        public Fighter() 
        {
            FirstName = OpponentRndFirstName();
            LastName = OpponentRndLastName();
            Health = AttributeConfig();
            Strength = AttributeConfig();
        }

        //Fighter Overload 1 - if name is entered it's considered to be the player
        public Fighter(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Health = AttributeConfig();
            Strength = AttributeConfig();
            TotalScore = 0;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Strength { get; set; }
        public int Health { get;  set; }
        public int TotalScore { get; set; }

        //public override string ToString() => FirstName + LastName;

        public int AttributeConfig()
        {
            Dice rndDice1 = new Dice(1, 6);
            Dice rndDice2 = new Dice(1, 6);

            int rnd = rndDice1.ThrowDice * rndDice2.ThrowDice;
            return rnd;
        }

        private readonly Dice rndDiceFirst = new Dice(0, 9);
        private readonly Dice rndDiceLast = new Dice(0, 9);

        public string OpponentRndFirstName()
        {
            var OpponentFirstNameList = new List<string>
            {
                "Sven",
                "Colt",
                "Sayonarah Sarah",
                "Billy-Bob",
                "Cletus",
                "Firehawk",
                "Berzerk",
                "Lindaaargh",
                "Nadine",
                "Witchmastress"
            };

            // Randomize Firstname from list
            string OpponentFirstName = OpponentFirstNameList.ElementAt(rndDiceFirst.ThrowDice);

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
                "Berzerker",
                "Sssmasher",
                "Hornblower",
                "MacDougall"
            };

            // Randomize Lastname from list
            string OpponentLastName = OpponentLastNameList.ElementAt(rndDiceLast.ThrowDice);

            return OpponentLastName;
        }
    }
}
