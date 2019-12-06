﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMan
{
    class Game
    {
        public static void StartGame()
        {
            Player player = new Player();

            Console.WriteLine("Welcome to Hang Man!");

            Player.CreatePlayer(ref player);

            //TO DO: implementera en metod som hämtar et random ord från en textfil.
            string randomWord = "mamma";

            string[] hiddenLetters = Lists.CreateHiddenWordArray(randomWord);

            bool gameOver = false;
            bool win = false;

            Graphics.InitialUpdate(hiddenLetters);

            do
            {
                string letter = Guess.Letter(ref win, ref gameOver, randomWord);
                if (gameOver)
                {
                    break;
                }

                bool containsLetter = DoesWordContain(letter, randomWord);

                string indexPlaces = ReturnIndexPlace(containsLetter, letter, randomWord);

                Graphics.UpdateDisplay(Lists.guessedLetters, hiddenLetters);
                Graphics.ChangeHiddenLetters(ref hiddenLetters, indexPlaces, letter);

            } while (!gameOver);

            WinOrLose(win);
        }

        private static void WinOrLose(bool win)
        {
            if (win)
            {
                Console.WriteLine("Win!");
            }
            else
            {
                Console.WriteLine("Lose!");
            }
        }

        private static string ReturnIndexPlace(bool containsLetter, string aLetter, string word)
        {
            char letter = Convert.ToChar(aLetter);
            string returnString = string.Empty;


            if (containsLetter)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        if (returnString == "")
                        {
                            returnString = i.ToString();
                        }
                        else
                        {
                            returnString += "," + i;
                        }
                    }
                }
            }

            return returnString;
        }

        private static bool DoesWordContain(string letter, string word)
        {
            return word.Contains(letter);
        }
    }
}