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
            Lists.guessedLetters.Clear();

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

                RightOrWrongGuess(letter, randomWord, player);

                if (player.lives == 0)
                {
                    win = false;
                    break;
                }

                string indexPlaces = ReturnIndexPlace(letter, randomWord);

                GFX.Display.UpdateDisplay(Lists.guessedLetters, hiddenLetters, player);
                GFX.Display.ChangeHiddenLetters(ref hiddenLetters, indexPlaces, letter, player);
                if (!hiddenLetters.Contains("_"))
                {
                    win = true;
                    break;
                }

            } while (!gameOver);

            WinOrLose(win, player, randomWord);
        }

        private static void WinOrLose(bool win, Player player, string randomWord)
        {
            Console.Clear();
            if (win)
            {
                Console.WriteLine("Win!\n");

                AddPoints(player);
                Console.WriteLine($"Your current score: " + player.score);

                Console.Write("\nDo you want to play again? Y/N: ");
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
                            Menus.MainMenu();
                            break;

                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    } 
                } while (answer.ToUpper() != "Y" && answer.ToUpper() != "N");
            }
            else
            {
                Console.WriteLine("Lose!\n");
                Console.WriteLine("Your total score was: " + player.score);
                Console.WriteLine("Secret word was: " + randomWord.ToUpper());
                Helpers.Colors.Grey("\nPress enter to go to main menu");
                GFX.Display.EnterToStart();

                Lists.highScores.Add(player.score.ToString());
                player.score = 0;
                Menus.MainMenu();
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

        private static string ReturnIndexPlace(string aLetter, string word)
        {
            char letter = Convert.ToChar(aLetter);
            string returnString = string.Empty;

            if (word.Contains(letter))
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
