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

            await using var sw = File.AppendText(SavedHighscoreListName);
            await sw.WriteLineAsync(result);

            sw.Close();
        }

        public static List<Highscore> ReadHighScoreList()
        {
            Highscore highscore = null;
            List<Highscore> highscoreList = new List<Highscore>();

            using var sr = File.OpenText(SavedHighscoreListName); 
            var s = "";

            while ((s = sr.ReadLine()) != null)
            {
                try
                {
                    highscore = JsonConvert.DeserializeObject<Highscore>(s);
                    highscoreList.Add(new Highscore(highscore.FirstName,highscore.LastName, highscore.Score));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something wrong: {ex}");
                }
            }
            return highscoreList;
        }

        public List<Highscore> InitCreateTop10()
        {
            Console.WriteLine(File.Exists(SavedHighscoreListName)
                ? "Fetching Highscores..."
                : "No Highscores exists. Creating list...");
            
            if (!File.Exists("Highscore.txt"))
            {
                for (int i = 0; i < 9; i++)
                {
                    highscoreList.Add(new Highscore("Anony","mouse", 1+i));
                }
                foreach (var HighscoreEntry in highscoreList)
                {
                    AddNewHighscore(HighscoreEntry.FirstName, HighscoreEntry.LastName, HighscoreEntry.Score);
                }
            }

            //highscoreList = highscoreList.OrderBy(o => o.Score).ToList();
            //Console.WriteLine("Highscore saved. Ready.");

            return highscoreList;
        }

        public void PrintHighscoreList()
        {
            var highscoreList = ReadHighScoreList();
            var tab = "";
            var fullName = "";
            highscoreList = highscoreList.OrderByDescending(o => o.Score).ToList();
            
            // Clear txt-file
            File.WriteAllText(SavedHighscoreListName, String.Empty);

            if (highscoreList.Count < 10)
            {
                highscoreList.Add(new Highscore("Anony","mouse", 1));
            }
            for (int i = 0; i < 10; i++)
            {
                fullName = highscoreList[i].FirstName + highscoreList[i].LastName;
                //Write each line to console
                if (fullName.Length <= 8)
                {
                    tab = "\t\t\t";
                }
                //else if (fullName.Length >= 11)
                //{
                //    tab = "";
                //}
                else
                {
                    tab = "\t\t";
                }
                Console.WriteLine("{4}\t{0} {1}{3}{2}",
                    highscoreList[i].FirstName,highscoreList[i].LastName, highscoreList[i].Score, tab, i+1);
                //Write enach entry to file
                AddNewHighscore(highscoreList[i].FirstName, highscoreList[i].LastName, highscoreList[i].Score);
            }

            //TrimHighscoreList();
        }

        private static void TrimHighscoreList()
        {
            var lines = System.IO.File.ReadAllLines(SavedHighscoreListName);
            var lineCount = lines.Length - 10;

            System.IO.File.WriteAllLines(SavedHighscoreListName, lines.Take(lines.Length - lineCount).ToArray());
        }
    }
}