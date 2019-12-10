using System;
using System.Collections.Generic;

namespace HangMan.GFX
{
    public static class Display
    {
        internal static void UpdateDisplay(List<char> letters, string[] hiddenLetters, Player player)
        {
            Console.Clear();

            PlayerInfo(player);
            HowManyLivesLeft(player);
            PrintHiddenLetters(hiddenLetters);
            GuessedLetters(letters);
        }

        public static void HowManyLivesLeft(Player player)
        {
            switch (player.lives)
            {
                case 10:
                    ASCII.TenLivesLeft();
                    break;
                case 9:
                    ASCII.NineLivesLeft();
                    break;
                case 8:
                    ASCII.EightLivesLeft();
                    break;
                case 7:
                    ASCII.SevenLivesLeft();
                    break;
                case 6:
                    ASCII.SixLivesLeft();
                    break;
                case 5:
                    ASCII.FiveLivesLeft();
                    break;
                case 4:
                    ASCII.FourLivesLeft();
                    break;
                case 3:
                    ASCII.ThreeLivesLeft();
                    break;
                case 2:
                    ASCII.TwoLivesLeft();
                    break;
                case 1:
                    ASCII.OneLifeLeft();
                    break;
                case 0:
                    ASCII.ZeroLivesLeft();
                    break;
            }
        }

        internal static void PrintHighScore()
        {

        }

        internal static void InitialUpdate(string[] hiddenLetters, Player player)
        {
            Console.Clear();
            PlayerInfo(player);
            HowManyLivesLeft(player);
            PrintHiddenLetters(hiddenLetters);
            Console.WriteLine("\n\n");
        }

        internal static void WinDisplay(Player player)
        {
            PlayerInfo(player);
            HowManyLivesLeft(player);
            Console.SetCursorPosition(18, Console.CursorTop);
            Helpers.Colors.Green("YOU WIN!");
            Helpers.Colors.Grey("\n\n____________________________________________\n");

            Console.WriteLine($"\n\nYour current score: " + player.score);
        }

        private static void PlayerInfo(Player player)
        {
            Helpers.Colors.Grey($"Player: {player.Name}\n" + $"Score: {player.score}");
        }

        public static void LoseDisplay(Player player, string randomWord)
        {
            Console.WriteLine("");
            HowManyLivesLeft(player);
            Console.SetCursorPosition(18, Console.CursorTop);
            Helpers.Colors.Red("YOU LOSE");
            Helpers.Colors.Grey("\n\n____________________________________________\n");

            Console.WriteLine("\n\nYour total score was: " + player.score);
            Console.WriteLine("Secret word was: " + randomWord.ToUpper());
        }

        public static void ChangeHiddenLetters(ref string[] hiddenLetters, string indexPlaces, string letter, Player player)
        {
            string[] indexString = indexPlaces.Split(',');
            int[] indexInt = new int[indexString.Length];

            if (indexPlaces != "")
            {
                for (int i = 0; i < indexInt.Length; i++)
                {
                    indexInt[i] = int.Parse(indexString[i]);
                }

                for (int i = 0; i < hiddenLetters.Length; i++)
                {
                    for (int j = 0; j < indexInt.Length; j++)
                    {
                        if (i == indexInt[j])
                        {
                            hiddenLetters[i] = letter.ToUpper();
                            UpdateDisplay(Lists.guessedLetters, hiddenLetters, player);
                        }
                    }
                }
            }
        }

        private static void PrintHiddenLetters(string[] hiddenLetters)
        {
            StartPrintingFrom(hiddenLetters);

            foreach (var letter in hiddenLetters)
            {
                Console.Write(letter + "  ");
            }
            Helpers.Colors.Grey("\n\n____________________________________________\n");
        }

        static void GuessedLetters(List<char> letters)
        {
            Console.Write("  ");
            foreach (var letter in letters)
            {
                Console.Write(letter + "  ");
            }
            Console.WriteLine("\n\n");
        }

        public static void StartPrintingFrom(string[] word)
        {
            Console.SetCursorPosition(21, Console.CursorTop);

            int ctr = 0;

            foreach (var letter in word)
            {
                Console.Write("\b");
                ctr++;

                if (word.Length > 5 && ctr % 3 == 0)
                {
                    Console.Write("\b");
                }
            }

            if (word.Length >= 14)
            {
                Console.Write("\b");
            }
        }

        public static void EnterToStart()
        {
            ConsoleKeyInfo info;

            do
            {
                info = Console.ReadKey();
                if (info.Key != ConsoleKey.Enter)
                {
                    Console.Write("\b \b");
                }

            } while (info.Key != ConsoleKey.Enter);
        }
    }
}