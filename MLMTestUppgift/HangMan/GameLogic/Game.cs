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
        public static int ctr = 1;

        public static dynamic rnd = new Random();

        public static void StartGame(Player player)
        {
            Console.Title = "Word #" + ctr;

            player.lives = 10;
            Lists.guessedLetters.Clear();

            string randomWord = Lists.GetRandomWord(rnd);

            string[] hiddenLetters = Lists.CreateHiddenWordArray(randomWord);

            bool win;

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

            } while (true);

            WinOrLose(win, player, randomWord);
        }

        private static void WinOrLose(bool win, Player player, string randomWord)
        {
            Console.Clear();
            
            if (win)
            {
                AddPoints(player);
                GFX.Display.WinDisplay(player);

                string answer;

                do
                {
                    Helpers.Colors.Grey("\nDo you want to play again? Y/N: ");
                    answer = Console.ReadLine();

                    switch (answer.ToUpper())
                    {
                        case "Y":
                            ctr++;
                            StartGame(player);
                            break;

                        case "N":
                            Lists.SaveHighScore(player);
                            player.score = 0;
                            Menus.MainMenu();
                            break;

                        default:
                            //Console.WriteLine("Wrong input!");
                            Helpers.Messages.ErrorMessage("Wrong input!");
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            break;
                    } 
                } while (answer.ToUpper() != "Y" && answer.ToUpper() != "N");
            }
            else
            {
                GFX.Display.LoseDisplay(player, randomWord);

                Helpers.Colors.Grey("\nPress enter to go to main menu");
                Helpers.Messages.PressEnterToContinue();

                Lists.SaveHighScore(player);
                player.score = 0;
                ctr = 1;

                Menus.MainMenu();
            }
        }

        public static void AddPoints(Player player)
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
            }
        }

        public static string ReturnIndexPlace(string aLetter, string word)
        {
            string capitalLetter = aLetter.ToUpper();
            char letter = Convert.ToChar(capitalLetter);
            string indexPlaces = string.Empty;

            if (word.Contains(letter))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        if (indexPlaces == "")
                        {
                            indexPlaces = i.ToString();
                        }
                        else
                        {
                            indexPlaces += "," + i;
                        }
                    }
                }
            }

            return indexPlaces;
        }
        public static bool RightOrWrongGuess(string letter, string word, Player player)
        {
            string capitalLetter = letter.ToUpper();

            if (!word.Contains(capitalLetter))
            {
                player.lives--;
            }

            return word.Contains(letter);
        }
    }
}
