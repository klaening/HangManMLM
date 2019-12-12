using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    public class Lists
    {
        public static List<char> guessedLetters = new List<char>();

        public static string[] CreateHiddenWordArray(string word)
        {
            string[] hiddenWord = new string[word.Length];

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = "_";
            }

            return hiddenWord;
        }

        public static string GetRandomWord(dynamic rnd)
        {
            string randomWord = string.Empty;
            string[] allWords = File.ReadAllLines("Words.txt");

            int indexPlace = rnd.Next(0, allWords.Length);

            for (int i = 0; i <= allWords.Length; i++)
            {
                if (indexPlace == i)
                {
                    randomWord = allWords[i];
                }
            }
            return randomWord.ToUpper();
        }

        public static string GetHighScore()
        {
            string highScore;
            using (StreamReader sr = new StreamReader("HighScore.txt"))
            {
                highScore = sr.ReadToEnd();
            }

            highScore = highScore.Remove(highScore.LastIndexOf(Environment.NewLine));

            return highScore;
        }

        public static void SaveHighScore(Player player)
        {
            using (StreamWriter sw = File.AppendText("HighScore.txt"))
            {
                sw.WriteLine(player.name + " " + player.score.ToString());
            }
        }

        internal static string[] SplitForEveryLine(string rawString)
        {
            string[] everyNewLine = rawString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            return everyNewLine;
        }

        internal static List<Player> SplitAndSort(string[] everyNewLine)
        {
            List<Player> playerHighScores = new List<Player>();

            for (int i = 0; i < everyNewLine.Length; i++)
            {
                string[] nameAndScore = everyNewLine[i].Split(' ');

                string playerName = nameAndScore[0];
                int playerScore = int.Parse(nameAndScore[1]);

                Player player = new Player(playerName, playerScore);

                playerHighScores.Add(player);
            }

            List<Player> sortedPlayerHighScores = playerHighScores.OrderByDescending(p=>p.score).ToList();

            List<Player> topTenPlayerHighScores = sortedPlayerHighScores.Take(10).ToList();

            return topTenPlayerHighScores;
        }
    }
}
