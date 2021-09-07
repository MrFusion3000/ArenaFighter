using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Newtonsoft.Json;

namespace ArenaFighter
{
    public class Highscore
    {
        private string name;
        private int score;
        //private DateTime date;

        public Highscore(string name, int score) //, DateTime date)
        {
            this.name = name;
            this.score = score;
            //this.date = date;
        }

        public string Name
        {
            get { return name; }
            set { name = value;}
        }

        public int Score
        {
            get { return score;}
            set { score = value; }
        }
        //public DateTime Date { get; set; }
        
    }
}
