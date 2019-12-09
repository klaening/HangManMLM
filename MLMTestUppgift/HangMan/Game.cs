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
            player.lives = 10;

            Player.CreatePlayer(ref player);

            //TO DO: implementera en metod som hämtar et random ord från en textfil.
            //TO DO: orden får inte vara större än 15 karaktärer
            string randomWord = Words.GetRandomWord();

            string[] hiddenLetters = Lists.CreateHiddenWordArray(randomWord);

            bool gameOver = false;
            bool win = false;

            Display.InitialUpdate(hiddenLetters, player);

            do
            {
                string letter = Guess.Letter();
                if (gameOver)
                {
                    break;
                }

                //Kan vi slänga in detta i ReturnIndexPlace()? En kodrad som vi kan få plats med
                bool containsLetter = RightOrWrongGuess(letter, randomWord, player, ref win);

                if (player.lives == 0)
                {
                    break;
                }

                string indexPlaces = ReturnIndexPlace(containsLetter, letter, randomWord);

                Display.UpdateDisplay(Lists.guessedLetters, hiddenLetters, player);
                Display.ChangeHiddenLetters(ref hiddenLetters, indexPlaces, letter, player);
                //TO DO: om hiddenLetters inte innehåller '_' så har man gissat rätt på ordet.
                Console.WriteLine(player.lives);

            } while (!gameOver);

            WinOrLose(win);
        }

        private static void WinOrLose(bool win)
        {
            Console.Clear();
            if (win)
            {
                Console.WriteLine("Win!");
                //Player får poäng beroende på hur snabbt hen gissade rätt
            }
            else
            {
                Console.WriteLine("Lose!");

                //Player förlorar spelet och den poäng man har lagras som playerns high score
                //Anropa huvudmenyn
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

        private static bool RightOrWrongGuess(string letter, string word, Player player, ref bool win)
        {
            if (!word.Contains(letter))
            {
                player.lives--;
            }

            if (player.lives == 0)
            {
                win = false;
            }
            return word.Contains(letter);
        }
    }
}
