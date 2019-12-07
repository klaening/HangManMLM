using System;
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

            Player.CreatePlayer(ref player);

            //TO DO: implementera en metod som hämtar et random ord från en textfil.
            //TO DO: orden får inte vara större än 15 karaktärer
            string randomWord = "mamma";

            string[] hiddenLetters = Lists.CreateHiddenWordArray(randomWord);

            bool gameOver = false;
            bool win = false;

            Display.InitialUpdate(hiddenLetters);

            do
            {
                string letter = Guess.Letter(ref win, ref gameOver, randomWord);
                if (gameOver)
                {
                    break;
                }

                //Metod som kollar ifall man har gissat på bokstaven redan. Returnerar bool. Sätt följande metoder i en if

                bool containsLetter = DoesWordContain(letter, randomWord);

                string indexPlaces = ReturnIndexPlace(containsLetter, letter, randomWord);

                Display.UpdateDisplay(Lists.guessedLetters, hiddenLetters);
                Display.ChangeHiddenLetters(ref hiddenLetters, indexPlaces, letter);

            } while (!gameOver);

            WinOrLose(win);
        }

        private static void WinOrLose(bool win)
        {
            if (win)
            {
                Console.WriteLine("Win!");
                //Player får poäng beroende på hur snabbt hen gissade rätt
            }
            else
            {
                Console.WriteLine("Lose!");
                //Player förlorar spelet och den poäng man har lagras som playerns high score
            }
        }

        //Sätta denna metod i en egen klass för alla ord?
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
