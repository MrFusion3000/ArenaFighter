using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Newtonsoft.Json;

namespace ArenaFighter
{
    public class Highscore
    {
        private string firstName;
        private string lastName;
        private int score;
        //private DateTime date;

        public Highscore(string firstName, string lastName, int score) //, DateTime date)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.score = score;
            //this.date = date;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;}
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value;}
        }

        public int Score
        {
            get { return score;}
            set { score = value; }
        }
        //public DateTime Date { get; set; }
        
    }
}
