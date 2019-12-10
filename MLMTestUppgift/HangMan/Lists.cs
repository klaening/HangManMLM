﻿using System;
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
        public static List<string> highScores = new List<string>();

        public static string[] CreateHiddenWordArray(string word)
        {
            string[] hiddenWord = new string[word.Length];
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = "_";
            }
            return hiddenWord;
        }

        public static string GetRandomWord()
        {
            string randomWord = string.Empty;
            string[] wordArray = File.ReadAllLines("Words.txt");

            Random rnd = new Random();
            int word = rnd.Next(0, wordArray.Length);

            for (int i = 0; i <= wordArray.Length; i++)
            {
                if (word == i)
                {
                    randomWord = wordArray[i];
                }
            }
            return randomWord;
        }



        public string GetHighScore()
        {
            string highScore = "";

            using (StreamReader sr = new StreamReader("HighScore.txt"))
            {
                highScore = sr.ReadLine();
            }

            return highScore;
        }

        public void SaveHighScore(Player player)
        {
            using (StreamWriter sw = new StreamWriter("HighScore.txt"))
            {
                highScores.Add(player.score.ToString());

                sw.WriteLine(player.score);
            }
        }
    }
}
