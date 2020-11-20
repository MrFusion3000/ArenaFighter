using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ArenaFighter
{
    public class Highscore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        //public List<Highscore> Highscores { get; set; }

        public Highscore()
        {            
        }

        public Highscore(string firstName, string lastName, int score)
        {
            Name = firstName + " " + lastName;
            Score = score;
        }

        public static void PrintHighScoreList(List<Highscore> Highscores)
        {
            List<Highscore> _highscores = Highscores.OrderByDescending(o => o.Score).ToList();

            //List<Highscore> SortedList = _highscores.OrderBy(o => o.Score).ToList();

            int j = 0;
            foreach (var item in _highscores)
            {
                Console.WriteLine(_highscores[j].Name + "\t-\t" + _highscores[j].Score + "\n");
                j++;
            }
        }
    }
}
