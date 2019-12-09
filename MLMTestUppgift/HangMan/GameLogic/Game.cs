using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMan
{
    public class Game
    {
        public static void StartGame(Player player)
        {
            player.lives = 10;

            Player.CreatePlayer(ref player);

            //TO DO: implementera en metod som hämtar ett random ord från en textfil.
            //TO DO: orden får inte vara större än 15 karaktärer
            string randomWord = Lists.GetRandomWord();

            string[] hiddenLetters = Lists.CreateHiddenWordArray(randomWord);

            bool gameOver = false;
            bool win = false;

            GFX.Display.InitialUpdate(hiddenLetters, player);

            do
            {
                ConsoleKey info;
                string letter = string.Empty;

                Console.WriteLine("Choose a letter to guess");

                do
                {
                    info = Guess.GuessLetter();
                    letter = Guess.ValidateLetter(info, ref letter);

                } while (info != ConsoleKey.Enter || letter == string.Empty);                
                
                if (gameOver)
                {
                    break;
                }

                //Kan vi slänga in detta i ReturnIndexPlace()? En kodrad som vi kan få plats med
                //Unit testing?
                bool containsLetter = RightOrWrongGuess(letter, randomWord, player);

                if (player.lives == 0)
                {
                    win = false;
                    break;
                }

                string indexPlaces = ReturnIndexPlace(containsLetter, letter, randomWord);

                GFX.Display.UpdateDisplay(Lists.guessedLetters, hiddenLetters, player);
                GFX.Display.ChangeHiddenLetters(ref hiddenLetters, indexPlaces, letter, player);
                if (!hiddenLetters.Contains("_"))
                {
                    win = true;
                    break;
                }

            } while (!gameOver);

            WinOrLose(win, player);
        }

        private static void WinOrLose(bool win, Player player)
        {
            Console.Clear();
            if (win)
            {
                Console.WriteLine("Win!");

                AddPoints(player);
                Console.WriteLine(player.score);
                //Player får poäng beroende på hur snabbt hen gissade rätt

                Console.Write("Do you want to play again? Y/N: ");
                string answer = Console.ReadLine();

                do
                {
                    switch (answer.ToUpper())
                    {
                        case "Y":
                            StartGame(player);
                            break;
                        case "N":
                            Lists.highScores.Add(player.score.ToString());
                            player.score = 0;
                            //Anropa huvudmenyn
                            break;
                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    } 
                } while (answer.ToUpper() != "Y" && answer.ToUpper() != "N");
            }
            else
            {
                Console.WriteLine("Lose!");

                Lists.highScores.Add(player.score.ToString());
                player.score = 0;
                //Player förlorar spelet och den poäng man har lagras som playerns high score
                //Anropa huvudmenyn
            }
        }

        private static void AddPoints(Player player)
        {
            switch (player.lives)
            {
                case 10:
                    player.score += 500;
                    break;
                case 9:
                    player.score += 100;
                    break;
                case 8:
                    player.score += 80;
                    break;
                case 7:
                    player.score += 80;
                    break;
                case 6:
                    player.score += 60;
                    break;
                case 5:
                    player.score += 60;
                    break;
                case 4:
                    player.score += 40;
                    break;
                case 3:
                    player.score += 40;
                    break;
                case 2:
                    player.score += 20;
                    break;
                case 1:
                    player.score += 20;
                    break;
                case 0:
                    player.score += 0;
                    break;
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
        public static bool RightOrWrongGuess(string letter, string word, Player player)
        {
            if (!word.Contains(letter))
            {
                player.lives--;
            }

            return word.Contains(letter);
        }
    }
}
