using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ArenaFighter
{
    public class HighscoreCommand
    {
        private static Highscore Highscore { get; set; } = new Highscore(null,null,0);
        //private static string AddHighScoreEntry { get; set; }
        private const string SavedHighscoreListName = @"Highscore" + ".txt";
        private List<Highscore> highscoreList = new List<Highscore>();

        //public List<Highscore> Highscores { get; set; }

        public static void AddNewHighscore(string firstName, string lastName, int score)
        {
            Highscore.FirstName = firstName;
            Highscore.LastName = lastName;
            Highscore.Score = score;
            //Highscore.Date = DateTime.Now;
            //AddHighScoreEntry = "name" + highscoreName + ":" + highscoreScore + ","; // + " " + Highscore.Date;
            
            WriteHighScoreList(Highscore);
            
            //TODO Add number of won games (and no of won rounds) and/or cash prize
            //cash could be used to train or for equipment
        }

        private static async void WriteHighScoreList(Highscore highscore)
        {
            var newhighscore = new Highscore(highscore.FirstName, highscore.LastName, highscore.Score);

            //var result = JsonConvert.SerializeObject(AddHighScoreEntry, Formatting.None);
            var result = JsonConvert.SerializeObject(newhighscore);

            Console.WriteLine(File.Exists(SavedHighscoreListName)
                ? "Fetching Highscores..."
                : "No Highscores exists. Creating list...");

            await using var sw = File.AppendText(SavedHighscoreListName);
            await sw.WriteLineAsync(result);

            sw.Close();

            Console.WriteLine("Highscore saved. Ready.");
        }

        public static Highscore ReadHighScoreList()
        {
            Highscore highscoreList = null;

            using var sr = File.OpenText(SavedHighscoreListName); 
            var s = "";

            while ((s = sr.ReadLine()) != null)
            {
                try
                {
                    highscoreList = JsonConvert.DeserializeObject<Highscore>(s);
                    //highscoreList.Add(new Highscore(highscoreRead.));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something wrong: {ex}");
                }
            }

            return highscoreList;

            //if (!File.Exists("HighScoreList.txt"))
            //WriteHighScoreList("Anonymouse 0");

            //var highscores = File.ReadAllLines(@"/HighScoreList.txt");
            //Task<IEnumerable> highscores = ReadHighScoreListAsync();

            //Console.WriteLine(highscores);

            //_highscores = Highscores.OrderByDescending(o => o.Score).ToList();

            //List<Highscore> SortedList = _highscores.OrderBy(o => o.Score).ToList();

            //var j = 0;
            //foreach (var item in highscores)
            //{
            //Console.WriteLine(_highscores[j].Name + "\t-\t" + _highscores[j].Score + "\n");
            //Console.WriteLine(item);
            //j++;
            //}
        }
        
        public List<Highscore> InitCreateTop10()
        {
            for (int i = 0; i < 9; i++)
            {
                highscoreList.Add(new Highscore("Anony","mouse", 1+i));
            }
            
            highscoreList = highscoreList.OrderByDescending(o => o.Score).ToList();

            List<Highscore> SortedList = highscoreList.OrderBy(o => o.Score).ToList();

            return highscoreList;
        }
    }
}