using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ArenaFighter
{
    public class Highscore
    {
        // public Highscore(string addHighScoreEntry)
        // {
        //     AddHighScoreEntry = addHighScoreEntry;
        // }

        private static string Name { get; set; }
        private static int Score { get; set; }
        private static string AddHighScoreEntry { get; set; }

        //public List<Highscore> Highscores { get; set; }

        public static void AddNewHighscore(string firstName, string lastName, int score)
        {
            Name = firstName + " " + lastName;
            Score = score;
            AddHighScoreEntry = Name + " " + Score;
            
            WriteHighScoreList(AddHighScoreEntry);
            
            //TODO Add number of won games (and no of won rounds)
        }

        private static async void WriteHighScoreList(string addHighScoreEntry)
        {
            await File.WriteAllTextAsync("HighScoreList.txt", addHighScoreEntry, CancellationToken.None);
        }

        // private static async Task<IEnumerable> ReadHighScoreListAsync()
        // {
        //     var highScoreListRead = await File.ReadAllLinesAsync(@"/HighScoreList.txt");
        //     return highScoreListRead;
        // }
        //public static void PrintHighScoreList(IEnumerable<Highscore> Highscores)
        public static void PrintHighScoreList()
        {
            if (!File.Exists("HighScoreList.txt"))
                WriteHighScoreList("Anonymouse 0");
                
            var highscores = File.ReadAllLines(@"/HighScoreList.txt");
            //Task<IEnumerable> highscores = ReadHighScoreListAsync();
            
            //Console.WriteLine(highscores);
            
            //_highscores = Highscores.OrderByDescending(o => o.Score).ToList();

            //List<Highscore> SortedList = _highscores.OrderBy(o => o.Score).ToList();

            //var j = 0;
            foreach (var item in highscores)
            {
                //Console.WriteLine(_highscores[j].Name + "\t-\t" + _highscores[j].Score + "\n");
                Console.WriteLine(item);
                //j++;
            }
        }
    }
}
